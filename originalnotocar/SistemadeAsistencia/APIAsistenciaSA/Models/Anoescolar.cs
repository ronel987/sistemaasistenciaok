using System;
using System.Collections.Generic;

namespace APIAsistenciaSA.Models
{
    public partial class Anoescolar
    {
        public Anoescolar()
        {
            Grado = new HashSet<Grado>();
        }

        public int Aeid { get; set; }
        public string Aenombre { get; set; }
        public bool Aeestado { get; set; }
        public DateTime Aefecfin { get; set; }
        public DateTime Aefecini { get; set; }

        public ICollection<Grado> Grado { get; set; }
    }
}
