using Api.Model;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository
{
    public class ConnectionContext : DbContext
    {
        public DbSet<UsuarioModel> tabUsuario { get; set; }
        public DbSet<ServicoModel> tabServico { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql(
            "Server=localhost;" +
            "Port=5432;Database=BancoDeDados;" +
            "User Id=postgres;" +
            "Password=Datamac32020");
    }
}
