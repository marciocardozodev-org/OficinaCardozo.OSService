using System.ComponentModel.DataAnnotations;

namespace OficinaCardozo.Application.DTOs;

/// <summary>
/// DTO para criação de novo veículo
/// </summary>
public class CreateVeiculoDto
{
    /// <summary>
    /// ID do cliente proprietário
    /// </summary>
    [Required(ErrorMessage = "ID do cliente é obrigatório")]
    [Range(1, int.MaxValue, ErrorMessage = "ID do cliente deve ser maior que zero")]
    public int IdCliente { get; set; }

    /// <summary>
    /// Placa do veículo
    /// </summary>
    [Required(ErrorMessage = "Placa do veículo é obrigatória")]
    [StringLength(8, ErrorMessage = "Placa deve ter no máximo 8 caracteres")]
    public string Placa { get; set; } = string.Empty;

    /// <summary>
    /// Marca e modelo do veículo
    /// </summary>
    [Required(ErrorMessage = "Marca/modelo do veículo é obrigatório")]
    [StringLength(100, ErrorMessage = "Marca/modelo deve ter no máximo 100 caracteres")]
    public string MarcaModelo { get; set; } = string.Empty;

    /// <summary>
    /// Ano de fabricação do veículo
    /// </summary>
    [Range(1900, 2030, ErrorMessage = "Ano deve estar entre 1900 e 2030")]
    public int AnoFabricacao { get; set; }

    /// <summary>
    /// Cor do veículo
    /// </summary>
    [StringLength(30, ErrorMessage = "Cor deve ter no máximo 30 caracteres")]
    public string? Cor { get; set; }

    /// <summary>
    /// Tipo de combustível
    /// </summary>
    [Required(ErrorMessage = "Tipo de combustível é obrigatório")]
    [StringLength(20, ErrorMessage = "Tipo de combustível deve ter no máximo 20 caracteres")]
    public string TipoCombustivel { get; set; } = string.Empty;
}