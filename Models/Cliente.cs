using System;
using System.Collections.Generic;

namespace Trasportistas_servicios.Models
{
    public partial class Cliente
    {
        public int Id { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Identificacion { get; set; }
    }
}
