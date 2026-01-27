using System.ComponentModel.DataAnnotations;

namespace OficinaCardozo.OSService.Application.DTOs;

public class VeiculoDto
{
    public int Id { get; set; }
    public int IdCliente { get; set; }
    public string? NomeCliente { get; set; }
    public string Placa { get; set; } = string.Empty;
    public string MarcaModelo { get; set; } = string.Empty;
    public int AnoFabricacao { get; set; }
    public string Cor { get; set; } = string.Empty;
    public string TipoCombustivel { get; set; } = string.Empty;
}
