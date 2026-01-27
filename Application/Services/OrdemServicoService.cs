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
	// Exemplo de dependências
	public OrdemServicoService() {}

	public async Task<OrdemServicoDto> CriarOrdemServicoAsync(CreateOrdemServicoDto createDto)
	{
		// ...persistência e lógica de negócio...
		return new OrdemServicoDto();
	}

	public async Task<IEnumerable<OrdemServicoDto>> ObterTodosAsync()
	{
		// ...busca e mapeamento...
		return new List<OrdemServicoDto>();
	}
	// ...outros métodos do contrato...
}
