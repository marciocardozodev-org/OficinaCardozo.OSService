using OficinaCardozo.OSService.Application.DTOs;
using OficinaCardozo.OSService.Domain.Entities;
using System.Collections.Generic;

namespace OficinaCardozo.OSService.Application.Interfaces;

public interface IClienteMapper
{
    ClienteDto MapearParaDto(Cliente cliente);
    IEnumerable<ClienteDto> MapearParaListaDto(IEnumerable<Cliente> clientes);
    Cliente MapearParaEntidade(CreateClienteDto createDto);
}
