namespace OficinaCardozo.Application.DTOs;

/// <summary>
/// DTO simplificado para seleçÍo de serviços em ordens de serviço
/// </summary>
public class ServicoSelecaoDto
{
    /// <summary>
    /// ID do serviço
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Nome do serviço
    /// </summary>
    public string NomeServico { get; set; } = string.Empty;

    /// <summary>
    /// Preço do serviço
    /// </summary>
    public decimal Preco { get; set; }

    /// <summary>
    /// Tempo estimado de execução em horas
    /// </summary>
    public int TempoEstimadoExecucao { get; set; }

    /// <summary>
    /// Descrição detalhada do serviço
    /// </summary>
    public string DescricaoDetalhadaServico { get; set; } = string.Empty;
}