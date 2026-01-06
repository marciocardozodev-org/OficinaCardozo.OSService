using System.ComponentModel.DataAnnotations;

namespace OficinaCardozo.Application.DTOs;

/// <summary>
/// DTO para atualização de dados do veículo
/// </summary>
public class UpdateVeiculoDto
{
    /// <summary>
    /// ID do cliente proprietário (opcional)
    /// </summary>
    [Range(1, int.MaxValue, ErrorMessage = "ID do cliente deve ser maior que zero")]
    public int? IdCliente { get; set; }

    /// <summary>
    /// Placa do veículo (opcional)
    /// </summary>
    [StringLength(8, ErrorMessage = "Placa deve ter no máximo 8 caracteres")]
    public string? Placa { get; set; }

    /// <summary>
    /// Marca e modelo do veículo (opcional)
    /// </summary>
    [StringLength(100, ErrorMessage = "Marca/modelo deve ter no máximo 100 caracteres")]
    public string? MarcaModelo { get; set; }

    /// <summary>
    /// Ano de fabricação do veículo (opcional)
    /// </summary>
    [Range(1900, 2030, ErrorMessage = "Ano deve estar entre 1900 e 2030")]
    public int? AnoFabricacao { get; set; }

    /// <summary>
    /// Cor do veículo (opcional)
    /// </summary>
    [StringLength(30, ErrorMessage = "Cor deve ter no máximo 30 caracteres")]
    public string? Cor { get; set; }

    /// <summary>
    /// Tipo de combustível (opcional)
    /// </summary>
    [StringLength(20, ErrorMessage = "Tipo de combustível deve ter no máximo 20 caracteres")]
    public string? TipoCombustivel { get; set; }
}