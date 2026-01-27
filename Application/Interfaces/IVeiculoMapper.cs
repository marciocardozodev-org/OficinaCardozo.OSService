using OficinaCardozo.OSService.Application.DTOs;
using OficinaCardozo.OSService.Domain.Entities;
using System.Collections.Generic;

namespace OficinaCardozo.OSService.Application.Interfaces;

public interface IVeiculoMapper
{
    VeiculoDto MapearParaDto(Veiculo veiculo);
    IEnumerable<VeiculoDto> MapearParaListaDto(IEnumerable<Veiculo> veiculos);
    Veiculo MapearParaEntidade(CreateVeiculoDto createDto);
}
