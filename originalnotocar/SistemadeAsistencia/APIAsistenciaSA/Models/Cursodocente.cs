using System;
using System.Collections.Generic;

namespace APIAsistenciaSA.Models
{
    public partial class Cursodocente
    {
        public Cursodocente()
        {
            Horariodoc = new HashSet<Horariodoc>();
        }

        public int Curid { get; set; }
        public int Docid { get; set; }
        public DateTime Cdfecasig { get; set; }

        public Curso Cur { get; set; }
        public Docente Doc { get; set; }
        public ICollection<Horariodoc> Horariodoc { get; set; }
    }
}
