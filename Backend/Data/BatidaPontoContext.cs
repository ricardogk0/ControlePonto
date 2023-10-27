using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class BatidaPontoContext : DbContext
    {
        public BatidaPontoContext(DbContextOptions<BatidaPontoContext> options) : base(options){}

        public DbSet<Backend.Models.Marcacao> Marcacoes { get; set; }
        public DbSet<Backend.Models.Registro> Registros { get; set; }
        public DbSet<Backend.Models.User> Users { get; set;}
    }
}