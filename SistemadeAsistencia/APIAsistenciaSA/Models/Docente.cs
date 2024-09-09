using System;
using System.Collections.Generic;

namespace APIAsistenciaSA.Models
{
    public partial class Docente
    {
        public Docente()
        {
            Asistenciaalu = new HashSet<Asistenciaalu>();
            Cursodocente = new HashSet<Cursodocente>();
        }

        public int Docid { get; set; }
        public bool Docestado { get; set; }
        public string Dni { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Apellidomat { get; set; }
        public string Apellidopat { get; set; }
        public string Direccion { get; set; }
        public bool Genero { get; set; }
        public string Nombres { get; set; }

        public ICollection<Asistenciaalu> Asistenciaalu { get; set; }
        public ICollection<Cursodocente> Cursodocente { get; set; }
    }
}
