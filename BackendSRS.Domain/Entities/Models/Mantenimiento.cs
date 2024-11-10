using System;
using System.Collections.Generic;

namespace BackendSRS.Models;

public partial class Mantenimiento
{
    public int MantenimientoId { get; set; }

    public int? DispositivoId { get; set; }

    public DateTime FechaMantenimiento { get; set; }

    public string TipoMantenimiento { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal? KilometrajeHora { get; set; }

    public virtual Dispositivos? Dispositivo { get; set; }
}
