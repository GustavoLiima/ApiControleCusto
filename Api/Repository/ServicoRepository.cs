using Api.Dto;
using Api.Intefaces;
using Api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;

namespace Api.Repository
{
    public class ServicoRepository : IServicoRepository
    {
        private readonly ConnectionContext _Context;

        public ServicoRepository(ConnectionContext context)
        {
            _Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<IActionResult> DeleteServico(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<bool>> EnviarServicos(List<Servico> pListaIncluir)
        {
            throw new NotImplementedException();
        }

        public ActionResult<List<Servico>> GetServico(int id)
        {
            List<Servico> retorno = _Context.tabServico.Where(x => x.IdVeiculo == id).ToList();
            return retorno;
        }

        public Task<ActionResult<IEnumerable<Servico>>> GetServicos()
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<Servico>> PostServico(Servico servico)
        {
            await _Context.AddAsync(servico);
            await _Context.SaveChangesAsync();
            return servico;
        }

        public bool ServicoExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}
