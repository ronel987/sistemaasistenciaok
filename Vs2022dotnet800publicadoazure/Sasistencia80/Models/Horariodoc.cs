using System;
using System.Collections.Generic;

namespace Sasistencia80.Models;

public partial class Horariodoc
{
    public int Hcid { get; set; }

    public string Hcdia { get; set; } = null!;

    public TimeOnly Hchoraini { get; set; }

    public TimeOnly Hchorafin { get; set; }

    public int Curid { get; set; }

    public int Docid { get; set; }

    public virtual ICollection<Asistenciadoc> Asistenciadocs { get; set; } = new List<Asistenciadoc>();

    public virtual Cursodocente Cursodocente { get; set; } = null!;
}
