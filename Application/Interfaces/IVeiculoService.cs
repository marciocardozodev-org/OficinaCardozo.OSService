using OficinaCardozo.OSService.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OficinaCardozo.OSService.Application.Interfaces;

public interface IVeiculoService
{
    Task<VeiculoDto> CriarVeiculoAsync(CreateVeiculoDto createDto);
    Task<IEnumerable<VeiculoDto>> ObterTodosAsync();
}
