namespace OficinaCardozo.OSService.Application.DTOs;

public class CreateVeiculoDto
{
	public int IdCliente { get; set; }
	public string Placa { get; set; } = string.Empty;
	public string MarcaModelo { get; set; } = string.Empty;
	public int AnoFabricacao { get; set; }
	public string Cor { get; set; } = string.Empty;
	public string TipoCombustivel { get; set; } = string.Empty;
}
