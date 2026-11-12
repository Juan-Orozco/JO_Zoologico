using Lib_Dominio.entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace lib_Zoo.interfaces
{
    public interface IConexion
    {
        DbSet<Animales>? Animales { get; set; }

        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}
