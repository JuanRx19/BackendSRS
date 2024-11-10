using System;
using System.Collections.Generic;

namespace BackendSRS.Models;

public partial class Alertas
{
    public int AlertaId { get; set; }

    public int? DispositivoId { get; set; }

    public string TipoAlerta { get; set; } = null!;

    public DateTime? FechaAlerta { get; set; }

    public string EstadoAlerta { get; set; } = null!;

    public int? UsuarioId { get; set; }

    public virtual Dispositivos? Dispositivo { get; set; }

    public virtual Usuarios? Usuario { get; set; }
}
