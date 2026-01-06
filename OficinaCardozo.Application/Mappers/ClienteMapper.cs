using OficinaCardozo.Application.DTOs;
using OficinaCardozo.Application.Interfaces;
using OficinaCardozo.Domain.Entities;

namespace OficinaCardozo.Application.Mappers;

public class ClienteMapper : IClienteMapper
{
    public ClienteDto MapearParaDto(Cliente cliente)
    {
        ArgumentNullException.ThrowIfNull(cliente);

        return new ClienteDto
        {
            Id = cliente.Id,
            Nome = cliente.Nome,
            CpfCnpj = cliente.CpfCnpj,
            TelefonePrincipal = cliente.TelefonePrincipal,
            EmailPrincipal = cliente.EmailPrincipal,
            EnderecoPrincipal = cliente.EnderecoPrincipal
        };
    }

    public IEnumerable<ClienteDto> MapearParaListaDto(IEnumerable<Cliente> clientes)
    {
        ArgumentNullException.ThrowIfNull(clientes);
        return clientes.Select(MapearParaDto);
    }

    public Cliente MapearParaEntidade(CreateClienteDto createDto)
    {
        ArgumentNullException.ThrowIfNull(createDto);

        return new Cliente
        {
            Nome = createDto.Nome.Trim(),
            CpfCnpj = createDto.CpfCnpj.Trim(),
            TelefonePrincipal = createDto.TelefonePrincipal?.Trim() ?? string.Empty,
            EmailPrincipal = createDto.EmailPrincipal?.Trim() ?? string.Empty,
            EnderecoPrincipal = createDto.EnderecoPrincipal?.Trim() ?? string.Empty
        };
    }

    public void AtualizarEntidadeComDto(Cliente cliente, UpdateClienteDto updateDto)
    {
        ArgumentNullException.ThrowIfNull(cliente);
        ArgumentNullException.ThrowIfNull(updateDto);

        if (!string.IsNullOrWhiteSpace(updateDto.Nome))
            cliente.Nome = updateDto.Nome.Trim();

        if (!string.IsNullOrWhiteSpace(updateDto.CpfCnpj))
            cliente.CpfCnpj = updateDto.CpfCnpj.Trim();

        if (!string.IsNullOrWhiteSpace(updateDto.TelefonePrincipal))
            cliente.TelefonePrincipal = updateDto.TelefonePrincipal.Trim();

        if (!string.IsNullOrWhiteSpace(updateDto.EmailPrincipal))
            cliente.EmailPrincipal = updateDto.EmailPrincipal.Trim();

        if (!string.IsNullOrWhiteSpace(updateDto.EnderecoPrincipal))
            cliente.EnderecoPrincipal = updateDto.EnderecoPrincipal.Trim();
    }
}