using Api.Dto;
using Api.Intefaces;
using Api.Model;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository
{
    public class UsuarioRepository : DbContext, IUsuarioRepository
    {
        private readonly ConnectionContext _Context;

        // Injeta o ConnectionContext no repositório
        public UsuarioRepository(ConnectionContext context)
        {
            _Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public bool ExisteEmailCadastrado(string email)
        {
            return _Context.tabUsuario.Any(u => u.email == email);
        }

        public UsuarioModel AdicionarAtualizarUsuario(UsuarioModel pUsuario)
        {
            
            _Context.tabUsuario.Update(pUsuario);
            _Context.SaveChanges();
            return pUsuario;
        }

        public UsuarioModel? AtualizarUsuario(UsuarioModel pUsuario)
        {
            var usuarioExistente = _Context.tabUsuario.Find(pUsuario.cd_usuario);
            if (usuarioExistente != null)
            {
                usuarioExistente.nome = pUsuario.nome;
                usuarioExistente.sobrenome = pUsuario.sobrenome;
                usuarioExistente.telefone = pUsuario.telefone;
                usuarioExistente.email = pUsuario.email;
                usuarioExistente.CategoriaCNH = pUsuario.CategoriaCNH;
                usuarioExistente.NumeroCNH = pUsuario.NumeroCNH;
                usuarioExistente.VencimentoCNH = pUsuario.VencimentoCNH;
                usuarioExistente.Plano = pUsuario.Plano;
                usuarioExistente.TokenPagamento = pUsuario.TokenPagamento;

                _Context.SaveChanges();
                return usuarioExistente;
            }
            else
            {
                return null;
            }
        }

        public List<UsuarioModel> GetUsuarios()
        {
            return _Context.tabUsuario.ToList();
        }

        public UsuarioModel? GetUsuarioEmail(string pEmail)
        {
            return _Context.tabUsuario.FirstOrDefault(x => x.email == pEmail);
        }

        public UsuarioDto GetUsuario(string pEmail, string pSenha)
        {
            UsuarioModel retorno = _Context.tabUsuario.FirstOrDefault(u => u.email == pEmail && u.senha == pSenha);
            if (retorno == null)
            {
                retorno = _Context.tabUsuario.FirstOrDefault(u => u.telefone == pEmail && u.senha == pSenha);
            }
            if(retorno == null)
            {
                return null;
            }
            else
            {
                return new UsuarioDto()
                {
                    senha = retorno.senha,
                    ativo = retorno.ativo,
                    cd_usuario = retorno.cd_usuario,
                    email = retorno.email,
                    nome = retorno.nome,
                    sobrenome = retorno.sobrenome,
                    telefone = retorno.telefone,
                    numeroCnh = retorno.NumeroCNH,
                    categoriaCnh = retorno.CategoriaCNH,
                    vencimentoCnh = retorno.VencimentoCNH,
                    Plano = retorno.Plano,
                    TokenPagamento = retorno.TokenPagamento
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

        public UsuarioModel? GetUsuarioId(int pId)
        {
            return _Context.tabUsuario.FirstOrDefault(x => x.cd_usuario == pId);
        }
    }
}
