using System;
using System.Collections.Generic;

namespace Sasistencia80.Models;

public partial class Anoescolar
{
    public int Aeid { get; set; }

    public string Aenombre { get; set; } = null!;

    public bool Aeestado { get; set; }

    public DateTime Aefecfin { get; set; }

    public DateTime Aefecini { get; set; }

    public virtual ICollection<Grado> Grados { get; set; } = new List<Grado>();
}
