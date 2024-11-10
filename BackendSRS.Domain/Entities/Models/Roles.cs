﻿using System;
using System.Collections.Generic;

namespace BackendSRS.Models;

public partial class Roles
{
    public int RolId { get; set; }

    public string NombreRol { get; set; } = null!;

    public virtual ICollection<Usuarios> Usuarios { get; set; } = new List<Usuarios>();
}
