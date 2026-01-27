namespace OficinaCardozo.OSService.Application.DTOs;

/// <summary>
/// DTO para representar a relação entre Ordem de Serviço e Serviços
/// </summary>
public class OrdemServicoServicoDto
{
    public int IdServico { get; set; }
    public string? NomeServico { get; set; }
    public decimal? ValorAplicado { get; set; }
    public decimal? PrecoOriginal { get; set; }
    public int? TempoEstimado { get; set; }
    public string? DescricaoDetalhada { get; set; }
}
