using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Model
{
    [Table("tab_empresa")]
    public class EmpresaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int cd_empresa { get; set; }

        [Required]
        [StringLength(255)]
        public string nome { get; set; }

        public string descricao { get; set; }

        [StringLength(255)]
        public string telefone { get; set; }

        [StringLength(255)]
        public string endereco { get; set; }

        [StringLength(255)]
        public string bairro { get; set; }

        [StringLength(255)]
        public string cidade { get; set; }

        [StringLength(255)]
        public string pais { get; set; }
    }
}