using System;
using System.Collections.Generic;
using BackendSRS.Models;

namespace BackendSRS.Models;

public partial class Dispositivos
{
    public int DispositivoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public string? UbicacionActual { get; set; }

    public decimal? Bateria { get; set; }

    public DateTime? UltimaMantenimiento { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Alertas> Alertas { get; set; } = new List<Alertas>();

    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();

    public virtual ICollection<Mantenimiento> Mantenimientos { get; set; } = new List<Mantenimiento>();

    public virtual ICollection<Reservas> Reservas { get; set; } = new List<Reservas>();

    public virtual ICollection<Videos> Videos { get; set; } = new List<Videos>();
}
