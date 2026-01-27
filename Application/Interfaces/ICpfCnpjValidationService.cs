namespace OficinaCardozo.OSService.Application.Interfaces;

public interface ICpfCnpjValidationService
{
    bool ValidarCpfCnpj(string valor);
    string LimparFormatacao(string valor);
    string FormatarCpfCnpj(string valor);
}
