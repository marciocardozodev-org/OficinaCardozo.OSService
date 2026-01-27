using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OficinaCardozo.OSService.Domain.Entities;
{
    [Table("OFICINA_VEICULO")]
    public class Veiculo
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [Column("ID_CLIENTE")]
        public int IdCliente { get; set; }

        [Required]
        [Column("PLACA")]
        [MaxLength(10)]
        public string Placa { get; set; } = string.Empty;

        [Required]
        [Column("MARCA_MODELO")]
        [MaxLength(100)]
        public string MarcaModelo { get; set; } = string.Empty;

        [Required]
        [Column("ANO_FABRICACAO")]
        public int AnoFabricacao { get; set; }

        [Required]
        [Column("COR")]
        [MaxLength(50)]
        public string Cor { get; set; } = string.Empty;

        [Required]
        [Column("TIPO_COMBUSTIVEL")]
        [MaxLength(255)]
        public string TipoCombustivel { get; set; } = string.Empty;

        [ForeignKey("IdCliente")]
        public virtual Cliente Cliente { get; set; } = null!;

        public virtual ICollection<OrdemServico> OrdensServico { get; set; } = new List<OrdemServico>();
    }
}