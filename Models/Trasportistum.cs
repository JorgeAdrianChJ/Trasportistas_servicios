using System;
using System.Collections.Generic;

namespace Trasportistas_servicios.Models
{
    public partial class Trasportistum
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
    }
}
