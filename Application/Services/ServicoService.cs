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

public class ServicoService : IServicoService
{
	private readonly IServicoMapper _mapper;
	public ServicoService(IServicoMapper mapper)
	{
		_mapper = mapper;
	}

	public async Task<ServicoDto> CriarServicoAsync(CreateServicoDto createDto)
	{
		var servico = _mapper.MapearParaEntidade(createDto);
		// ...persistência e lógica de negócio...
		return _mapper.MapearParaDto(servico);
	}

	public async Task<IEnumerable<ServicoDto>> ObterTodosAsync()
	{
		// ...busca e mapeamento...
		return new List<ServicoDto>();
	}
	// ...outros métodos do contrato...
}
