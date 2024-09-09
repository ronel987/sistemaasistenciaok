using System;
using System.Collections.Generic;

namespace Sasistencia80.Models;

public partial class Grado
{
    public int Grdid { get; set; }

    public bool Grdestado { get; set; }

    public string Grdnombre { get; set; } = null!;

    public int Aeid { get; set; }

    public virtual Anoescolar Ae { get; set; } = null!;

    public virtual ICollection<Curso> Cursos { get; set; } = new List<Curso>();
}
