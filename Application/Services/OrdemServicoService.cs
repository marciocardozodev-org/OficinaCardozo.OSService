using OficinaCardozo.OSService.Application.DTOs;
using OficinaCardozo.OSService.Application.Interfaces;
using OficinaCardozo.OSService.Application.Mappers;
using OficinaCardozo.OSService.Domain.Entities;
using OficinaCardozo.Domain.ValueObjects;
using OficinaCardozo.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OficinaCardozo.OSService.Application.Services;

public class OrdemServicoService : IOrdemServicoService
{
    public OrdemServicoService() {}

    public async Task<OrdemServicoDto> CriarOrdemServicoAsync(CreateOrdemServicoDto createDto) => new();
    public async Task<IEnumerable<OrdemServicoDto>> ObterTodosAsync() => new List<OrdemServicoDto>();
    public async Task<IEnumerable<OrdemServicoDto>> GetAllAtivasAsync() => new List<OrdemServicoDto>();
    public async Task<IEnumerable<OrdemServicoDto>> GetAllAsync() => new List<OrdemServicoDto>();
    public async Task<OrdemServicoDto> CreateOrdemServicoComOrcamentoAsync(CreateOrdemServicoDto createDto) => new();
    public async Task<OrdemServicoDto> GetByIdAsync(int id) => new();

    public async Task<IEnumerable<OrcamentoDto>> GetAllOrcamentosAsync() => new List<OrcamentoDto>();
    public async Task<OrcamentoResumoDto> IniciarDiagnosticoAsync(int id) => new();
    public async Task<OrcamentoResumoDto> EnviarOrcamentoParaAprovacaoAsync(EnviarOrcamentoParaAprovacaoDto dto) => new();
    public async Task<OrcamentoResumoDto> FinalizarDiagnosticoAsync(int id) => new();
    public async Task<OrcamentoResumoDto> AprovarOrcamentoAsync(AprovarOrcamentoDto dto) => new();
    public async Task<OrdemServicoDto> IniciarExecucaoAsync(int id) => new();
    public async Task<OrdemServicoDto> FinalizarServicoAsync(int id) => new();
    public async Task<OrdemServicoDto> EntregarVeiculoAsync(int id) => new();
    public async Task<OrdemServicoDto> CancelarOrdemServicoAsync(CancelarOrdemServicoDto dto) => new();
    public async Task<OrdemServicoDto> DevolverVeiculoSemServicoAsync(int id, string motivo) => new();
    public async Task<TempoMedioExecucaoDto> ObterTempoMedioExecucaoAsync(FiltroTempoMedioDto? filtro = null) => new();
    public async Task<ResumoTempoExecucaoDto> ObterResumoTempoExecucaoAsync() => new();
}
