using BackendSRS.Infrastructure.Models;
using System;
using System.Collections.Generic;

namespace BackendSRS.Models;

public partial class Reservas
{
    public int ReservaId { get; set; }

    public int? DispositivoId { get; set; }

    public int? UsuarioId { get; set; }

    public DateTime? FechaReserva { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public string Estado { get; set; } = null!;

    public virtual Dispositivos? Dispositivo { get; set; }

    public virtual Usuarios? Usuario { get; set; }

    public virtual ICollection<Reportes> Reportes { get; set; } = new List<Reportes>();
}
