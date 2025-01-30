using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api.Model
{
    [Table("Servico")]
    public class Servico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdBanco { get; set; } // Chave primária gerada automaticamente no banco

        [Required]
        public int Id { get; set; } // ID local do dispositivo

        [Required]
        public bool EnviadoServidor { get; set; }

        [Required]
        public int IdVeiculo { get; set; }

        [Required]
        public int AcaoSelecionada { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        public TimeSpan Hora { get; set; }

        [Required]
        public double Odometro { get; set; }

        [Required]
        public int Combustivel { get; set; }

        [Required]
        public double Preco { get; set; }

        [Required]
        public double ValorTotal { get; set; }

        [Required]
        public double Litros { get; set; }

        public string? Motorista { get; set; }

        [Required]
        public int FormaPagamento { get; set; }

        public string? Descricao { get; set; }

        public string? DescricaoServico { get; set; }

        public string? DescricaoDespesa { get; set; }

        [Required]
        public int TipoDespesa { get; set; }

        [Required]
        public int TipoServico { get; set; }

        [Required]
        public int Receita { get; set; }

        [Required]
        public double ValorReceita { get; set; }

        [Required]
        public double ValorDespesa { get; set; }

        [Required]
        public bool LembreteFoiServico { get; set; }

        [Required]
        public bool ApenasUmaVez { get; set; }

        [Required]
        public bool LembrarEmKm { get; set; }

        [Required]
        public bool LembrarEmData { get; set; }

        [Required]
        public double LembreteKilometragem { get; set; }

        [Required]
        public DateTime DataLembrete { get; set; }
    }





    //[Table("tab_servico")]
    //public class ServicoModel
    //{
    //    public ServicoModel() { }

    //    public ServicoModel(int cdServico, string tituloServico, string descricaoServico, double pValor, int cdEmpresa, int pTempo)
    //    {
    //        cd_servico = cdServico;
    //        tituloservico = tituloServico;
    //        descricaoservico = descricaoServico;
    //        valor = pValor;
    //        cd_empresa = cdEmpresa;
    //        tempo = pTempo;
    //    }

    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Define como auto-increment
    //    public int cd_servico { get; set; }

    //    [Required]
    //    [StringLength(255)] // Define o tamanho máximo de 255 caracteres
    //    public string tituloservico { get; set; }

    //    public string descricaoservico { get; set; } // Texto longo, pode ser nulo

    //    [Required]
    //    public double valor { get; set; } // Valor obrigatório

    //    [Required]
    //    public long cd_empresa { get; set; } // Referência à empresa (bigint)

    //    public int? tempo { get; set; } // Pode ser nulo
    //}
}
