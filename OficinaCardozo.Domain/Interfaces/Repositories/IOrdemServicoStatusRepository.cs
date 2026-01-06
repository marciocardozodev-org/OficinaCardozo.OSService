using OficinaCardozo.Domain.Entities;

namespace OficinaCardozo.Domain.Interfaces;

public interface IOrdemServicoStatusRepository
{
    Task<OrdemServicoStatus?> GetByDescricaoAsync(string descricao);
    Task<IEnumerable<OrdemServicoStatus>> GetAllAsync();
}