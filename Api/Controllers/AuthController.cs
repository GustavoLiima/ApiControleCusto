using Api.Dto;
using Api.Repository;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/v1/token")]
    public class AuthController : Controller
    {
        [HttpPost]
        public IActionResult Auth(TokenDto pAcesso)
        {
            UsuarioRepository repUsuario = new UsuarioRepository();
            UsuarioDto usuario = repUsuario.GetUsuario(pAcesso.user, pAcesso.password);
            if (usuario != null)
            {
                var token = TokenService.GenerateToken(usuario);
                return Ok(token);
            }
            else
            {
                return BadRequest("Usuario/Senha inválido");
            }
        }
    }
}
