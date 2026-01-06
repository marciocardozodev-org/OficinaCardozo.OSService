using System.ComponentModel.DataAnnotations;
using OficinaCardozo.Application.Validation;

namespace OficinaCardozo.Application.DTOs;

public class ClienteDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string CpfCnpj { get; set; } = string.Empty;
    public string TelefonePrincipal { get; set; } = string.Empty;
    public string EmailPrincipal { get; set; } = string.Empty;
    public string EnderecoPrincipal { get; set; } = string.Empty;
}

public class CreateClienteDto
{
    [Required(ErrorMessage = "Nome é obrigatório")]
    [MaxLength(255, ErrorMessage = "Nome não pode exceder 255 caracteres")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "CPF/CNPJ é obrigatório")]
    [MaxLength(50, ErrorMessage = "CPF/CNPJ não pode exceder 50 caracteres")]
    [CpfCnpjValidation(ErrorMessage = "CPF/CNPJ deve estar em formato válido brasileiro")]
    public string CpfCnpj { get; set; } = string.Empty;

    [Required(ErrorMessage = "Telefone principal é obrigatório")]
    [MaxLength(50, ErrorMessage = "Telefone não pode exceder 50 caracteres")]
    public string TelefonePrincipal { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email principal é obrigatório")]
    [MaxLength(100, ErrorMessage = "Email não pode exceder 100 caracteres")]
    [EmailAddress(ErrorMessage = "Email deve ter um formato válido")]
    public string EmailPrincipal { get; set; } = string.Empty;

    [Required(ErrorMessage = "Endereço principal é obrigatório")]
    [MaxLength(255, ErrorMessage = "Endereço não pode exceder 255 caracteres")]
    public string EnderecoPrincipal { get; set; } = string.Empty;
}

public class UpdateClienteDto
{
    [MaxLength(255, ErrorMessage = "Nome não pode exceder 255 caracteres")]
    public string? Nome { get; set; }

    [MaxLength(50, ErrorMessage = "CPF/CNPJ não pode exceder 50 caracteres")]
    [CpfCnpjValidation(ErrorMessage = "CPF/CNPJ deve estar em formato válido brasileiro")]
    public string? CpfCnpj { get; set; }

    [MaxLength(50, ErrorMessage = "Telefone não pode exceder 50 caracteres")]
    public string? TelefonePrincipal { get; set; }

    [MaxLength(100, ErrorMessage = "Email não pode exceder 100 caracteres")]
    [EmailAddress(ErrorMessage = "Email deve ter um formato válido")]
    public string? EmailPrincipal { get; set; }

    [MaxLength(255, ErrorMessage = "Endereço não pode exceder 255 caracteres")]
    public string? EnderecoPrincipal { get; set; }
}