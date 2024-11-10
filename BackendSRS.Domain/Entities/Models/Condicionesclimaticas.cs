using System;
using System.Collections.Generic;

namespace BackendSRS.Models;

public partial class Condicionesclimaticas
{
    public int CondicionId { get; set; }

    public DateTime? FechaCondicion { get; set; }

    public decimal? Temperatura { get; set; }

    public decimal? VelocidadViento { get; set; }

    public string EstadoClima { get; set; } = null!;

    public bool AprobadoParaVuelos { get; set; }
}
