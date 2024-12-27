using Api.Dto;
using Api.Model;

namespace Api.Intefaces
{
    public interface IUsuarioRepository
    {
        UsuarioModel AdicionarAtualizarUsuario(UsuarioModel pUsuario);
        List<UsuarioModel> GetUsuarios();
        void RemoverUsuario(UsuarioDto pUsuario);
        public UsuarioModel? GetUsuarioEmail(string pEmail);
        public UsuarioModel? GetUsuarioId(int pId);
    }
}
