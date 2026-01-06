using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OficinaCardozo.Domain.Entities
{
    [Table("OFICINA_SERVICO")]
    public class Servico
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        [Column("NOME_SERVICO")]
        public string NomeServico { get; set; } = string.Empty;

        [Required]
        [Column("PRECO")]
        public decimal Preco { get; set; }

        [Column("TEMPO_ESTIMADO_EXECUCAO")]
        public int TempoEstimadoExecucao { get; set; }

        [MaxLength(255)]
        [Column("DESCRICAO_DETALHADA_SERVICO")]
        public string DescricaoDetalhadaServico { get; set; } = string.Empty;

        [MaxLength(255)]
        [Column("FREQUENCIA_RECOMENDADA")]
        public string FrequenciaRecomendada { get; set; } = string.Empty;

        public virtual ICollection<OrdemServicoServico> OrdensServicoServicos { get; set; } = new List<OrdemServicoServico>();
    }
}