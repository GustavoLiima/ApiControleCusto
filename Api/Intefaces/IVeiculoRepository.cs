using Api.Model;

namespace Api.Intefaces
{
    public interface IVeiculoRepository
    {
        Task<VeiculoModel> AdicionarVeiculo(VeiculoModel veiculo);
        Task<VeiculoModel?> GetVeiculo(int id);
        Task AtualizarVeiculo(VeiculoModel veiculo);
        Task ExcluirVeiculo(int id);
    }
}
