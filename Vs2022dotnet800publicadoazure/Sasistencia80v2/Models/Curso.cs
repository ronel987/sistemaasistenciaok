using System;
using System.Collections.Generic;

namespace Sasistencia80.Models;

public partial class Curso
{
    public int Curid { get; set; }

    public bool Curestado { get; set; }

    public string Curnombre { get; set; } = null!;

    public int Grdid { get; set; }

    public virtual ICollection<Cursodocente> Cursodocentes { get; set; } = new List<Cursodocente>();

    public virtual Grado Grd { get; set; } = null!;

    public Curso(bool curestado, string curnombre, int grdid)
    {
        
        Curestado = curestado;
        Curnombre = curnombre;
        Grdid = grdid;
        
    }


}
