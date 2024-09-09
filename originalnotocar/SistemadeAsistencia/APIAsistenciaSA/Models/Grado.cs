using System;
using System.Collections.Generic;

namespace APIAsistenciaSA.Models
{
    public partial class Grado
    {
        public Grado()
        {
            Curso = new HashSet<Curso>();
        }

        public int Grdid { get; set; }
        public bool Grdestado { get; set; }
        public string Grdnombre { get; set; }
        public int Aeid { get; set; }

        public Anoescolar Ae { get; set; }
        public ICollection<Curso> Curso { get; set; }
    }
}
