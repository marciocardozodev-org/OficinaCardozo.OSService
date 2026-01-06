using OficinaCardozo.Application.DTOs;

namespace OficinaCardozo.Application.Interfaces;

public interface IServicoService
{
    // Métodos em português (Clean Architecture)
    Task<IEnumerable<ServicoDto>> ObterTodosServicosAsync();
    Task<ServicoDto?> ObterServicoPorIdAsync(int id);
    Task<ServicoDto> CriarServicoAsync(CreateServicoDto createDto);
    Task<ServicoDto> AtualizarServicoAsync(int id, UpdateServicoDto updateDto);
    Task<bool> RemoverServicoAsync(int id);
    Task<IEnumerable<ServicoDto>> BuscarServicosPorNomeAsync(string nome);

    // Métodos em inglês (compatibilidade com controllers existentes)
    Task<IEnumerable<ServicoDto>> GetAllAsync();
    Task<ServicoDto?> GetByIdAsync(int id);
    Task<ServicoDto> CreateAsync(CreateServicoDto createDto);
    Task<ServicoDto> UpdateAsync(int id, UpdateServicoDto updateDto);
    Task<bool> DeleteAsync(int id);
}