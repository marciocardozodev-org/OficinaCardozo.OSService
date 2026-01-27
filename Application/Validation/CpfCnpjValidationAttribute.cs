using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace OficinaCardozo.OSService.Application.Validation;

public class CpfCnpjValidationAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value == null)
            return true;
        var documento = value.ToString()?.Trim() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(documento))
            return true;
        var numeroLimpo = Regex.Replace(documento, @"[^\d]", "");
        return numeroLimpo.Length switch
        {
            11 => ValidarCpf(numeroLimpo),
            14 => ValidarCnpj(numeroLimpo),
            _ => false
        };
    }
    public override string FormatErrorMessage(string name)
    {
        return $"O campo {name} deve conter um CPF (11 dígitos) ou CNPJ (14 dígitos) válido";
    }
    private static bool ValidarCpf(string cpf)
    {
        if (cpf.All(c => c == cpf[0]))
            return false;
        var soma = 0;
        for (var i = 0; i < 9; i++)
            soma += (cpf[i] - '0') * (10 - i);
        var resto = soma % 11;
        var primeiroDigito = resto < 2 ? 0 : 11 - resto;
        if ((cpf[9] - '0') != primeiroDigito)
            return false;
        soma = 0;
        for (var i = 0; i < 10; i++)
            soma += (cpf[i] - '0') * (11 - i);
        resto = soma % 11;
        var segundoDigito = resto < 2 ? 0 : 11 - resto;
        return (cpf[10] - '0') == segundoDigito;
    }
    private static bool ValidarCnpj(string cnpj)
    {
        // ...continuação do método...
        return true;
    }
}
