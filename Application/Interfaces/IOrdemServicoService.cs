using OficinaCardozo.OSService.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OficinaCardozo.OSService.Application.Interfaces;

public interface IOrdemServicoService
{
    Task<OrdemServicoDto> CriarOrdemServicoAsync(CreateOrdemServicoDto createDto);
    Task<IEnumerable<OrdemServicoDto>> ObterTodosAsync();
}
