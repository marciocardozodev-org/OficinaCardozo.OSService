using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OficinaCardozo.OSService.Domain.Entities;

[Table("OFICINA_ORDEM_SERVICO_STATUS")]
public class OrdemServicoStatus
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [MaxLength(50)]
    [Column("DESCRICAO")]
    public string? Descricao { get; set; }

    public virtual ICollection<OrdemServico> OrdensServico { get; set; } = new List<OrdemServico>();
}
