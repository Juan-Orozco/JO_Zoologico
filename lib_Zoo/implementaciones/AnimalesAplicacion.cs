using Lib_Dominio.entidades;
using lib_Zoo.interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_Zoo.implementaciones
{
    public class AnimalesAplicacion : IAnimalesAplicacion
    {
        private IConexion IConexion;

        public AnimalesAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public List<Animales> Consultar()
        {
            return this.IConexion.Animales!.Take(5).ToList();
        }

        public List<Animales> Buscar(Animales entidad)
        {
            if (!string.IsNullOrEmpty(entidad.Codigo))
                return this.IConexion.Animales!
                    .Where(x => x.Codigo == entidad.Codigo)
                    .Take(5)
                    .ToList();

            if (!string.IsNullOrEmpty(entidad.Nombre))
                return this.IConexion.Animales!
                    .Where(x => x.Nombre!.Contains(entidad.Nombre))
                    .Take(5)
                    .ToList();

            throw new Exception("Indique codigo o nombre");
        }

        public Animales Insertar(Animales entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            if (this.IConexion.Animales!.Any(x => x.Codigo == entidad.Codigo))
                throw new Exception("El codigo ya existe");

            this.IConexion.Animales!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Animales Actualizar(Animales entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Debe indicar el Id del animal a actualizar");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            if (this.IConexion.Animales!.Any(x => x.Codigo == entidad.Codigo && x.Id != entidad.Id))
                throw new Exception("El codigo ya esta en uso");

            var entry = this.IConexion.Entry<Animales>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Animales Borrar(Animales entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Debe indicar el Id del animal a borrar");

            this.IConexion.Animales!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
