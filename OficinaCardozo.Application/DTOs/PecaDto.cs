using System.ComponentModel.DataAnnotations;

namespace OficinaCardozo.Application.DTOs;

public class PecaDto
{
    public int Id { get; set; }
    public string NomePeca { get; set; } = string.Empty;
    public string CodigoIdentificador { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int QuantidadeEstoque { get; set; }
    public int QuantidadeMinima { get; set; }
    public string UnidadeMedida { get; set; } = string.Empty;
    public string? LocalizacaoEstoque { get; set; }
    public string? Observacoes { get; set; }
    public bool EstoqueBaixo => QuantidadeEstoque <= QuantidadeMinima;
}

public class CreatePecaDto
{
    [Required(ErrorMessage = "Nome da peça é obrigatório")]
    [MaxLength(150, ErrorMessage = "Nome da peça não pode exceder 150 caracteres")]
    public string NomePeca { get; set; } = string.Empty;

    [Required(ErrorMessage = "Código identificador é obrigatório")]
    [MaxLength(50, ErrorMessage = "Código identificador não pode exceder 50 caracteres")]
    public string CodigoIdentificador { get; set; } = string.Empty;

    [Required(ErrorMessage = "Preço é obrigatório")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Preço deve ser maior que zero")]
    public decimal Preco { get; set; }

    [Required(ErrorMessage = "Quantidade em estoque é obrigatória")]
    [Range(0, int.MaxValue, ErrorMessage = "Quantidade em estoque deve ser maior ou igual a zero")]
    public int QuantidadeEstoque { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Quantidade mínima deve ser maior ou igual a zero")]
    public int QuantidadeMinima { get; set; } = 0;

    [MaxLength(20, ErrorMessage = "Unidade de medida não pode exceder 20 caracteres")]
    public string UnidadeMedida { get; set; } = "UN";

    [MaxLength(100, ErrorMessage = "Localização não pode exceder 100 caracteres")]
    public string? LocalizacaoEstoque { get; set; }

    [MaxLength(500, ErrorMessage = "Observações não podem exceder 500 caracteres")]
    public string? Observacoes { get; set; }
}

public class UpdatePecaDto
{
    [MaxLength(150, ErrorMessage = "Nome da peça não pode exceder 150 caracteres")]
    public string? NomePeca { get; set; }

    [MaxLength(50, ErrorMessage = "Código identificador não pode exceder 50 caracteres")]
    public string? CodigoIdentificador { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "Preço deve ser maior que zero")]
    public decimal? Preco { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Quantidade em estoque deve ser maior ou igual a zero")]
    public int? QuantidadeEstoque { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Quantidade mínima deve ser maior ou igual a zero")]
    public int? QuantidadeMinima { get; set; }

    [MaxLength(20, ErrorMessage = "Unidade de medida não pode exceder 20 caracteres")]
    public string? UnidadeMedida { get; set; }

    [MaxLength(100, ErrorMessage = "Localização não pode exceder 100 caracteres")]
    public string? LocalizacaoEstoque { get; set; }

    [MaxLength(500, ErrorMessage = "Observações não podem exceder 500 caracteres")]
    public string? Observacoes { get; set; }
}

public class MovimentacaoEstoqueDto
{
    [Required(ErrorMessage = "Quantidade é obrigatória")]
    [Range(1, int.MaxValue, ErrorMessage = "Quantidade deve ser maior que zero")]
    public int Quantidade { get; set; }

    [Required(ErrorMessage = "Tipo de movimentação é obrigatório")]
    [RegularExpression("^(ENTRADA|SAIDA)$", ErrorMessage = "Tipo deve ser ENTRADA ou SAIDA")]
    public string Tipo { get; set; } = string.Empty;

    [MaxLength(255, ErrorMessage = "Observação não pode exceder 255 caracteres")]
    public string? Observacao { get; set; }
}