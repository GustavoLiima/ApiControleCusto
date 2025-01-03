using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api.Model
{
    [Table("Veiculo")]
    public class VeiculoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Indica auto incremento
        public int ID { get; set; }

        [Required]
        [MaxLength(255)]
        public string NomeVeiculo { get; set; }

        [Required]
        public string Marca { get; set; }

        [Required]
        [MaxLength(50)]
        public string Placa { get; set; }

        [Required]
        public int TipoVeiculo { get; set; }

        public int? TipoCombustivel { get; set; }

        public int? CapacidadeTanque { get; set; }

        public int? Kilometragem { get; set; }

        public int? AnoFabricacao { get; set; }

        public int? AnoModelo { get; set; }

        [MaxLength(255)]
        public string? Chassi { get; set; }

        [MaxLength(255)]
        public string? Renavam { get; set; }

        public string? Anotacoes { get; set; }
        public bool Ativo { get; set; }
    }
}
