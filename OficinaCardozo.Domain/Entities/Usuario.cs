using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OficinaCardozo.Domain.Entities;

[Table("OFICINA_USUARIO")]
public class Usuario
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Required]
    [Column("NOME_USUARIO")]
    [MaxLength(255)]
    public string NomeUsuario { get; set; } = string.Empty;

    [Required]
    [Column("EMAIL")]
    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [Column("HASH_SENHA")]
    [MaxLength(255)]
    public string HashSenha { get; set; } = string.Empty;

    [Required]
    [Column("COMPLEXIDADE")]
    [MaxLength(255)]
    public string Complexidade { get; set; } = string.Empty;

    [Column("DATA_CRIACAO")]
    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
}