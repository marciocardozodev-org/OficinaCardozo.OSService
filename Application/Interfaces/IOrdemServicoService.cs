using OficinaCardozo.OSService.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OficinaCardozo.OSService.Application.Interfaces;

public interface IOrdemServicoService
{
    Task<OrdemServicoDto> CriarOrdemServicoAsync(CreateOrdemServicoDto createDto);
    Task<IEnumerable<OrdemServicoDto>> ObterTodosAsync();
    Task<IEnumerable<OrdemServicoDto>> GetAllAtivasAsync();
    Task<IEnumerable<OrdemServicoDto>> GetAllAsync();
    Task<OrdemServicoDto> CreateOrdemServicoComOrcamentoAsync(CreateOrdemServicoDto createDto);
    Task<OrdemServicoDto> GetByIdAsync(int id);
    Task<IEnumerable<OrcamentoDto>> GetAllOrcamentosAsync();
    Task<OrcamentoResumoDto> IniciarDiagnosticoAsync(int id);
    Task<OrcamentoResumoDto> EnviarOrcamentoParaAprovacaoAsync(EnviarOrcamentoParaAprovacaoDto dto);
    Task<OrcamentoResumoDto> FinalizarDiagnosticoAsync(int id);
    Task<OrcamentoResumoDto> AprovarOrcamentoAsync(AprovarOrcamentoDto dto);
    Task<OrdemServicoDto> IniciarExecucaoAsync(int id);
    Task<OrdemServicoDto> FinalizarServicoAsync(int id);
    Task<OrdemServicoDto> EntregarVeiculoAsync(int id);
    Task<OrdemServicoDto> CancelarOrdemServicoAsync(CancelarOrdemServicoDto dto);
    Task<OrdemServicoDto> DevolverVeiculoSemServicoAsync(int id, string motivo);
    Task<TempoMedioExecucaoDto> ObterTempoMedioExecucaoAsync(FiltroTempoMedioDto? filtro = null);
    Task<ResumoTempoExecucaoDto> ObterResumoTempoExecucaoAsync();
}
