using System;
using System.Collections.Generic;

namespace Sasistencia80.Models;

public partial class Docente
{
    public int Docid { get; set; }

    public bool Docestado { get; set; }

    public string Dni { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public string Apellidomat { get; set; } = null!;

    public string Apellidopat { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public bool Genero { get; set; }

    public string Nombres { get; set; } = null!;

    public virtual ICollection<Asistenciaalu> Asistenciaalus { get; set; } = new List<Asistenciaalu>();

    public virtual ICollection<Cursodocente> Cursodocentes { get; set; } = new List<Cursodocente>();
}
