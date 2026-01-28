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
		var cliente = _mapper.MapearParaEntidade(createDto);
		return _mapper.MapearParaDto(cliente);
	}

	public async Task<IEnumerable<ClienteDto>> ObterTodosAsync()
	{
		return new List<ClienteDto>();
	}

	public async Task<IEnumerable<ClienteDto>> ObterTodosClientesAsync()
	{
		return new List<ClienteDto>();
	}
}
