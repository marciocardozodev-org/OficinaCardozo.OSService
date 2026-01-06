using System.ComponentModel.DataAnnotations;

namespace OficinaCardozo.Application.DTOs;

/// <summary>
/// DTO para exibição de dados do veículo
/// </summary>
public class VeiculoDto
{
    /// <summary>
    /// ID do veículo
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// ID do cliente proprietário
    /// </summary>
    public int IdCliente { get; set; }

    /// <summary>
    /// Nome do cliente proprietário
    /// </summary>
    public string? NomeCliente { get; set; }

    /// <summary>
    /// Placa do veículo
    /// </summary>
    public string Placa { get; set; } = string.Empty;

    /// <summary>
    /// Marca e modelo do veículo
    /// </summary>
    public string MarcaModelo { get; set; } = string.Empty;

    /// <summary>
    /// Ano de fabricação do veículo
    /// </summary>
    public int AnoFabricacao { get; set; }

    /// <summary>
    /// Cor do veículo
    /// </summary>
    public string Cor { get; set; } = string.Empty;

    /// <summary>
    /// Tipo de combustível (Gasolina, Álcool, Flex, Diesel, GNV)
    /// </summary>
    public string TipoCombustivel { get; set; } = string.Empty;
}