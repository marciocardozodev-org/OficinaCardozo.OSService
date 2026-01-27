using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OficinaCardozo.OSService.Domain.Entities;
{
    [Table("OFICINA_ORDEM_SERVICO_PECA")]
    public class OrdemServicoPeca
    {
        [Key]
        [Column("ID_ORDEM_SERVICO")]
        public int IdOrdemServico { get; set; }

        

        [Key]
        [Column("ID_PECA", Order = 1)]
        public int IdPeca { get; set; }

        [Required]
        [Column("QUANTIDADE")]
        public int Quantidade { get; set; }

        [Column("VALOR_UNITARIO")]
        public decimal? ValorUnitario { get; set; }

        [ForeignKey("IdOrdemServico")]
        public virtual OrdemServico OrdemServico { get; set; } = null!;

        [ForeignKey("IdPeca")]
        public virtual Peca Peca { get; set; } = null!;
    }
}