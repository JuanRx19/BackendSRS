using System;
using System.Collections.Generic;

namespace BackendSRS.Models;

public partial class Proveedores
{
    public int ProveedorId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Contacto { get; set; }

    public string? Direccion { get; set; }

    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();
}
