namespace OficinaCardozo.OSService.Application.DTOs;

/// <summary>
/// DTO para representar a relação entre Ordem de Serviço e Peças
/// </summary>
public class OrdemServicoPecaDto
{
    public int IdPeca { get; set; }
    public string? NomePeca { get; set; }
    public string? CodigoIdentificador { get; set; }
    public int Quantidade { get; set; }
    public decimal? ValorUnitario { get; set; }
    public decimal? PrecoOriginal { get; set; }
    public decimal? ValorTotal => ValorUnitario * Quantidade;
    public string? UnidadeMedida { get; set; }
}
