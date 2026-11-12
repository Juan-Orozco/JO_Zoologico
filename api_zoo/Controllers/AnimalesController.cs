using Lib_Dominio.entidades;
using lib_Zoo.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api_zoo.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AnimalesController : ControllerBase
    {
        private IAnimalesAplicacion IAnimalesAplicacion;

        public AnimalesController(IAnimalesAplicacion IAnimalesAplicacion)
        {
            this.IAnimalesAplicacion = IAnimalesAplicacion;
        }

        [HttpPost]
        public List<Animales> Consultar()
        {
            return this.IAnimalesAplicacion.Consultar();
        }

        [HttpPost]
        public List<Animales> Buscar(Animales entidad)
        {
            return this.IAnimalesAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Animales Insertar(Animales entidad)
        {
            return this.IAnimalesAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Animales Actualizar(Animales entidad)
        {
            return this.IAnimalesAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Animales Borrar(Animales entidad)
        {
            return this.IAnimalesAplicacion.Borrar(entidad);
        }
    }
}
