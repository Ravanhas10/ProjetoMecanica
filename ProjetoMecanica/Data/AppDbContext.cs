using Microsoft.EntityFrameworkCore;
using ProjetoMecanica.Models;

namespace ProjetoMecanica.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Usuarios> Usuario { get; set; }
        public DbSet<Clientes> Cliente { get; set; }
        public DbSet<Veiculos> Veiculo { get; set; }
        public DbSet<Agendamentos> Agendamentos { get; set; }
    }
}
