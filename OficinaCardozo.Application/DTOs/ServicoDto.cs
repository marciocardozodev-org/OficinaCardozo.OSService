using System.ComponentModel.DataAnnotations;

namespace OficinaCardozo.Application.DTOs;

/// <summary>
/// DTO para exibição de dados do serviço
/// </summary>
public class ServicoDto
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

    /// <summary>
    /// Frequência recomendada para o serviço
    /// </summary>
    public string? FrequenciaRecomendada { get; set; }

    /// <summary>
    /// Preço formatado para exibição
    /// </summary>
    public string PrecoFormatado => Preco.ToString("C2");
}