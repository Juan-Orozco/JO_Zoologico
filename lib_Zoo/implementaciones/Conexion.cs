using Lib_Dominio.entidades;
using lib_Zoo.interfaces;
using lib_Zoo.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_Zoo.implementaciones
{
    public class Conexion : DbContext, IConexion
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DatosGenerales.StringConexion()!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<Animales>? Animales { get; set; }
    }
}
