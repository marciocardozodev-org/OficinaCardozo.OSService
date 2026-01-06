using OficinaCardozo.Application.DTOs;
using OficinaCardozo.Application.Interfaces;
using OficinaCardozo.Domain.Entities;

namespace OficinaCardozo.Application.Mappers;

public class ServicoMapper : IServicoMapper
{
    public ServicoDto MapearParaDto(Servico servico)
    {
        ArgumentNullException.ThrowIfNull(servico);

        return new ServicoDto
        {
            Id = servico.Id,
            NomeServico = servico.NomeServico,
            Preco = servico.Preco,
            TempoEstimadoExecucao = servico.TempoEstimadoExecucao,
            DescricaoDetalhadaServico = servico.DescricaoDetalhadaServico,
            FrequenciaRecomendada = servico.FrequenciaRecomendada
        };
    }

    public IEnumerable<ServicoDto> MapearParaListaDto(IEnumerable<Servico> servicos)
    {
        ArgumentNullException.ThrowIfNull(servicos);
        return servicos.Select(MapearParaDto);
    }

    public Servico MapearParaEntidade(CreateServicoDto createDto)
    {
        ArgumentNullException.ThrowIfNull(createDto);

        return new Servico
        {
            NomeServico = createDto.NomeServico.Trim(),
            Preco = createDto.Preco,
            TempoEstimadoExecucao = createDto.TempoEstimadoExecucao,
            DescricaoDetalhadaServico = createDto.DescricaoDetalhadaServico?.Trim() ?? string.Empty,
            FrequenciaRecomendada = createDto.FrequenciaRecomendada?.Trim()
        };
    }

    public void AtualizarEntidadeComDto(Servico servico, UpdateServicoDto updateDto)
    {
        ArgumentNullException.ThrowIfNull(servico);
        ArgumentNullException.ThrowIfNull(updateDto);

        if (!string.IsNullOrWhiteSpace(updateDto.NomeServico))
            servico.NomeServico = updateDto.NomeServico.Trim();

        if (updateDto.Preco.HasValue)
            servico.Preco = updateDto.Preco.Value;

        if (updateDto.TempoEstimadoExecucao.HasValue)
            servico.TempoEstimadoExecucao = updateDto.TempoEstimadoExecucao.Value;

        if (!string.IsNullOrWhiteSpace(updateDto.DescricaoDetalhadaServico))
            servico.DescricaoDetalhadaServico = updateDto.DescricaoDetalhadaServico.Trim();

        if (!string.IsNullOrWhiteSpace(updateDto.FrequenciaRecomendada))
            servico.FrequenciaRecomendada = updateDto.FrequenciaRecomendada.Trim();
    }
}