using Api.Dto;
using Api.Intefaces;
using Api.Model;

namespace Api.Repository
{
    public class ServicoRepository : IServicoRepository
    {
        private readonly ConnectionContext _Context = new ConnectionContext();

        public void AdicionarAtualizarServico(ServicoModel pServico)
        {
            _Context.tabServico.Add(pServico);
            _Context.SaveChanges();
        }

        public List<ServicoModel> GetServicos()
        {
            return _Context.tabServico.ToList();
        }

        public void RemoverServico(ServicoDto pServico)
        {
            var servico = new ServicoModel { cd_servico = pServico.cdServico };

            _Context.tabServico.Attach(servico); // Anexa a entidade ao contexto
            _Context.tabServico.Remove(servico); // Marca para remoção
            _Context.SaveChanges(); // Salva as mudanças no banco
        }
    }
}
