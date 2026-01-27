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

public class ClienteService : IClienteService
{
	private readonly IClienteMapper _mapper;
	public ClienteService(IClienteMapper mapper)
	{
		_mapper = mapper;
	}

	public async Task<ClienteDto> CriarClienteAsync(CreateClienteDto createDto)
	{
		// Exemplo de uso do ValueObject e Exception
		var cliente = _mapper.MapearParaEntidade(createDto);
		// ...persistência e lógica de negócio...
		return _mapper.MapearParaDto(cliente);
	}

	public async Task<IEnumerable<ClienteDto>> ObterTodosAsync()
	{
		// ...busca e mapeamento...
		return new List<ClienteDto>();
	}
	// ...outros métodos do contrato...
}
