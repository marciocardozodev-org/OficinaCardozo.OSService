using Xunit;
using Microsoft.Extensions.DependencyInjection;
using OficinaCardozo.Application.DTOs;
using OficinaCardozo.Domain.Entities;
using FluentAssertions;
using OficinaCardozo.Tests.TestBase;

namespace OficinaCardozo.Tests.IntegrationTests;

public class OrdemServicoFluxoIntegrationTests : IntegrationTestBase
{
    [Fact]
    public async Task FluxoCompleto_CriacaoAteEntrega_DeveExecutarCorretamente()
    {
        var cliente = await CriarClienteTeste();
        var servico = await CriarServicoTeste();


        var createDto = new CreateOrdemServicoDto
        {
            ClienteCpfCnpj = cliente.CpfCnpj,
            VeiculoPlaca = "ABC1234",
            VeiculoMarcaModelo = "Honda Civic",
            VeiculoAnoFabricacao = 2020,
            VeiculoCor = "Branco",
            ServicosIds = new List<int> { servico.Id }
        };

      
        var ordemCriada = await OrdemServicoService.CreateOrdemServicoComOrcamentoAsync(createDto);
        ordemCriada.Should().NotBeNull();
        ordemCriada.StatusDescricao.Should().Be("Recebida");

        var diagnosticoIniciado = await OrdemServicoService.IniciarDiagnosticoAsync(ordemCriada.Id);
        diagnosticoIniciado.Should().NotBeNull();
        diagnosticoIniciado.StatusDescricao.Should().Be("Diagnostico iniciado");

        var diagnosticoFinalizado = await OrdemServicoService.FinalizarDiagnosticoAsync(ordemCriada.Id);
        diagnosticoFinalizado.StatusDescricao.Should().Contain("elaboracao");

        var enviarDto = new EnviarOrcamentoParaAprovacaoDto
        {
            IdOrcamento = diagnosticoFinalizado.Id
        };
        var orcamentoEnviado = await OrdemServicoService.EnviarOrcamentoParaAprovacaoAsync(enviarDto);
        orcamentoEnviado.StatusDescricao.Should().Be("Pendente aprovacao");

        var aprovarDto = new AprovarOrcamentoDto
        {
            IdOrcamento = orcamentoEnviado.Id,
            Aprovado = true
        };
        var orcamentoAprovado = await OrdemServicoService.AprovarOrcamentoAsync(aprovarDto);
        orcamentoAprovado.StatusDescricao.Should().Be("Aprovado");

        var servicoFinalizado = await OrdemServicoService.FinalizarServicoAsync(ordemCriada.Id);
        servicoFinalizado.StatusDescricao.Should().Be("Finalizada");
        servicoFinalizado.DataFinalizacao.Should().NotBeNull();

        var veiculoEntregue = await OrdemServicoService.EntregarVeiculoAsync(ordemCriada.Id);
        veiculoEntregue.StatusDescricao.Should().Be("Entregue");
        veiculoEntregue.DataEntrega.Should().NotBeNull();
    }

    [Fact]
    public async Task FluxoRejeicaoOrcamento_ComNovaPropostaComSucesso()
    {
        var cliente = await CriarClienteTeste();
        var servico = await CriarServicoTeste();
        var ordem = await CriarOrdemServicoTeste(cliente, servico);

        await OrdemServicoService.IniciarDiagnosticoAsync(ordem.Id);
        var diagnostico = await OrdemServicoService.FinalizarDiagnosticoAsync(ordem.Id);
        var enviarDto = new EnviarOrcamentoParaAprovacaoDto { IdOrcamento = diagnostico.Id };
        var orcamento = await OrdemServicoService.EnviarOrcamentoParaAprovacaoAsync(enviarDto);
        var rejeitarDto = new AprovarOrcamentoDto
        {
            IdOrcamento = orcamento.Id,
            Aprovado = false,
            SolicitarNovoOrcamento = true,
            MotivoRejeicao = "Preço muito alto"
        };

        var resultado = await OrdemServicoService.AprovarOrcamentoAsync(rejeitarDto);

        resultado.Should().NotBeNull();
        resultado.Id.Should().NotBe(orcamento.Id); 
        resultado.StatusDescricao.Should().Be("Criado");
        resultado.MensagemAprovacao.Should().Contain("Novo orçamento criado");
        resultado.MensagemAprovacao.Should().Contain("Preço muito alto");
    }

    [Fact]
    public async Task FluxoCancelamentoOrdemServico_DuranteDiagnostico_DeveCancelarComSucesso()
    {
        var cliente = await CriarClienteTeste();
        var servico = await CriarServicoTeste();
        var ordem = await CriarOrdemServicoTeste(cliente, servico);

        await OrdemServicoService.IniciarDiagnosticoAsync(ordem.Id);

        var cancelarDto = new CancelarOrdemServicoDto
        {
            IdOrdemServico = ordem.Id,
            MotivoCancelamento = "Cliente desistiu do serviço",
            ObservacoesAdicionais = "Cliente alegou urgência financeira",
            VeiculoDevolvido = true
        };

        var resultado = await OrdemServicoService.CancelarOrdemServicoAsync(cancelarDto);

        resultado.Should().NotBeNull();
        resultado.StatusDescricao.Should().Be("Devolvida");
      
        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            OrdemServicoService.IniciarExecucaoAsync(ordem.Id));
    }

    [Fact]
    public async Task FluxoDevolucaoVeiculoSemServico_AposRejeicaoFinal_DeveExecutarCorretamente()
    {
        var cliente = await CriarClienteTeste();
        var servico = await CriarServicoTeste();
        var ordem = await CriarOrdemServicoTeste(cliente, servico);

        await OrdemServicoService.IniciarDiagnosticoAsync(ordem.Id);
        var diagnostico = await OrdemServicoService.FinalizarDiagnosticoAsync(ordem.Id);
        var enviarDto = new EnviarOrcamentoParaAprovacaoDto { IdOrcamento = diagnostico.Id };
        await OrdemServicoService.EnviarOrcamentoParaAprovacaoAsync(enviarDto);

        var rejeitarDto = new AprovarOrcamentoDto
        {
            IdOrcamento = diagnostico.Id,
            Aprovado = false,
            SolicitarNovoOrcamento = false,
            MotivoRejeicao = "Valor muito acima do esperado"
        };
        await OrdemServicoService.AprovarOrcamentoAsync(rejeitarDto);

        var motivo = "Cliente rejeitou orçamento definitivamente";
        var resultado = await OrdemServicoService.DevolverVeiculoSemServicoAsync(ordem.Id, motivo);

        resultado.Should().NotBeNull();
        resultado.StatusDescricao.Should().Be("Devolvida");
        resultado.DataFinalizacao.Should().BeNull(); 
        resultado.DataEntrega.Should().NotBeNull(); 
        resultado.DataEntrega.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMinutes(1));

        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            OrdemServicoService.IniciarExecucaoAsync(ordem.Id));

        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            OrdemServicoService.FinalizarServicoAsync(ordem.Id));
    }
}