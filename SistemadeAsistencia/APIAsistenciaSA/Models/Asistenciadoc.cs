using System;
using System.Collections.Generic;

namespace APIAsistenciaSA.Models
{
    public partial class Asistenciadoc
    {
        public int Fdpid { get; set; }
        public bool? Fdpestado { get; set; }
        public DateTime Fdpfecha { get; set; }
        public int Hcid { get; set; }
        public bool? Asmarca { get; set; }
        public DateTime? Marcamomento { get; set; }

        public Horariodoc Hc { get; set; }
    }
}
