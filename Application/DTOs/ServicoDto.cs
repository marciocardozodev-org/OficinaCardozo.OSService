using System.ComponentModel.DataAnnotations;

namespace OficinaCardozo.OSService.Application.DTOs;

public class ServicoDto
{
    public int Id { get; set; }
    public string NomeServico { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int TempoEstimadoExecucao { get; set; }
    public string DescricaoDetalhadaServico { get; set; } = string.Empty;
    public string? FrequenciaRecomendada { get; set; }
    public string PrecoFormatado => Preco.ToString("C2");
}
