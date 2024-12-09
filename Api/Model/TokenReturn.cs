using Api.Dto;

namespace Api.Model
{
    public class TokenReturn
    {
        public UsuarioDto Usuario { get; set; }
        public string Token { get; set; }
        public List<VeiculoModel> Veiculos { get; set; }
    }
}
