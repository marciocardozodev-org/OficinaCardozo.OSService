using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OficinaCardozo.OSService.Domain.Entities;
{
    [Table("OFICINA_ORDEM_SERVICO_SERVICO")]
    public class OrdemServicoServico
    {
        [Column("ID_ORDEM_SERVICO")]
        public int IdOrdemServico { get; set; }

        [Column("ID_SERVICO")]
        public int IdServico { get; set; }

        [Column("VALOR_APLICADO")]
        public decimal? ValorAplicado { get; set; }

        [ForeignKey("IdOrdemServico")]
        public virtual OrdemServico OrdemServico { get; set; } = null!;

        [ForeignKey("IdServico")]
        public virtual Servico Servico { get; set; } = null!;
    }
}