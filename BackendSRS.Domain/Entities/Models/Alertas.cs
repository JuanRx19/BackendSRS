﻿using System;
using System.Collections.Generic;

namespace BackendSRS.Domain.Entities.Models
{
    public class Alerta
    {
        public int Id { get; set; }
        public string Mensaje { get; set; }
        public string Criticidad { get; set; } // Ejemplo: "Alta", "Media", "Baja"
        public DateTime FechaCreacion { get; set; }
    }
}
