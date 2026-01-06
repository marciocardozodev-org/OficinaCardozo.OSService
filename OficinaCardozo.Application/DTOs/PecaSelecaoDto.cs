namespace OficinaCardozo.Application.DTOs;

/// <summary>
/// DTO simplificado para seleçÍo de peças em ordens de serviço
/// </summary>
public class PecaSelecaoDto
{
    /// <summary>
    /// ID da peça
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Nome da peça
    /// </summary>
    public string NomePeca { get; set; } = string.Empty;

    /// <summary>
    /// Código identificador da peça
    /// </summary>
    public string CodigoIdentificador { get; set; } = string.Empty;

    /// <summary>
    /// Preço unitário da peça
    /// </summary>
    public decimal Preco { get; set; }

    /// <summary>
    /// Quantidade disponÍ­vel em estoque
    /// </summary>
    public int QuantidadeEstoque { get; set; }

    /// <summary>
    /// Unidade de medida
    /// </summary>
    public string UnidadeMedida { get; set; } = string.Empty;

    /// <summary>
    /// Indica se o estoque está baixo
    /// </summary>
    public bool EstoqueBaixo { get; set; }

    /// <summary>
    /// Status do estoque para exibição
    /// </summary>
    public string StatusEstoque => EstoqueBaixo ? "Estoque Baixo" :
                                   QuantidadeEstoque == 0 ? "Sem Estoque" :
                                   "DisponÍ­vel";
}