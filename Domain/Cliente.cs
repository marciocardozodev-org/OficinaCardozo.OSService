using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OficinaCardozo.OSService.Domain.Entities;

[Table("OFICINA_CLIENTE")]
public class Cliente
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Required]
    [Column("NOME")]
    [MaxLength(255)]
    public string Nome { get; set; } = string.Empty;

    

    [Required]
    [Column("CPF_CNPJ")]
    [MaxLength(50)]
    public string CpfCnpj { get; set; } = string.Empty;

    [Required]
    [Column("TELEFONE_PRINCIPAL")]
    [MaxLength(50)]
    public string TelefonePrincipal { get; set; } = string.Empty;

    [Required]
    [Column("EMAIL_PRINCIPAL")]
    [MaxLength(100)]
    public string EmailPrincipal { get; set; } = string.Empty;

    [Required]
    [Column("ENDERECO_PRINCIPAL")]
    [MaxLength(255)]
    public string EnderecoPrincipal { get; set; } = string.Empty;

    public virtual ICollection<Veiculo> Veiculos { get; set; } = new List<Veiculo>();
}