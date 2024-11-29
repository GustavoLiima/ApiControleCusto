using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Model
{
    [Table("usuario")]
    public class UsuarioModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Auto-incremento
        public int cd_usuario { get; set; }

        [Required]
        [StringLength(255)]  // Tamanho máximo de 255 caracteres
        public string nome { get; set; }

        [Required]
        [StringLength(255)]  // Tamanho máximo de 255 caracteres
        public string sobrenome { get; set; }

        [StringLength(255)]  // Tamanho máximo de 255 caracteres
        public string telefone { get; set; }

        [Required]
        [StringLength(255)]  // Tamanho máximo de 255 caracteres
        public string email { get; set; }

        [Required]
        [StringLength(255)]  // Tamanho máximo de 255 caracteres
        public string senha { get; set; }

        [StringLength(255)]  // Tamanho máximo de 255 caracteres
        public string? NumeroCNH { get; set; }
        [StringLength(255)]  // Tamanho máximo de 255 caracteres
        public string? CategoriaCNH { get; set; }
        public DateTime? VencimentoCNH { get; set; }

        [Required]
        public bool ativo { get; set; }  // Status ativo
        public UsuarioModel() { }

        public UsuarioModel(int pcdUsuario, string pNome, string pSobrenome, string pSenha, string pTelefone, string pEmail, string pNumeroCNH, string pCategoriaCNH, DateTime? pVencimentoCNH, bool pAtivo) 
        {
            cd_usuario = pcdUsuario;
            nome = pNome;
            sobrenome = pSobrenome;
            telefone = pTelefone;
            email = pEmail;
            senha = pSenha;
            ativo = pAtivo;
            NumeroCNH = pNumeroCNH;
            CategoriaCNH = pCategoriaCNH;
            VencimentoCNH = pVencimentoCNH;
        }
    }
}
