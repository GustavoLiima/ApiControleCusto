using Api.Model;
using Api.Model.TabRelacionamento;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository
{
    public class ConnectionContext : DbContext
    {
        private IConfiguration _configuration;
        public DbSet<UsuarioModel> tabUsuario { get; set; }
        public DbSet<Servico> tabServico { get; set; }
        public DbSet<RecuperacaoSenhaModel> tabRecuperacaoSenha { get; set; }
        public DbSet<VeiculoModel> tabVeiculos { get; set; }
        public DbSet<UsuarioVeiculo> tabUsuarioVeiculos { get; set; }


        public ConnectionContext(IConfiguration configuration, DbContextOptions options) : base(options) 
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Default"));
        }
    }
}
