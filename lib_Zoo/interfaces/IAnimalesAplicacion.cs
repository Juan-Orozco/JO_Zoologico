using Lib_Dominio.entidades;

namespace lib_Zoo.interfaces
{
    public interface IAnimalesAplicacion
    {
        Animales Insertar(Animales entidad);
        Animales Actualizar(Animales entidad);
        List<Animales> Consultar();
        List<Animales> Buscar(Animales entidad);
        Animales Borrar(Animales entidad);
    }
}
