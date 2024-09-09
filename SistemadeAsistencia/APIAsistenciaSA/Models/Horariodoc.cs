using System;
using System.Collections.Generic;

namespace APIAsistenciaSA.Models
{
    public partial class Horariodoc
    {
        public Horariodoc()
        {
            Asistenciadoc = new HashSet<Asistenciadoc>();
        }

        public int Hcid { get; set; }
        public string Hcdia { get; set; }
        public TimeSpan Hchoraini { get; set; }
        public TimeSpan Hchorafin { get; set; }
        public int Curid { get; set; }
        public int Docid { get; set; }

        public Cursodocente Cursodocente { get; set; }
        public ICollection<Asistenciadoc> Asistenciadoc { get; set; }
    }
}
