using Api.Dto;
using Api.Intefaces;
using Api.Model;

namespace Api.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ConnectionContext _Context = new ConnectionContext();

        public void AdicionarAtualizarUsuario(UsuarioModel pUsuario)
        {
            _Context.tabUsuario.Add(pUsuario);
            _Context.SaveChanges();
        }

        public List<UsuarioModel> GetUsuarios()
        {
            return _Context.tabUsuario.ToList();
        }

        public UsuarioDto GetUsuario(string pUsuario, string pSenha)
        {
            UsuarioModel retorno = _Context.tabUsuario.FirstOrDefault(u => u.usuario == pUsuario && u.senha == pSenha);
            if (retorno == null)
            {
                retorno = _Context.tabUsuario.FirstOrDefault(u => u.telefone == pUsuario && u.senha == pSenha);
            }
            if(retorno == null)
            {
                return null;
            }
            else
            {
                return new UsuarioDto()
                {
                    usuario = retorno.usuario,
                    senha = retorno.senha,
                    ativo = retorno.ativo,
                    cd_usuario = retorno.cd_usuario,
                    email = retorno.email,
                    nome = retorno.nome,
                    sobrenome = retorno.sobrenome,
                    telefone = retorno.telefone
                };
            }
        }

        public void RemoverUsuario(UsuarioDto pUsuario)
        {
            var usuario = new UsuarioModel { cd_usuario = pUsuario.cd_usuario };

            _Context.tabUsuario.Attach(usuario); // Anexa a entidade ao contexto
            _Context.tabUsuario.Remove(usuario); // Marca para remoção
            _Context.SaveChanges(); // Salva as mudanças no banco
        }
    }
}
