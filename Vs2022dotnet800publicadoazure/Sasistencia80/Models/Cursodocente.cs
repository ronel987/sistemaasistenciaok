using System;
using System.Collections.Generic;

namespace Sasistencia80.Models;

public partial class Cursodocente
{
    public int Curid { get; set; }

    public int Docid { get; set; }

    public DateTime Cdfecasig { get; set; }

    public virtual Curso Cur { get; set; } = null!;

    public virtual Docente Doc { get; set; } = null!;

    public virtual ICollection<Horariodoc> Horariodocs { get; set; } = new List<Horariodoc>();
}
