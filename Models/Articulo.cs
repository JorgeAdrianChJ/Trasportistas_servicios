using System;
using System.Collections.Generic;

namespace Trasportistas_servicios.Models
{
    public partial class Articulo
    {
        public int Id { get; set; }
        public string? TrasportistaCodigo { get; set; }
        public string? TrakingId { get; set; }
        public string? Descripcion { get; set; }
        public decimal? Peso { get; set; }
        public decimal? Precio { get; set; }
        public string? ClienteCodigo { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public DateTime? FechaRetiro { get; set; }
        public int? Estado { get; set; }
    }
}
