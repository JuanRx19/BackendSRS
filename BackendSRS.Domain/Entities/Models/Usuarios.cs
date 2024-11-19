using System;
using System.Collections.Generic;
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

    public virtual ICollection<Alerta> Alerta { get; set; } = new List<Alerta>();

    public virtual ICollection<Reservas> Reservas { get; set; } = new List<Reservas>();

    public virtual Roles? Rol { get; set; }
}
