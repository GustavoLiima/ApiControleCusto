using Api.Model;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository
{
    public class ConnectionContext : DbContext
    {
        private IConfiguration _configuration;
        public DbSet<UsuarioModel> tabUsuario { get; set; }
        public DbSet<ServicoModel> tabServico { get; set; }

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
