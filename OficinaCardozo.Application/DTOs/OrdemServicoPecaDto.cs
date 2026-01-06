namespace OficinaCardozo.Application.DTOs;

/// <summary>
/// DTO para representar a relaçÍo entre Ordem de Serviço e Peças
/// </summary>
public class OrdemServicoPecaDto
{
    /// <summary>
    /// ID da peça
    /// </summary>
    public int IdPeca { get; set; }

    /// <summary>
    /// Nome da peça
    /// </summary>
    public string? NomePeca { get; set; }

    /// <summary>
    /// Código identificador da peça
    /// </summary>
    public string? CodigoIdentificador { get; set; }

    /// <summary>
    /// Quantidade utilizada na ordem de serviço
    /// </summary>
    public int Quantidade { get; set; }

    /// <summary>
    /// Valor unitário aplicado para esta peça na ordem (pode diferir do preço original)
    /// </summary>
    public decimal? ValorUnitario { get; set; }

    /// <summary>
    /// Preço original cadastrado da peça (para comparaçÍo)
    /// </summary>
    public decimal? PrecoOriginal { get; set; }

    /// <summary>
    /// Valor total da peça (ValorUnitario * Quantidade)
    /// </summary>
    public decimal? ValorTotal => ValorUnitario * Quantidade;

    /// <summary>
    /// Unidade de medida da peça
    /// </summary>
    public string? UnidadeMedida { get; set; }
}