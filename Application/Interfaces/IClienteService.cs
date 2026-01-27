using OficinaCardozo.OSService.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OficinaCardozo.OSService.Application.Interfaces;

public interface IClienteService
{
    Task<ClienteDto> CriarClienteAsync(CreateClienteDto createDto);
    Task<IEnumerable<ClienteDto>> ObterTodosAsync();
}
