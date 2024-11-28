using Api.Dto;
using Api.Model;

namespace Api.Intefaces
{
    public interface IServicoRepository
    {
        void AdicionarAtualizarServico(ServicoModel pServico);
        List<ServicoModel> GetServicos();
        void RemoverServico(ServicoDto pServico);
    }
}
