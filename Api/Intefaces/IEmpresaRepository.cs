using Api.Dto;
using Api.Model;

namespace Api.Intefaces
{
    public interface IEmpresaRepository
    {
        void AdicionarAtualizarEmpresa(EmpresaModel pEmpresa);
        List<EmpresaModel> GetEmpresas();
        //void RemoverEmpresa(EmpresaDto pEmpresa);
    }
}
