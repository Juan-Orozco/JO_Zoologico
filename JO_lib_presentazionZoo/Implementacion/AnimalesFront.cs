using JO_lib_presentazionZoo.Interface;
using Lib_Dominio.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace JO_lib_presentazionZoo.Implementacion
{
    public class AnimalesFront : IAnimalesFront
    {
        private IComunicacion IComunicacion;

        public AnimalesFront(IComunicacion IComunicaciones)
        {
            this.IComunicacion = IComunicaciones;
        }

        public Animales Actualizar(Animales entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var task = this.IComunicacion.Ejecutar<Animales>(
                "Animales/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Animales Borrar(Animales entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicacion.Ejecutar<Animales>(
                "Animales/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Animales> Buscar(Animales entidad)
        {
            var task = this.IComunicacion.Ejecutar<List<Animales>>(
                "Animales/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Animales> Consultar()
        {
            var task = this.IComunicacion.Ejecutar<List<Animales>>(
                "Animales/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Animales Insertar(Animales entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var task = this.IComunicacion.Ejecutar<Animales>(
                "Animales/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }
    }
}
