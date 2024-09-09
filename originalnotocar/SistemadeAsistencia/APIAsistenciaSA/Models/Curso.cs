using System;
using System.Collections.Generic;

namespace APIAsistenciaSA.Models
{
    public partial class Curso
    {
        public Curso()
        {
            Cursodocente = new HashSet<Cursodocente>();
        }

        public int Curid { get; set; }
        public bool Curestado { get; set; }
        public string Curnombre { get; set; }
        public int Grdid { get; set; }

        public Grado Grd { get; set; }
        public ICollection<Cursodocente> Cursodocente { get; set; }
    }
}
