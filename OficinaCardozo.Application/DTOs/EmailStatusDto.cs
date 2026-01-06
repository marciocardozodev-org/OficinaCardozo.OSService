using System.ComponentModel.DataAnnotations;

namespace OficinaCardozo.Application.DTOs;

public class EmailStatusDto
{
    public string Remetente { get; set; } = string.Empty;
    public string Assunto { get; set; } = string.Empty;
    public string Corpo { get; set; } = string.Empty;
    public DateTime DataRecebimento { get; set; }
    public int? OrdemServicoId { get; set; }
    public string? NovoStatus { get; set; }
    public bool ProcessadoComSucesso { get; set; }
    public string? MensagemErro { get; set; }
}

public class ComandoEmailDto
{
    [Required]
    public int OrdemServicoId { get; set; }

    [Required]
    public string NovoStatus { get; set; } = string.Empty;

    public string? Observacoes { get; set; }
    public string? RemetenteEmail { get; set; }
}