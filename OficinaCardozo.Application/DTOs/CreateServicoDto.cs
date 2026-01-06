using System.ComponentModel.DataAnnotations;

namespace OficinaCardozo.Application.DTOs;

/// <summary>
/// DTO para criação de novo serviço
/// </summary>
public class CreateServicoDto
{
    /// <summary>
    /// Nome do serviço
    /// </summary>
    [Required(ErrorMessage = "Nome do serviço é obrigatório")]
    [StringLength(100, ErrorMessage = "Nome do serviço deve ter no máximo 100 caracteres")]
    public string NomeServico { get; set; } = string.Empty;

    /// <summary>
    /// Preço do serviço
    /// </summary>
    [Required(ErrorMessage = "Preço é obrigatório")]
    [Range(0.01, 999999.99, ErrorMessage = "Preço deve estar entre R$ 0,01 e R$ 999.999,99")]
    public decimal Preco { get; set; }

    /// <summary>
    /// Tempo estimado de execução em horas
    /// </summary>
    [Required(ErrorMessage = "Tempo estimado é obrigatório")]
    [Range(1, 720, ErrorMessage = "Tempo estimado deve estar entre 1 e 720 horas")]
    public int TempoEstimadoExecucao { get; set; }

    /// <summary>
    /// Descrição detalhada do serviço
    /// </summary>
    [StringLength(500, ErrorMessage = "Descrição deve ter no máximo 500 caracteres")]
    public string? DescricaoDetalhadaServico { get; set; }

    /// <summary>
    /// Frequência recomendada para o serviço
    /// </summary>
    [StringLength(100, ErrorMessage = "Frequência recomendada deve ter no máximo 100 caracteres")]
    public string? FrequenciaRecomendada { get; set; }
}