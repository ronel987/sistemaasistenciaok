using System;
using System.Collections.Generic;

namespace APIAsistenciaSA.Models
{
    public partial class Alumno
    {
        public Alumno()
        {
            Asistenciaalu = new HashSet<Asistenciaalu>();
        }

        public int Aluid { get; set; }
        public bool Aluestado { get; set; }
        public string Dni { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Apellidomat { get; set; }
        public string Apellidopat { get; set; }
        public string Direccion { get; set; }
        public bool Genero { get; set; }
        public string Nombres { get; set; }

        public ICollection<Asistenciaalu> Asistenciaalu { get; set; }
    }
}
