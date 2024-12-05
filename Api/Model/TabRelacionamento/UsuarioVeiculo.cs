using Api.Dto;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Model.TabRelacionamento
{
    [Table("usuario_veiculo")]
    public class UsuarioVeiculo
    {
        public int id { get; set; } // Identificador único (opcional, se a tabela tiver um campo Id)

        // Chaves estrangeiras
        public int cd_usuario { get; set; }
        public int id_veiculo { get; set; }

    }
}
