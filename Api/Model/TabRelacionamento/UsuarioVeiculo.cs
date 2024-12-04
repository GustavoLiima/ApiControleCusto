using Api.Dto;

namespace Api.Model.TabRelacionamento
{
    public class UsuarioVeiculo
    {
        public int Id { get; set; } // Identificador único (opcional, se a tabela tiver um campo Id)

        // Chaves estrangeiras
        public int CdUsuario { get; set; }
        public int IdVeiculo { get; set; }

        // Propriedades de navegação
        public UsuarioModel Usuario { get; set; } // Relação com a entidade Usuario
        public VeiculoModel Veiculo { get; set; } // Relação com a entidade Veiculo
    }
}
