namespace OficinaCardozo.Application.Settings;

public class ConfiguracoesEmail
{
    public string Host { get; set; } = string.Empty;
    public int PortaImap { get; set; } = 993;
    public int PortaSmtp { get; set; } = 587;
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public bool UsarSsl { get; set; } = true;
    public int IntervaloVerificacaoMinutos { get; set; } = 1;
}