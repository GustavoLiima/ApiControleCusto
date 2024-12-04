using Api.Intefaces;
using Api.Model;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository
{
    public class VeiculoRepository : DbContext, IVeiculoRepository
    {
        private readonly ConnectionContext _context;

        public VeiculoRepository(ConnectionContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<VeiculoModel> AdicionarVeiculo(VeiculoModel veiculo)
        {
            await _context.tabVeiculos.AddAsync(veiculo);
            await _context.SaveChangesAsync();
            return veiculo;
        }

        public async Task<VeiculoModel?> GetVeiculo(int id)
        {
            return await _context.tabVeiculos.FirstOrDefaultAsync(v => v.ID == id);
        }

        public async Task AtualizarVeiculo(VeiculoModel veiculo)
        {
            var veiculoExistente = await GetVeiculo(veiculo.ID);
            if (veiculoExistente == null)
            {
                throw new ArgumentException("Veículo não encontrado.");
            }

            _context.Entry(veiculoExistente).CurrentValues.SetValues(veiculo);
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirVeiculo(int id)
        {
            var veiculo = await GetVeiculo(id);
            if (veiculo == null)
            {
                throw new ArgumentException("Veículo não encontrado.");
            }

            _context.tabVeiculos.Remove(veiculo);
            await _context.SaveChangesAsync();
        }
    }
}
