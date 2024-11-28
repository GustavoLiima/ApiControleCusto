using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api.Model
{
    [Table("tab_servico")]
    public class ServicoModel
    {
        public ServicoModel() { }

        public ServicoModel(int cdServico, string tituloServico, string descricaoServico, double pValor, int cdEmpresa, int pTempo)
        {
            cd_servico = cdServico;
            tituloservico = tituloServico;
            descricaoservico = descricaoServico;
            valor = pValor;
            cd_empresa = cdEmpresa;
            tempo = pTempo;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Define como auto-increment
        public int cd_servico { get; set; }

        [Required]
        [StringLength(255)] // Define o tamanho máximo de 255 caracteres
        public string tituloservico { get; set; }

        public string descricaoservico { get; set; } // Texto longo, pode ser nulo

        [Required]
        public double valor { get; set; } // Valor obrigatório

        [Required]
        public long cd_empresa { get; set; } // Referência à empresa (bigint)

        public int? tempo { get; set; } // Pode ser nulo
    }
}
