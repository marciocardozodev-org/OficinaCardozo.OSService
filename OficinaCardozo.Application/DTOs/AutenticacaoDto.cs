using System.ComponentModel.DataAnnotations;

namespace OficinaCardozo.Application.DTOs;
public class LoginDto
{
    [Required(ErrorMessage = "Nome de usu�rio � obrigat�rio")]
    public string NomeUsuario { get; set; } = string.Empty;

    [Required(ErrorMessage = "Senha � obrigat�ria")]
    public string Senha { get; set; } = string.Empty;
}

public class LoginCpfDto
{
    [Required(ErrorMessage = "CPF/CNPJ é obrigatório")]
    public string CpfCnpj { get; set; } = string.Empty;

    [Required(ErrorMessage = "Senha é obrigatória")]
    public string Senha { get; set; } = string.Empty;
}
public class CriarUsuarioDto
{
    [Required(ErrorMessage = "Nome de usu�rio � obrigat�rio")]
    [MaxLength(255, ErrorMessage = "Nome de usu�rio n�o pode exceder 255 caracteres")]
    public string NomeUsuario { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email � obrigat�rio")]
    [EmailAddress(ErrorMessage = "Email deve ter um formato v�lido")]
    [MaxLength(100, ErrorMessage = "Email n�o pode exceder 100 caracteres")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Senha � obrigat�ria")]
    [MinLength(6, ErrorMessage = "Senha deve ter pelo menos 6 caracteres")]
    public string Senha { get; set; } = string.Empty;
}

public class AtualizarUsuarioDto
{
    [Required(ErrorMessage = "Nome de usu�rio � obrigat�rio")]
    [MaxLength(255, ErrorMessage = "Nome de usu�rio n�o pode exceder 255 caracteres")]
    public string NomeUsuario { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email � obrigat�rio")]
    [EmailAddress(ErrorMessage = "Email deve ter um formato v�lido")]
    [MaxLength(100, ErrorMessage = "Email n�o pode exceder 100 caracteres")]
    public string Email { get; set; } = string.Empty;
}

public class TokenRespostaDto
{
    public string Token { get; set; } = string.Empty;
    public DateTime ExpiraEm { get; set; }
    public string NomeUsuario { get; set; } = string.Empty;
}

public class UsuarioDto
{
    public int Id { get; set; }
    public string NomeUsuario { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime DataCriacao { get; set; }
}
