using OficinaCardozo.Application.DTOs;
using OficinaCardozo.Application.Interfaces;
using OficinaCardozo.Domain.Entities;

namespace OficinaCardozo.Application.Mappers;

public class VeiculoMapper : IVeiculoMapper
{
    public VeiculoDto MapearParaDto(Veiculo veiculo)
    {
        ArgumentNullException.ThrowIfNull(veiculo);

        return new VeiculoDto
        {
            Id = veiculo.Id,
            IdCliente = veiculo.IdCliente,
            NomeCliente = veiculo.Cliente?.Nome,
            Placa = veiculo.Placa,
            MarcaModelo = veiculo.MarcaModelo,
            AnoFabricacao = veiculo.AnoFabricacao,
            Cor = veiculo.Cor,
            TipoCombustivel = veiculo.TipoCombustivel
        };
    }

    public IEnumerable<VeiculoDto> MapearParaListaDto(IEnumerable<Veiculo> veiculos)
    {
        ArgumentNullException.ThrowIfNull(veiculos);
        return veiculos.Select(MapearParaDto);
    }

    public Veiculo MapearParaEntidade(CreateVeiculoDto createDto)
    {
        ArgumentNullException.ThrowIfNull(createDto);

        return new Veiculo
        {
            IdCliente = createDto.IdCliente,
            Placa = createDto.Placa.Trim().ToUpperInvariant(),
            MarcaModelo = createDto.MarcaModelo.Trim(),
            AnoFabricacao = createDto.AnoFabricacao,
            Cor = createDto.Cor?.Trim() ?? string.Empty,
            TipoCombustivel = createDto.TipoCombustivel.Trim()
        };
    }

    public void AtualizarEntidadeComDto(Veiculo veiculo, UpdateVeiculoDto updateDto)
    {
        ArgumentNullException.ThrowIfNull(veiculo);
        ArgumentNullException.ThrowIfNull(updateDto);

        if (updateDto.IdCliente.HasValue)
            veiculo.IdCliente = updateDto.IdCliente.Value;

        if (!string.IsNullOrWhiteSpace(updateDto.Placa))
            veiculo.Placa = updateDto.Placa.Trim().ToUpperInvariant();

        if (!string.IsNullOrWhiteSpace(updateDto.MarcaModelo))
            veiculo.MarcaModelo = updateDto.MarcaModelo.Trim();

        if (updateDto.AnoFabricacao.HasValue)
            veiculo.AnoFabricacao = updateDto.AnoFabricacao.Value;

        if (!string.IsNullOrWhiteSpace(updateDto.Cor))
            veiculo.Cor = updateDto.Cor.Trim();

        if (!string.IsNullOrWhiteSpace(updateDto.TipoCombustivel))
            veiculo.TipoCombustivel = updateDto.TipoCombustivel.Trim();
    }
}