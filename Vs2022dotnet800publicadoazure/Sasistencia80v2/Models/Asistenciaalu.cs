using System;
using System.Collections.Generic;

namespace Sasistencia80.Models;

public partial class Asistenciaalu
{
    public int Fecid { get; set; }

    public DateTime Fecano { get; set; }

    public string? Marcacion { get; set; }

    public int Docid { get; set; }

    public int Aluid { get; set; }

    public bool Fecestado { get; set; }

    public virtual Alumno Alu { get; set; } = null!;

    public virtual Docente Doc { get; set; } = null!;
}
