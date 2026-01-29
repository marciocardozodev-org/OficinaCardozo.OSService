namespace OficinaCardozo.OSService.Application.DTOs;

public class CreateOrdemServicoDto
{
	public string ClienteCpfCnpj { get; set; } = string.Empty;
	public string VeiculoPlaca { get; set; } = string.Empty;
	public string VeiculoMarcaModelo { get; set; } = string.Empty;
	public int VeiculoAnoFabricacao { get; set; }
	public string VeiculoCor { get; set; } = string.Empty;
	public string VeiculoTipoCombustivel { get; set; } = string.Empty;
	public List<int> ServicosIds { get; set; } = new();
	public List<CreateOrdemServicoPecaDto> Pecas { get; set; } = new();
}
