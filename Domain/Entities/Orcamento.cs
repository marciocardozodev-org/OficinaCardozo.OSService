using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OficinaCardozo.OSService.Domain.Entities;

[Table("OFICINA_ORCAMENTO")]
public class Orcamento
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Required]
    [Column("DATA_ORCAMENTO")]
    public DateTime DataOrcamento { get; set; }

    [Column("ID_ORDEM_SERVICO")]
    public int IdOrdemServico { get; set; }

    [Column("ID_STATUS")]
    public int IdStatus { get; set; }

    [ForeignKey("IdOrdemServico")]
    public virtual OrdemServico OrdemServico { get; set; } = null!;

    [ForeignKey("IdStatus")]
    public virtual OrcamentoStatus Status { get; set; } = null!;
}
