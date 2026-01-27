using Microsoft.EntityFrameworkCore;
using OficinaCardozo.OSService.Domain;
using OficinaCardozo.OSService.Domain.Interfaces.Repositories;
using OficinaCardozo.OSService.Infrastructure.Data;
using System.Globalization;
using System.Text;

namespace OficinaCardozo.OSService.Infrastructure.Repositories;

public class OrdemServicoStatusRepository : IOrdemServicoStatusRepository
{
    private readonly OficinaDbContext _context;

    public OrdemServicoStatusRepository(OficinaDbContext context)
    {
        _context = context;
    }

    public async Task<OrdemServicoStatus?> GetByDescricaoAsync(string descricao)
    {
        try
        {
            _context.ChangeTracker.Clear();

            var todosStatus = await _context.OrdensServicoStatus
                .AsNoTracking()
                .ToListAsync();
            var result = todosStatus.FirstOrDefault(s => s.Descricao == descricao);

            return result;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<IEnumerable<OrdemServicoStatus>> GetAllAsync()
    {
        return await _context.OrdensServicoStatus
            .AsNoTracking()
            .OrderBy(s => s.Id)
            .ToListAsync();
    }
}