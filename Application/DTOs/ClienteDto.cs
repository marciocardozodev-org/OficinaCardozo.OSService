namespace OficinaCardozo.OSService.Application.DTOs;

public class ClienteDto
{
	public int Id { get; set; }
	public string Nome { get; set; } = string.Empty;
	public string CpfCnpj { get; set; } = string.Empty;
	public string TelefonePrincipal { get; set; } = string.Empty;
	public string EmailPrincipal { get; set; } = string.Empty;
	public string EnderecoPrincipal { get; set; } = string.Empty;
}
