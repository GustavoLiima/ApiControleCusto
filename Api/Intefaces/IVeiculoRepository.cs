using Api.Model;

namespace Api.Intefaces
{
    public interface IVeiculoRepository
    {
        Task<VeiculoModel> AdicionarVeiculo(VeiculoModel veiculo, int IdUsuario);
        Task<VeiculoModel?> GetVeiculo(int id);
        Task<List<VeiculoModel>> GetVeiculosUsuario(int pIdUsuario);
        Task AtualizarVeiculo(VeiculoModel veiculo);
        Task<VeiculoModel> ExcluirVeiculo(VeiculoModel veiculo);
    }
}
