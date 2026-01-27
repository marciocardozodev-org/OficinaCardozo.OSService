namespace OficinaCardozo.OSService.Application.DTOs;

public class ComandoEmailDto
{
    public int OrdemServicoId { get; set; }
    public string NovoStatus { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Assunto { get; set; } = string.Empty;
    public string Mensagem { get; set; } = string.Empty;
}
