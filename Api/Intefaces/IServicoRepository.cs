using Api.Model;
using Microsoft.AspNetCore.Mvc;

namespace Api.Intefaces
{
    public interface IServicoRepository
    {
        Task<ActionResult<bool>> EnviarServicos(List<Servico> pListaIncluir);
        Task<ActionResult<IEnumerable<Servico>>> GetServicos();
        Task<ActionResult<Servico>> PostServico(Servico servico);
        ActionResult<List<Servico>> GetServico(int id);
        Task<IActionResult> DeleteServico(int id);
        bool ServicoExists(int id);
    }
}
