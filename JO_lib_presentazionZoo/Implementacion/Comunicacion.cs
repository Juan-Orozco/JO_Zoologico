using JO_lib_presentazionZoo.Interface;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json;

namespace JO_lib_presentazionZoo.Implementacion
{
    public class Comunicacion : IComunicacion
    {
        private static readonly HttpClient cliente = new HttpClient
        {
            Timeout = TimeSpan.FromMinutes(4)
        };
        private static readonly JsonSerializerOptions opciones = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public async Task<T> Ejecutar<T>(string url, object? entidad)
        {
            url = "http://localhost:5118/" + url;

            var body = new StringContent(
                JsonSerializer.Serialize(entidad),
                Encoding.UTF8, "application/json");

            var respuesta = await cliente.PostAsync(url, body);
            var texto = await respuesta.Content.ReadAsStringAsync();

            if (!respuesta.IsSuccessStatusCode)
                throw new Exception($"Error Comunicacion ({(int)respuesta.StatusCode})");

            return JsonSerializer.Deserialize<T>(texto, opciones)!;
        }
    }
}
