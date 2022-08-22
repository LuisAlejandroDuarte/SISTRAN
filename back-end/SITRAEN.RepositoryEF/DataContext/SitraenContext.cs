using Microsoft.EntityFrameworkCore;
using SITRAEN.Entities.POCOs;

namespace SITRAEN.RepositoryEF.DataContext
{
    public class SitraenContext: DbContext
    {
        public SitraenContext(DbContextOptions<SitraenContext> options) : base(options) { }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Contacto> Contactos { get; set; }
        

    }
}
