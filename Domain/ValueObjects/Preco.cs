using OficinaCardozo.Domain.Exceptions;

namespace OficinaCardozo.Domain.ValueObjects;

public record Preco
{
    public decimal Valor { get; }
    public Preco(decimal valor)
    {
        if (valor <= 0)
            throw new PrecoInvalidoException(valor);
        if (valor > 999999.99m)
            throw new PrecoInvalidoException(valor, "Preço não pode exceder R$ 999.999,99");
        Valor = Math.Round(valor, 2);
    }
    public string ValorFormatado => Valor.ToString("C2");
    public override string ToString() => ValorFormatado;
    public static implicit operator decimal(Preco preco) => preco.Valor;
    public static implicit operator Preco(decimal valor) => new(valor);
}
