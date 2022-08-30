using AplicacionASPNetMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace AplicacionASPNetMVC.Datos
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }

        //usar los modelos
        public DbSet<Usuario> Usuario { get; set; }
    }
}
