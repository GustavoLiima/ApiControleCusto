using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Model
{
    [Table("RecuperacaoSenha")]
    public class RecuperacaoSenhaModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Codigo { get; set; }
        public DateTime DataHora { get; set; }
    }
}
