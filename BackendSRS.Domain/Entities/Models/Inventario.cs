using System;
using System.Collections.Generic;

namespace BackendSRS.Models;

public partial class Inventario
{
    public int InventarioId { get; set; }

    public int? DispositivoId { get; set; }

    public string Componente { get; set; } = null!;

    public int Cantidad { get; set; }

    public int? ProveedorId { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public virtual Dispositivos? Dispositivo { get; set; }

    public virtual Proveedores? Proveedor { get; set; }
}
