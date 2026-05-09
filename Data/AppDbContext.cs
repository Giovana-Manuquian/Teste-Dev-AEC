using Microsoft.EntityFrameworkCore;
using TesteDevAEC.Models;

namespace TesteDevAEC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Endereco> Enderecos => Set<Endereco>();
    }
}