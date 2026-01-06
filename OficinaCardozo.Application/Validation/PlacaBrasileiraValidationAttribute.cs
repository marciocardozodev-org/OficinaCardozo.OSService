using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace OficinaCardozo.Application.Validation;

public class PlacaBrasileiraValidationAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value == null)
            return true; 

        var placa = value.ToString()?.Trim().ToUpperInvariant() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(placa))
            return true; 

        var placaLimpa = Regex.Replace(placa, @"[^A-Z0-9]", "");
                
        var formatoAntigo = new Regex(@"^[A-Z]{3}[0-9]{4}$");
                
        var formatoMercosul = new Regex(@"^[A-Z]{3}[0-9]{1}[A-Z]{1}[0-9]{2}$");

        return formatoAntigo.IsMatch(placaLimpa) || formatoMercosul.IsMatch(placaLimpa);
    }

    public override string FormatErrorMessage(string name)
    {
        return $"O campo {name} deve conter uma placa brasileira válida no formato ABC1234 (padrão antigo) ou ABC1D23 (padrão Mercosul)";
    }
}