namespace OficinaCardozo.Application.DTOs;

/// <summary>
/// DTO para representar a relaçÍo entre Ordem de Serviço e Serviços
/// </summary>
public class OrdemServicoServicoDto
{
    /// <summary>
    /// ID do serviço
    /// </summary>
    public int IdServico { get; set; }

    /// <summary>
    /// Nome do serviço
    /// </summary>
    public string? NomeServico { get; set; }

    /// <summary>
    /// Valor aplicado para este serviço na ordem (pode diferir do preço original)
    /// </summary>
    public decimal? ValorAplicado { get; set; }

    /// <summary>
    /// Preço original cadastrado do serviço (para comparaçÍo)
    /// </summary>
    public decimal? PrecoOriginal { get; set; }

    /// <summary>
    /// Tempo estimado de execução em horas
    /// </summary>
    public int? TempoEstimado { get; set; }

    /// <summary>
    /// Descrição detalhada do serviço
    /// </summary>
    public string? DescricaoDetalhada { get; set; }
}