using System;
using System.Collections.Generic;
using System.Text;

namespace JO_lib_presentazionZoo.Interface
{
    public interface IComunicacion
    {
        Task<T> Ejecutar<T>(string url, object? entidad);
    }
}
