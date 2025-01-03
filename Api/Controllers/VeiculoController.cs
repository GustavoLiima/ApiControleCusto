using Api.Intefaces;
using Api.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class VeiculoController : Controller
    {
        private readonly IVeiculoRepository _context;

        public VeiculoController(IVeiculoRepository context)
        {
            _context = context;
        }

        // Criar um novo veículo
        [HttpPost("criar")]
        [Authorize]
        public async Task<IActionResult> CriarVeiculo([FromBody] VeiculoModel veiculo)
        {
            if (veiculo == null)
            {
                return BadRequest("Dados do veículo são obrigatórios.");
            }

            var claims = User.Claims;
            var id = int.Parse(claims.FirstOrDefault(c => c.Type == "usuarioID")?.Value);

            VeiculoModel objret = await _context.AdicionarVeiculo(veiculo, id);
            return Ok(objret);
        }

        // Buscar veículo por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterVeiculo(int id)
        {
            var veiculo = await _context.GetVeiculo(id);
            if (veiculo == null)
            {
                return NotFound("Veículo não encontrado.");
            }

            return Ok(veiculo);
        }

        [HttpDelete("Desabilitar")]
        public async Task<IActionResult> DesabilitarVeiculo(int id)
        {
            var veiculo = await _context.GetVeiculo(id);
            if (veiculo == null)
            {
                return BadRequest("Veículo não encontrado.");
            }

            var retorno = await _context.ExcluirVeiculo(veiculo);

            return Ok(retorno);
        }

        // Atualizar veículo
        [HttpPut("atualizar")]
        public async Task<IActionResult> AtualizarVeiculo([FromBody] VeiculoModel veiculo)
        {
            if (veiculo == null || veiculo.ID == 0)
            {
                return BadRequest("Dados inválidos para atualização.");
            }

            await _context.AtualizarVeiculo(veiculo);
            return Ok("Veículo atualizado com sucesso.");
        }

        // Excluir veículo por ID
        [HttpDelete("excluir/{id}")]
        public async Task<IActionResult> ExcluirVeiculo(int id)
        {
            //await _context.ExcluirVeiculo(id);
            return Ok("Veículo excluído com sucesso.");
        }
    }
}
