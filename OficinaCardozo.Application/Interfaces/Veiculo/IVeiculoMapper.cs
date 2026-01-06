using OficinaCardozo.Application.DTOs;
using OficinaCardozo.Domain.Entities;

namespace OficinaCardozo.Application.Interfaces;

public interface IVeiculoMapper
{
    VeiculoDto MapearParaDto(Veiculo veiculo);
    IEnumerable<VeiculoDto> MapearParaListaDto(IEnumerable<Veiculo> veiculos);
    Veiculo MapearParaEntidade(CreateVeiculoDto createDto);
    void AtualizarEntidadeComDto(Veiculo veiculo, UpdateVeiculoDto updateDto);
}