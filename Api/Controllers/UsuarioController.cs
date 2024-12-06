using Api.Dto;
using Api.Intefaces;
using Api.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/v1/Usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRep;
        public UsuarioController(IUsuarioRepository pUsuarioRep)
        {
            _usuarioRep = pUsuarioRep;
        }

        [HttpPost]
        public IActionResult Adicionar(UsuarioDto pUsuario)
        {
            var retorno = _usuarioRep.AdicionarAtualizarUsuario(new UsuarioModel(pUsuario.cd_usuario, pUsuario.nome, pUsuario.sobrenome, pUsuario.senha, pUsuario.telefone, pUsuario.email, pUsuario.numeroCnh, pUsuario.categoriaCnh, pUsuario.vencimentoCnh, true));
            if(retorno != null)
            {
                return Ok(retorno);
            }
            else
            {
                return BadRequest("Falha ao incluir usuário");
            }
        }

        [HttpGet]
        public IActionResult PegarUsuario()
        {
            return Ok(_usuarioRep.GetUsuarios());
        }
    }
}
