using Api.Dto;
using Api.Intefaces;
using Api.Model;
using Api.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/v1/Servicos")]
    public class ServicoController : ControllerBase
    {
        private readonly IServicoRepository _context;

        public ServicoController(IServicoRepository context)
        {
            _context = context;
        }

        [HttpPost("EnviarServicos")]
        public async Task<IActionResult> EnviarServicos([FromBody] List<Servico> servicos)
        {
            if (servicos == null || !servicos.Any())
            {
                return BadRequest("A lista de serviços está vazia ou nula.");
            }

            foreach (var servico in servicos)
            {
                await _context.PostServico(servico);
            }

            return Ok(new { message = "Serviços enviados com sucesso." });
        }

        // GET: api/Servico
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Servico>>> GetServicos()
        //{
        //    return await _context.GetServicos();
        //}

        // GET: api/Servico/{id}
        [HttpGet("{id}")]
        public ActionResult<List<Servico>> GetServico(int id)
        {
            var servico = _context.GetServico(id);

            if (servico == null)
            {
                return NotFound();
            }

            return servico;
        }

        // POST: api/Servico
        //[HttpPost]
        //public async Task<ActionResult<Servico>> PostServico(Servico servico)
        //{
        //    return await _context.PostServico(servico);
        //}

        // PUT: api/Servico/{id}
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutServico(int id, Servico servico)
        //{
        //    if (id != servico.IdBanco)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(servico).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ServicoExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // DELETE: api/Servico/{id}
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteServico(int id)
        //{
        //    return await _context.DeleteServico(id);
        //}

        //private bool ServicoExists(int id)
        //{
        //    return _context.ServicoExists(id);
        //}
    }
}
