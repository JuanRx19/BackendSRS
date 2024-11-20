using System;
using System.Collections.Generic;
using BackendSRS.Infrastructure.Models;
using BackendSRS.Models;


namespace BackendSRS.Models;

public partial class Usuarios
{
    public int UsuarioId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? RolId { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Alertas> Alertas { get; set; } = new List<Alertas>();

    public virtual ICollection<Reservas> Reservas { get; set; } = new List<Reservas>();

    public virtual Roles? Rol { get; set; }

    public virtual ICollection<Reportes> Reportes { get; set; } = new List<Reportes>();
}
