using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OficinaCardozo.Domain.Entities
{
    [Table("OFICINA_PECA")]
    public class Peca
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        [Column("NOME_PECA")]
        public string NomePeca { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        [Column("CODIGO_IDENTIFICADOR")]
        public string CodigoIdentificador { get; set; } = string.Empty;

        [Required]
        [Column("PRECO")]
        public decimal Preco { get; set; }

        [Column("QTD_ESTOQUE")]
        public int QuantidadeEstoque { get; set; }

        [Column("QTD_MINIMA")]
        public int QuantidadeMinima { get; set; }

        [Required]
        [MaxLength(20)]
        [Column("UNIDADE_MEDIDA")]
        public string UnidadeMedida { get; set; } = string.Empty;

        [MaxLength(100)]
        [Column("LOCALIZACAO_ESTOQUE")]
        public string? LocalizacaoEstoque { get; set; }

        [MaxLength(500)]
        [Column("OBSERVACOES")]
        public string? Observacoes { get; set; }

        public virtual ICollection<OrdemServicoPeca> OrdensServicoPecas { get; set; } = new List<OrdemServicoPeca>();
    }
}