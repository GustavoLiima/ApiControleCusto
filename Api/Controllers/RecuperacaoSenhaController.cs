using Api.Intefaces;
using Api.Model;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RecuperacaoSenhaController : Controller
    {
        private readonly IUsuarioRepository _context;
        private readonly IRecuperarSenha _contextRecSenha;

        public RecuperacaoSenhaController(IUsuarioRepository context, IRecuperarSenha pContextRecSenha)
        {
            _context = context;
            _contextRecSenha = pContextRecSenha;
        }

        // Endpoint para solicitar o código
        [HttpPost("solicitar-codigo")]
        public async Task<IActionResult> SolicitarCodigo([FromBody] string email)
        {
            // Verifica se o e-mail existe na tabela de usuários
            var usuario = _context.GetUsuarioEmail(email);
            if (usuario == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            // Gera um código aleatório de 6 dígitos
            var codigo = new Random().Next(100000, 999999).ToString();

            // Armazena o código no banco de dados
            var recuperacao = new RecuperacaoSenhaModel
            {
                Email = email,
                Codigo = codigo,
                DataHora = DateTime.UtcNow
            };

            _contextRecSenha.AdicionarNovaRecuperacao(recuperacao);

            // Simula o envio do e-mail
            Console.WriteLine($"Código de recuperação enviado para {email}: {codigo}");

            return Ok("Código enviado com sucesso.");
        }

        // Endpoint para redefinir a senha
        [HttpPost("redefinir-senha")]
        public async Task<IActionResult> RedefinirSenha([FromBody] RedefinirSenhaRequest request)
        {
            // Busca o código de recuperação no banco
            var recuperacao = await _contextRecSenha.GetRecuperacao(request);

            if (recuperacao == null || (DateTime.UtcNow - recuperacao.DataHora).TotalMinutes > 15)
            {
                return BadRequest("Código inválido ou expirado.");
            }

            // Verifica se o código expirou (tempo limite: 15 minutos)
            if ((DateTime.UtcNow - recuperacao.DataHora).TotalMinutes > 15)
            {
                return BadRequest("O código expirou. Solicite um novo código.");
            }

            // Atualiza a senha do usuário
            var usuario = _context.GetUsuarioEmail(request.Email);
            if (usuario == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            usuario.senha = request.NovaSenha; // Certifique-se de hash da senha!
            _context.AdicionarAtualizarUsuario(usuario);

            return Ok("Senha atualizada com sucesso.");
        }
    }
}
