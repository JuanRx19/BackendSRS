﻿using BackendSRS.Models;
using System;
using System.Collections.Generic;

namespace BackendSRS.Infrastructure.Models;

public partial class Reportes
{
    public int ReporteId { get; set; }

    public int DispositivoId { get; set; }

    public int ReservaId { get; set; }

    public int UsuarioId { get; set; }

    public int? AlertaId { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public DateTime FechaReporte { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Alertas? Alerta { get; set; }

    public virtual Usuarios? Usuario { get; set; }

    public virtual Dispositivos? Dispositivo { get; set; }

    public virtual Reservas? Reserva { get; set; }

}
