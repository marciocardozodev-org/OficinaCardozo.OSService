using OficinaCardozo.Domain.Exceptions;

namespace OficinaCardozo.Domain.ValueObjects;

public record Placa
{
    public string Valor { get; }
    public string ValorFormatado { get; }
    public Placa(string valor)
    {
        if (string.IsNullOrWhiteSpace(valor))
            throw new ArgumentException("Placa não pode estar vazia", nameof(valor));
        var placaLimpa = LimparFormatacao(valor);
        if (!EhValida(placaLimpa))
            throw new PlacaInvalidaException(valor);
        Valor = placaLimpa.ToUpperInvariant();
        ValorFormatado = FormatarPlaca(Valor);
    }
    private static string LimparFormatacao(string placa)
    {
        return new string(placa.Where(c => char.IsLetterOrDigit(c)).ToArray());
    }
    private static bool EhValida(string placa)
    {
        if (placa.Length != 7) return false;
        var formatoAntigo = placa.Take(3).All(char.IsLetter) && placa.Skip(3).All(char.IsDigit);
        var formatoMercosul = placa.Take(3).All(char.IsLetter) && char.IsDigit(placa[3]) && char.IsLetter(placa[4]) && placa.Skip(5).All(char.IsDigit);
        return formatoAntigo || formatoMercosul;
    }
    private static string FormatarPlaca(string placa)
    {
        if (placa.Length != 7) return placa;
        return $"{placa[..3]}-{placa[3..]}";
    }
    public bool EhFormatoMercosul() => Valor.Length == 7 && char.IsLetter(Valor[4]);
    public override string ToString() => ValorFormatado;
    public static implicit operator string(Placa placa) => placa.Valor;
}
