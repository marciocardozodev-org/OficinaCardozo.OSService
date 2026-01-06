using OficinaCardozo.Application.DTOs;
using OficinaCardozo.Domain.Entities;

namespace OficinaCardozo.Application.Interfaces;

public interface IClienteMapper
{
    ClienteDto MapearParaDto(Cliente cliente);
    IEnumerable<ClienteDto> MapearParaListaDto(IEnumerable<Cliente> clientes);
    Cliente MapearParaEntidade(CreateClienteDto createDto);
    void AtualizarEntidadeComDto(Cliente cliente, UpdateClienteDto updateDto);
}