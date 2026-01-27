namespace OficinaCardozo.OSService.Application.DTOs;

public class CreateServicoDto
{
	public string NomeServico { get; set; } = string.Empty;
	public decimal Preco { get; set; }
	public int TempoEstimadoExecucao { get; set; }
	public string DescricaoDetalhadaServico { get; set; } = string.Empty;
	public string FrequenciaRecomendada { get; set; } = string.Empty;
}
