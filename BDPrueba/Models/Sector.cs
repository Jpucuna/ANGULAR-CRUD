using System;
using System.Collections.Generic;

namespace BDPrueba.Models
{
    public partial class Sector
    {
        public Sector()
        {
            Personas = new HashSet<Persona>();
            Zonas = new HashSet<Zona>();
        }

        public int CodSector { get; set; }
        public string? DesSector { get; set; }

        public virtual ICollection<Persona> Personas { get; set; }
        public virtual ICollection<Zona> Zonas { get; set; }
    }
}
