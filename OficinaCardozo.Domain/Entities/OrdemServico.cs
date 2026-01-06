using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OficinaCardozo.Domain.Entities
{
    [Table("OFICINA_ORDEM_SERVICO")]
    public class OrdemServico
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [Column("DATA_SOLICITACAO")]
        public DateTime DataSolicitacao { get; set; }

        [Column("ID_VEICULO")]
        public int IdVeiculo { get; set; }

        [Column("ID_STATUS")]
        public int IdStatus { get; set; }

        [Column("DATA_FINALIZACAO")]
        public DateTime? DataFinalizacao { get; set; }

        [Column("DATA_ENTREGA")]
        public DateTime? DataEntrega { get; set; }

        [ForeignKey("IdVeiculo")]
        public virtual Veiculo Veiculo { get; set; } = null!;

        [ForeignKey("IdStatus")]
        public virtual OrdemServicoStatus Status { get; set; } = null!;

        public virtual ICollection<OrdemServicoServico> OrdemServicoServicos { get; set; } = new List<OrdemServicoServico>();
        public virtual ICollection<OrdemServicoPeca> OrdemServicoPecas { get; set; } = new List<OrdemServicoPeca>();
        public virtual ICollection<Orcamento> Orcamentos { get; set; } = new List<Orcamento>();
    }
}