using System;
using System.Collections.Generic;

using System;

namespace BackendSRS.Models
{
    public class Alertas
    {
        // Propiedades mapeadas en la base de datos
        public int AlertaId { get; set; }
        public string? EstadoAlerta { get; set; }
        public string? TipoAlerta { get; set; }
        public DateTime FechaAlerta { get; set; } = DateTime.Now;

        // Propiedades adicionales utilizadas en tu servicio
        public int Id => AlertaId; // Alias para compatibilidad
        public string Mensaje { get; set; } = string.Empty;
        public string Criticidad { get; set; } = "Media";
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        // Relaciones de navegación
        public int DispositivoId { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuarios? Usuario { get; set; }
        public virtual Dispositivos? Dispositivo { get; set; }
    }
}
