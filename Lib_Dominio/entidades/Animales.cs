using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Lib_Dominio.entidades
{
    [Index(nameof(Codigo), IsUnique = true)]
    public class Animales
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string? Codigo { get; set; }
        [MaxLength(50)]
        public string? Nombre { get; set; }
        [MaxLength(50)]
        public string? Especie { get; set; }
        [MaxLength(50)]
        public string? Habitat { get; set; }

        public bool Validar()
        {
            return string.IsNullOrEmpty(Codigo) ||
                   string.IsNullOrEmpty(Nombre) ||
                   string.IsNullOrEmpty(Especie) ||
                   string.IsNullOrEmpty(Habitat);
        }
    }
}
