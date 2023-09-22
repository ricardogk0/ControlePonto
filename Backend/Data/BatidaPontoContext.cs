using Microsoft.EntityFrameworkCore;

namespace beckend.Data
{
    public class BatidaPontoContext : DbContext
    {
        public BatidaPontoContext(DbContextOptions<BatidaPontoContext> options) : base(options){}

        public DbSet<beckend.Models.Marcacao> Marcacoes { get; set; }
        public DbSet<beckend.Models.Registro> Registros { get; set; }
    }
}