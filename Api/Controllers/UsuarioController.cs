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
            _usuarioRep.AdicionarAtualizarUsuario(new UsuarioModel(pUsuario.cd_usuario, pUsuario.usuario, pUsuario.nome, pUsuario.sobrenome, pUsuario.senha, pUsuario.telefone, pUsuario.email, true));
            return Ok(true);
        }

        [HttpGet]
        [Authorize]
        public IActionResult PegarUsuario()
        {
            return Ok(_usuarioRep.GetUsuarios());
        }
    }
}
