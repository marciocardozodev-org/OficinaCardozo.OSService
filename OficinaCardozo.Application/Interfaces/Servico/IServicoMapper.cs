using OficinaCardozo.Application.DTOs;
using OficinaCardozo.Domain.Entities;

namespace OficinaCardozo.Application.Interfaces;

public interface IServicoMapper
{
    ServicoDto MapearParaDto(Servico servico);
    IEnumerable<ServicoDto> MapearParaListaDto(IEnumerable<Servico> servicos);
    Servico MapearParaEntidade(CreateServicoDto createDto);
    void AtualizarEntidadeComDto(Servico servico, UpdateServicoDto updateDto);
}