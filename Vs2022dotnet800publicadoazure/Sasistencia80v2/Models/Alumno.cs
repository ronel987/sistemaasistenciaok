using System;
using System.Collections.Generic;

namespace Sasistencia80.Models;

public partial class Alumno
{
    public int Aluid { get; set; }

    public bool Aluestado { get; set; }

    public string? Dni { get; set; }

    public DateTime FechaRegistro { get; set; }

    public string Apellidomat { get; set; } = null!;

    public string Apellidopat { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public bool Genero { get; set; }

    public string Nombres { get; set; } = null!;

    public virtual ICollection<Asistenciaalu> Asistenciaalus { get; set; } = new List<Asistenciaalu>();
}
