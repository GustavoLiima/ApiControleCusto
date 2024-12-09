using Api.Dto;
using Api.Model;
using Api.Repository;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/v1/token")]
    public class AuthController : Controller
    {
        ConnectionContext connectionContext;

        public AuthController(ConnectionContext connectionContext)
        {
            this.connectionContext = connectionContext;
        }

        [HttpPost]
        public IActionResult Auth(TokenDto pAcesso)
        {
            UsuarioRepository repUsuario = new UsuarioRepository(connectionContext);
            UsuarioDto usuario = repUsuario.GetUsuario(pAcesso.user, pAcesso.password);
            if (usuario != null)
            {
                var token = TokenService.GenerateToken(usuario);
                VeiculoRepository repVeiculo= new VeiculoRepository(connectionContext);
                return Ok(new TokenReturn()
                {
                    Token = token,
                    Usuario = usuario,
                    Veiculos = repVeiculo.GetVeiculosUsuario(usuario.cd_usuario).Result
                });
            }
            else
            {
                return BadRequest("Usuario/Senha inválido");
            }
        }
    }
}
