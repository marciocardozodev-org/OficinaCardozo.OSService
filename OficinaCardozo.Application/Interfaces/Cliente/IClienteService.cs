using OficinaCardozo.Application.DTOs;

namespace OficinaCardozo.Application.Interfaces;

public interface IClienteService
{
    Task<IEnumerable<ClienteDto>> ObterTodosClientesAsync();
    Task<ClienteDto?> ObterClientePorIdAsync(int id);
    Task<ClienteDto> CriarClienteAsync(CreateClienteDto createDto);
    Task<ClienteDto> AtualizarClienteAsync(int id, UpdateClienteDto updateDto);
    Task<bool> RemoverClienteAsync(int id);
}