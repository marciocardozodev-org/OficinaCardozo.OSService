using OficinaCardozo.Application.DTOs;

namespace OficinaCardozo.Application.Interfaces;

public interface IVeiculoService
{
    Task<IEnumerable<VeiculoDto>> ObterTodosVeiculosAsync();
    Task<VeiculoDto?> ObterVeiculoPorIdAsync(int id);
    Task<IEnumerable<VeiculoDto>> ObterVeiculosPorClienteAsync(int clienteId);
    Task<VeiculoDto> CriarVeiculoAsync(CreateVeiculoDto createDto);
    Task<VeiculoDto> AtualizarVeiculoAsync(int id, UpdateVeiculoDto updateDto);
    Task<bool> RemoverVeiculoAsync(int id);
    Task<VeiculoDto?> ObterVeiculoPorPlacaAsync(string placa);

    Task<IEnumerable<VeiculoDto>> GetAllAsync();
    Task<VeiculoDto?> GetByIdAsync(int id);
    Task<IEnumerable<VeiculoDto>> GetByClienteIdAsync(int clienteId);
    Task<VeiculoDto> CreateAsync(CreateVeiculoDto createDto);
    Task<VeiculoDto> UpdateAsync(int id, UpdateVeiculoDto updateDto);
    Task<bool> DeleteAsync(int id);
    Task<VeiculoDto?> GetByPlacaAsync(string placa);
}