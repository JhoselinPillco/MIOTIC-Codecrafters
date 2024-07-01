using Microsoft.EntityFrameworkCore;
using MIOTIC.Models;

namespace MIOTIC.Contexto
{
    public class MiContexto : DbContext
    {
        public MiContexto(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Inicio> Inicio { get; set; }  // Agrega esta línea
    }
}
