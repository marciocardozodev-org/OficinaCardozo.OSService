using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OficinaCardozo.Application.DTOs;
using OficinaCardozo.Application.Interfaces;
using OficinaCardozo.Application.Services;

namespace OficinaCardozo.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class OrdensServicoController : ControllerBase
{
    private readonly IOrdemServicoService _ordemServicoService;
    private readonly IServicoService _servicoService;
    private readonly IPecaService _pecaService;

    public OrdensServicoController(
        IOrdemServicoService ordemServicoService,
        IServicoService servicoService,
        IPecaService pecaService)
    {
        _ordemServicoService = ordemServicoService;
        _servicoService = servicoService;
        _pecaService = pecaService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrdemServicoDto>>> GetAll()
    {
        try
        {
            var ordensServico = await _ordemServicoService.GetAllAtivasAsync();
            return Ok(ordensServico);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro interno do servidor", details = ex.Message });
        }
    }

    [HttpGet("todas")]
    public async Task<ActionResult<IEnumerable<OrdemServicoDto>>> GetAllIncludingFinalized()
    {
        try
        {
            var ordensServico = await _ordemServicoService.GetAllAsync();
            return Ok(ordensServico);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro interno do servidor", details = ex.Message });
        }
    }

    [HttpGet("ativas")]
    public async Task<ActionResult<IEnumerable<OrdemServicoDto>>> GetAllAtivas()
    {
        try
        {
            var ordensServico = await _ordemServicoService.GetAllAtivasAsync();
            return Ok(ordensServico);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro interno do servidor", details = ex.Message });
        }
    }

    [HttpGet("servicos-selecao")]
    public async Task<ActionResult<IEnumerable<ServicoSelecaoDto>>> GetServicosParaSelecao()
    {
        try
        {
            var servicos = await _servicoService.GetAllAsync();
            var servicosSelecao = servicos.Select(s => new ServicoSelecaoDto
            {
                Id = s.Id,
                NomeServico = s.NomeServico,
                Preco = s.Preco,
                TempoEstimadoExecucao = s.TempoEstimadoExecucao,
                DescricaoDetalhadaServico = s.DescricaoDetalhadaServico
            });

            return Ok(servicosSelecao);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro interno do servidor", details = ex.Message });
        }
    }

    [HttpGet("pecas-selecao")]
    public async Task<ActionResult<IEnumerable<PecaSelecaoDto>>> GetPecasParaSelecao()
    {
        try
        {
            var pecas = await _pecaService.GetAllAsync();
            var pecasSelecao = pecas.Select(p => new PecaSelecaoDto
            {
                Id = p.Id,
                NomePeca = p.NomePeca,
                CodigoIdentificador = p.CodigoIdentificador,
                Preco = p.Preco,
                QuantidadeEstoque = p.QuantidadeEstoque,
                UnidadeMedida = p.UnidadeMedida,
                EstoqueBaixo = p.EstoqueBaixo
            });

            return Ok(pecasSelecao);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro interno do servidor", details = ex.Message });
        }
    }

 
    [HttpGet("pecas-com-estoque")]
    public async Task<ActionResult<IEnumerable<PecaSelecaoDto>>> GetPecasComEstoque()
    {
        try
        {
            var pecas = await _pecaService.GetAllAsync();
            var pecasComEstoque = pecas
                .Where(p => p.QuantidadeEstoque > 0)
                .Select(p => new PecaSelecaoDto
                {
                    Id = p.Id,
                    NomePeca = p.NomePeca,
                    CodigoIdentificador = p.CodigoIdentificador,
                    Preco = p.Preco,
                    QuantidadeEstoque = p.QuantidadeEstoque,
                    UnidadeMedida = p.UnidadeMedida,
                    EstoqueBaixo = p.EstoqueBaixo
                });

            return Ok(pecasComEstoque);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro interno do servidor", details = ex.Message });
        }
    }

   
    [HttpPost]
    public async Task<ActionResult<OrdemServicoDto>> CreateOrdemServicoComOrcamento([FromBody] CreateOrdemServicoDto createDto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ordemServico = await _ordemServicoService.CreateOrdemServicoComOrcamentoAsync(createDto);
            return CreatedAtAction(nameof(GetById), new { id = ordemServico.Id }, ordemServico);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro interno do servidor", details = ex.Message });
        }
    }

    
    [HttpGet("{id}")]
    public async Task<ActionResult<OrdemServicoDto>> GetById(int id)
    {
        try
        {
            var ordemServico = await _ordemServicoService.GetByIdAsync(id);
            if (ordemServico == null)
                return NotFound(new { message = "Ordem de servi�o n�o encontrada" });

            return Ok(ordemServico);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro interno do servidor", details = ex.Message });
        }
    }

    [HttpGet("orcamentos")]
    public async Task<ActionResult<IEnumerable<OrcamentoDto>>> GetAllOrcamentos()
    {
        try
        {
            var orcamentos = await _ordemServicoService.GetAllOrcamentosAsync();
            return Ok(orcamentos);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro interno do servidor", details = ex.Message });
        }
    }

   
    [HttpPost("{id}/iniciar-diagnostico")]
    [Authorize(Policy = "RequireCpf")]
    public async Task<ActionResult<OrcamentoResumoDto>> IniciarDiagnostico(int id)
    {
        try
        {
            var resultado = await _ordemServicoService.IniciarDiagnosticoAsync(id);
            return Ok(resultado);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro interno do servidor", details = ex.Message });
        }
    }

  
    [HttpPost("enviar-orcamento-para-aprovacao")]
    [Authorize(Policy = "RequireCpf")]
    public async Task<ActionResult<OrcamentoResumoDto>> EnviarOrcamentoParaAprovacao([FromBody] EnviarOrcamentoParaAprovacaoDto enviarDto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultado = await _ordemServicoService.EnviarOrcamentoParaAprovacaoAsync(enviarDto);
            return Ok(resultado);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro interno do servidor", details = ex.Message });
        }
    }

  
    [HttpPost("{id}/finalizar-diagnostico")]
    [Authorize(Policy = "RequireCpf")]
    public async Task<ActionResult<OrcamentoResumoDto>> FinalizarDiagnostico(int id)
    {
        try
        {
            var resultado = await _ordemServicoService.FinalizarDiagnosticoAsync(id);
            return Ok(resultado);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro interno do servidor", details = ex.Message });
        }
    }

    [HttpPost("aprovar-orcamento")]
    [Authorize(Policy = "RequireCpf")]
    public async Task<ActionResult<OrcamentoResumoDto>> AprovarOrcamento([FromBody] AprovarOrcamentoDto aprovarDto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultado = await _ordemServicoService.AprovarOrcamentoAsync(aprovarDto);
            return Ok(resultado);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro interno do servidor", details = ex.Message });
        }
    }

   
    [HttpPost("{id}/iniciar-execucao")]
    public async Task<ActionResult<OrdemServicoDto>> IniciarExecucao(int id)
    {
        try
        {
            var resultado = await _ordemServicoService.IniciarExecucaoAsync(id);
            return Ok(resultado);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro interno do servidor", details = ex.Message });
        }
    }

    
    [HttpPost("{id}/finalizar-servico")]
    [Authorize(Policy = "RequireCpf")]
    public async Task<ActionResult<OrdemServicoDto>> FinalizarServico(int id)
    {
        try
        {
            var resultado = await _ordemServicoService.FinalizarServicoAsync(id);
            return Ok(resultado);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro interno do servidor", details = ex.Message });
        }
    }

  
    [HttpPost("{id}/entregar-veiculo")]
    [Authorize(Policy = "RequireCpf")]
    public async Task<ActionResult<OrdemServicoDto>> EntregarVeiculo(int id)
    {
        try
        {
            var resultado = await _ordemServicoService.EntregarVeiculoAsync(id);
            return Ok(resultado);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro interno do servidor", details = ex.Message });
        }
    }
  
    [HttpPost("cancelar-ordem-servico")]
    public async Task<ActionResult<OrdemServicoDto>> CancelarOrdemServico([FromBody] CancelarOrdemServicoDto cancelarDto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultado = await _ordemServicoService.CancelarOrdemServicoAsync(cancelarDto);
            return Ok(resultado);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro interno do servidor", details = ex.Message });
        }
    }

    [HttpPost("{id}/devolver-veiculo-sem-servico")]
    public async Task<ActionResult<OrdemServicoDto>> DevolverVeiculoSemServico(int id, [FromBody] string motivo)
    {
        try
        {
            var resultado = await _ordemServicoService.DevolverVeiculoSemServicoAsync(id, motivo);
            return Ok(resultado);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro interno do servidor", details = ex.Message });
        }
    }

    [HttpPost("responder-orcamento")]
    public async Task<ActionResult<OrcamentoResumoDto>> ResponderOrcamento([FromBody] AprovarOrcamentoDto aprovarDto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultado = await _ordemServicoService.AprovarOrcamentoAsync(aprovarDto);
            return Ok(resultado);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro interno do servidor", details = ex.Message });
        }
    }

    [HttpPost("tempo-medio-execucao")]
    public async Task<ActionResult<TempoMedioExecucaoDto>> ObterTempoMedioExecucao([FromBody] FiltroTempoMedioDto? filtro = null)
    {
        try
        {
            var resultado = await _ordemServicoService.ObterTempoMedioExecucaoAsync(filtro);
            return Ok(resultado);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro interno do servidor", details = ex.Message });
        }
    }

    [HttpGet("resumo-tempo-execucao")]
    public async Task<ActionResult<object>> ObterResumoTempoExecucao()
    {
        try
        {
            var resultado = await _ordemServicoService.ObterResumoTempoExecucaoAsync();

            var response = new
            {
                resumoExecutivo = new
                {
                    totalOrdens = resultado.EstatisticasGerais.TotalOrdensAnalisadas,
                    ordensEntregues = resultado.EstatisticasGerais.TotalOrdensEntregues,
                    tempoMedioHoras = Math.Round(resultado.EstatisticasGerais.TempoMedioEntregaHoras, 1),
                    tempoMedioFormatado = resultado.EstatisticasGerais.TempoMedioFormatado,
                    performance = resultado.EstatisticasGerais.PerformanceGeral,
                    mensagem = resultado.EstatisticasGerais.ResumoExecutivo
                },

                ordensRecentes = resultado.OrdensServico
                    .Take(10)
                    .Select(o => new
                    {
                        id = o.IdOrdemServico,
                        cliente = o.ClienteNome,
                        veiculo = $"{o.VeiculoPlaca} - {o.VeiculoMarcaModelo}",
                        dataInicio = o.DataSolicitacao.ToString("dd/MM/yyyy HH:mm"),
                        dataEntrega = o.DataEntrega?.ToString("dd/MM/yyyy HH:mm") ?? "n�o entregue",
                        status = o.StatusDescricao,
                        tempoHoras = Math.Round(o.TempoEntregaHoras ?? o.TempoFinalizacaoHoras ?? 0, 1),
                        tempoFormatado = o.TempoFormatado,
                        performance = o.IndicadorPerformance,
                        valor = $"R$ {o.ValorTotal:N2}"
                    }),

                topClientes = resultado.TempoMedioPorCliente
                    .Take(10)
                    .Select(c => new
                    {
                        cliente = c.NomeCliente,
                        totalServicos = c.TotalOrdensEntregues,
                        tempoMedioHoras = Math.Round(c.TempoMedioHoras, 1),
                        tempoFormatado = c.TempoMedioFormatado,
                        valorMedio = $"R$ {c.ValorMedioOrdem:N2}",
                        performance = c.Performance,
                        classificacao = c.ClassificacaoCliente
                    }),

                indicadores = new
                {
                    servicosRapidos = resultado.OrdensServico.Count(o => (o.TempoEntregaHoras ?? 999) <= 24),
                    servicosLentos = resultado.OrdensServico.Count(o => (o.TempoEntregaHoras ?? 0) > 120),
                    servicosEmAndamento = resultado.EstatisticasGerais.TotalOrdensAnalisadas - resultado.EstatisticasGerais.TotalOrdensEntregues,
                    percentualEficiencia = resultado.EstatisticasGerais.TotalOrdensEntregues > 0
                        ? Math.Round((double)resultado.EstatisticasGerais.TotalOrdensEntregues / resultado.EstatisticasGerais.TotalOrdensAnalisadas * 100, 1)
                        : 0
                }
            };

            return Ok(response);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro interno do servidor", details = ex.Message });
        }
    }

    
    [HttpGet("dashboard-performance")]
    public async Task<ActionResult<object>> ObterDashboardPerformance()
    {
        try
        {
            var resultado = await _ordemServicoService.ObterResumoTempoExecucaoAsync();

            var dashboard = new
            {
                metricas = new
                {
                    tempoMedioGeral = new
                    {
                        horas = Math.Round(resultado.EstatisticasGerais.TempoMedioEntregaHoras, 1),
                        formatado = resultado.EstatisticasGerais.TempoMedioFormatado,
                        performance = resultado.EstatisticasGerais.PerformanceGeral
                    },
                    produtividade = new
                    {
                        totalServicosConcluidos = resultado.EstatisticasGerais.TotalOrdensEntregues,
                        servicosEmAndamento = resultado.EstatisticasGerais.TotalOrdensAnalisadas - resultado.EstatisticasGerais.TotalOrdensEntregues,
                        taxaConclusao = resultado.EstatisticasGerais.TotalOrdensAnalisadas > 0
                            ? Math.Round((double)resultado.EstatisticasGerais.TotalOrdensEntregues / resultado.EstatisticasGerais.TotalOrdensAnalisadas * 100, 1)
                            : 0
                    }
                },

                clientesMaisEficientes = resultado.TempoMedioPorCliente
                    .Take(5)
                    .Select(c => new
                    {
                        nome = c.NomeCliente,
                        tempoMedio = c.TempoMedioFormatado,
                        totalServicos = c.TotalOrdensEntregues,
                        badge = c.Performance.Split(' ')[0] // Pega apenas o emoji
                    }),

                alertas = new
                {
                    servicosLentos = resultado.OrdensServico.Count(o => (o.TempoEntregaHoras ?? 0) > 120),
                    clientesComProblemas = resultado.TempoMedioPorCliente.Count(c => c.TempoMedioHoras > 120),
                    oportunidadeMelhoria = resultado.EstatisticasGerais.TempoMedioEntregaHoras > 72
                        ? "⚠️ Tempo m�dio acima de 3 dias - revisar processos"
                        : "✅ Tempo m�dio dentro do esperado"
                },

                resumo = resultado.EstatisticasGerais.ResumoExecutivo
            };

            return Ok(dashboard);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro interno do servidor", details = ex.Message });
        }
    }

    [HttpGet("tempo-medio-execucao/simples")]
    public async Task<ActionResult<object>> ObterTempoMedioExecucaoSimples()
    {
        try
        {
            var resumo = await _ordemServicoService.ObterResumoTempoExecucaoAsync();

            return Ok(new
            {
                // Dados principais
                tempoMedioHoras = Math.Round(resumo.EstatisticasGerais.TempoMedioEntregaHoras, 1),
                tempoMedioFormatado = resumo.EstatisticasGerais.TempoMedioFormatado,
                totalServicosConcluidos = resumo.EstatisticasGerais.TotalOrdensEntregues,
                totalOrdens = resumo.EstatisticasGerais.TotalOrdensAnalisadas,

                // Performance
                performance = resumo.EstatisticasGerais.PerformanceGeral,
                eficiencia = resumo.EstatisticasGerais.TotalOrdensAnalisadas > 0
                    ? $"{Math.Round((double)resumo.EstatisticasGerais.TotalOrdensEntregues / resumo.EstatisticasGerais.TotalOrdensAnalisadas * 100, 1)}%"
                    : "0%",

                // Resumo
                mensagem = resumo.EstatisticasGerais.ResumoExecutivo,

                // Sugest͵es
                dicas = new[]
                {
                resumo.EstatisticasGerais.TempoMedioEntregaHoras <= 24
                    ? "Excelente! Continuem assim!"
                    : "Considere otimizar os processos para reduzir o tempo m�dio",
                "Use 'dashboard-performance' para an�lise detalhada",
                "Verifique 'performance-por-cliente' para insights espec�ficos"
            }
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro interno do servidor", details = ex.Message });
        }
    }


}