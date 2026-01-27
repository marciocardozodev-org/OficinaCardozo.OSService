using OficinaCardozo.OSService.Domain.Entities;

namespace OficinaCardozo.OSService.Domain.Interfaces.Repositories;

public interface IOrdemServicoStatusRepository
{
    Task<OrdemServicoStatus?> GetByDescricaoAsync(string descricao);
    Task<IEnumerable<OrdemServicoStatus>> GetAllAsync();
}
