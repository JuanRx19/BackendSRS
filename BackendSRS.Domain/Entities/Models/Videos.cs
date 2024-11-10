using System;
using System.Collections.Generic;

namespace BackendSRS.Models;

public partial class Videos
{
    public int VideoId { get; set; }

    public int? DispositivoId { get; set; }

    public string RutaVideo { get; set; } = null!;

    public DateTime FechaGrabacion { get; set; }

    public int? Duracion { get; set; }

    public string Tipo { get; set; } = null!;

    public int? Retencion { get; set; }

    public virtual Dispositivos? Dispositivo { get; set; }
}
