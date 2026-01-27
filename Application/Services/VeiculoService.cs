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

public class VeiculoService : IVeiculoService
{
	private readonly IVeiculoMapper _mapper;
	public VeiculoService(IVeiculoMapper mapper)
	{
		_mapper = mapper;
	}

	public async Task<VeiculoDto> CriarVeiculoAsync(CreateVeiculoDto createDto)
	{
		var veiculo = _mapper.MapearParaEntidade(createDto);
		// ...persistência e lógica de negócio...
		return _mapper.MapearParaDto(veiculo);
	}

	public async Task<IEnumerable<VeiculoDto>> ObterTodosAsync()
	{
		// ...busca e mapeamento...
		return new List<VeiculoDto>();
	}
	// ...outros métodos do contrato...
}
