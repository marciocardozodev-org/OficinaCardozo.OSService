namespace OficinaCardozo.OSService.Application.DTOs;

public class ServicoSelecaoDto
{
    public int Id { get; set; }
    public string NomeServico { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int TempoEstimadoExecucao { get; set; }
    public string DescricaoDetalhadaServico { get; set; } = string.Empty;
}
