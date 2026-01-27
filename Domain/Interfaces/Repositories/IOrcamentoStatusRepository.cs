using OficinaCardozo.OSService.Domain.Entities;

namespace OficinaCardozo.OSService.Domain.Interfaces.Repositories;

public interface IOrcamentoStatusRepository
{
    Task<OrcamentoStatus?> GetByDescricaoAsync(string descricao);
    Task<IEnumerable<OrcamentoStatus>> GetAllAsync();
}
