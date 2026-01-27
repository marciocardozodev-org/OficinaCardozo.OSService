using OficinaCardozo.OSService.Application.DTOs;
using OficinaCardozo.OSService.Domain.Entities;

namespace OficinaCardozo.OSService.Application.Interfaces;

public interface IServicoMapper
{
    ServicoDto MapearParaDto(Servico servico);
    IEnumerable<ServicoDto> MapearParaListaDto(IEnumerable<Servico> servicos);
    Servico MapearParaEntidade(CreateServicoDto createDto);
    void AtualizarEntidadeComDto(Servico servico, UpdateServicoDto updateDto);
}