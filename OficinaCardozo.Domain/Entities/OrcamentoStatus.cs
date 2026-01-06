using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OficinaCardozo.Domain.Entities
{
    [Table("OFICINA_ORCAMENTO_STATUS")]
    public class OrcamentoStatus
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("DESCRICAO")]
        [MaxLength(50)]
        public string? Descricao { get; set; }

        public virtual ICollection<Orcamento> Orcamentos { get; set; } = new List<Orcamento>();
    }
}