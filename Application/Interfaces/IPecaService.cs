using OficinaCardozo.OSService.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OficinaCardozo.OSService.Application.Interfaces
{
    public interface IPecaService
    {
        Task<IEnumerable<PecaDto>> GetAllAsync();
        Task<PecaDto?> GetByIdAsync(int id);
        Task<IEnumerable<PecaDto>> GetEstoqueBaixoAsync();
        Task<PecaDto> CreateAsync(CreatePecaDto createDto);
        Task<PecaDto> UpdateAsync(int id, UpdatePecaDto updateDto);
        Task<bool> DeleteAsync(int id);
        Task<bool> MovimentarEstoqueAsync(int id, MovimentacaoEstoqueDto movimentacaoDto);
    }
}
