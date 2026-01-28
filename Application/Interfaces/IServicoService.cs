using OficinaCardozo.OSService.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OficinaCardozo.OSService.Application.Interfaces;

public interface IServicoService
{
    Task<ServicoDto> CriarServicoAsync(CreateServicoDto createDto);
    Task<IEnumerable<ServicoDto>> ObterTodosAsync();
    Task<IEnumerable<ServicoDto>> GetAllAsync();
    Task<ServicoDto> CreateAsync(CreateServicoDto createDto);
    // Adicione outros métodos conforme necessário
}
