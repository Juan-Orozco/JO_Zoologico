using Lib_Dominio.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace JO_lib_presentazionZoo.Interface
{
    public interface IAnimalesFront
    {
        Animales Insertar(Animales entidad);
        Animales Actualizar(Animales entidad);
        List<Animales> Consultar();
        List<Animales> Buscar(Animales entidad);
        Animales Borrar(Animales entidad);
    }
}
