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

        public async Task<VeiculoModel> AdicionarVeiculo(VeiculoModel veiculo, int IdUsuario)
        {
            await _context.tabVeiculos.AddAsync(veiculo);
            await _context.SaveChangesAsync();
            await _context.tabUsuarioVeiculos.AddAsync(new Model.TabRelacionamento.UsuarioVeiculo()
            {
                id_veiculo = veiculo.ID,
                cd_usuario = IdUsuario
            });
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

        public async Task<VeiculoModel> ExcluirVeiculo(VeiculoModel id)
        {
            var veiculo = await GetVeiculo(id.ID);

            veiculo.Ativo = false; // Atualiza a propriedade Ativo para false
            _context.tabVeiculos.Update(veiculo); // Marca o veículo como modificado
            await _context.SaveChangesAsync(); // Salva as alterações no banco

            return veiculo;
        }

        public async Task<List<VeiculoModel>> GetVeiculosUsuario(int pIdUsuario)
        {
                var veiculos = await _context.tabUsuarioVeiculos
                    .Where(uv => uv.cd_usuario == pIdUsuario)
                    .Join(_context.tabVeiculos,
                        uv => uv.id_veiculo,
                        v => v.ID,
                        (uv, v) => v)
                    .ToListAsync();

                return veiculos;
        }
    }
}
