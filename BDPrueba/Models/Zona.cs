using System;
using System.Collections.Generic;

namespace BDPrueba.Models
{
    public partial class Zona
    {
        public Zona()
        {
            Personas = new HashSet<Persona>();
        }

        public int CodZona { get; set; }
        public int? CodSector { get; set; }
        public string? DesZona { get; set; }

        public virtual Sector? CodSectorNavigation { get; set; }
        public virtual ICollection<Persona> Personas { get; set; }
    }
}
