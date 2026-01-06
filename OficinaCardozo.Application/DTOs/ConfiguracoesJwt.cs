namespace OficinaCardozo.Application.Settings;


public class ConfiguracoesJwt
{    
    public string ChaveSecreta { get; set; } = string.Empty;

    public int ExpiracaoEmMinutos { get; set; } = 60;
}