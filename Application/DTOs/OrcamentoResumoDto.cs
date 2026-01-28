namespace OficinaCardozo.OSService.Application.DTOs;

public class OrcamentoResumoDto
{
	public int Id { get; set; }
	public DateTime DataOrcamento { get; set; }
	public string StatusDescricao { get; set; } = string.Empty;
	public string ClienteNome { get; set; } = string.Empty;
	public string ClienteEmail { get; set; } = string.Empty;
	public string VeiculoPlaca { get; set; } = string.Empty;
	public string VeiculoMarcaModelo { get; set; } = string.Empty;
	public decimal ValorTotal { get; set; }
	public string MensagemAprovacao { get; set; } = string.Empty;
	public string ValorFormatado => ValorTotal.ToString("C2");
	public string DataFormatada => DataOrcamento.ToString("dd/MM/yyyy HH:mm");
}
