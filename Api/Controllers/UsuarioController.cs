using Api.Dto;
using Api.Intefaces;
using Api.Model;
using Api.Model.Enum;
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
            var retorno = _usuarioRep.AtualizarUsuario(new UsuarioModel(pUsuario.cd_usuario, pUsuario.nome, pUsuario.sobrenome, pUsuario.senha, pUsuario.telefone, pUsuario.email, pUsuario.numeroCnh, pUsuario.categoriaCnh, pUsuario.vencimentoCnh, true, (int)EPlanos.Gratuito));
            if(retorno != null)
            {
                return Ok(retorno);
            }
            else
            {
                return BadRequest("Falha ao incluir usuário");
            }
        }

        [HttpPost("AtualizarUsuario")]
        [Authorize]
        public IActionResult Atualizar(UsuarioDto pUsuario)
        {
            var retorno = _usuarioRep.AdicionarAtualizarUsuario(new UsuarioModel(pUsuario.cd_usuario, pUsuario.nome, pUsuario.sobrenome, pUsuario.senha, pUsuario.telefone, pUsuario.email, pUsuario.numeroCnh, pUsuario.categoriaCnh, pUsuario.vencimentoCnh, true, pUsuario.Plano));
            if (retorno != null)
            {
                return Ok(retorno);
            }
            else
            {
                return BadRequest("Falha ao atualizar usuário");
            }
        }

        [HttpGet]
        public IActionResult PegarUsuario()
        {
            return Ok(_usuarioRep.GetUsuarios());
        }

        [HttpPut("AtualizarSenha")]
        [Authorize]
        public IActionResult AtualizarSenha([FromBody] string novaSenha)
        {
            try
            {
                var claims = User.Claims;
                var id = int.Parse(claims.FirstOrDefault(c => c.Type == "usuarioID")?.Value);

                var user = _usuarioRep.GetUsuarioId(id);

                user.senha = novaSenha;

                _usuarioRep.AdicionarAtualizarUsuario(user);
                return Ok("Senha atualizada com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }
    }
}
