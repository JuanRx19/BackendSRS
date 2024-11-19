using System;
using System.Collections.Generic;

using System;

namespace BackendSRS.Models
{
    public class Alerta
    {
        // Propiedades mapeadas en la base de datos
        public int AlertaId { get; set; } // Este debe coincidir con la columna "AlertaID"
        public string? EstadoAlerta { get; set; }
        public string? TipoAlerta { get; set; }
        public DateTime FechaAlerta { get; set; } = DateTime.Now;

        // Propiedades adicionales utilizadas en tu servicio
        public int Id => AlertaId; // Alias para compatibilidad
        public string Mensaje { get; set; } = string.Empty;
        public string Criticidad { get; set; } = "Media";
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        // Relaciones de navegación (opcional según la base de datos)
        public int DispositivoId { get; set; }  // Clave foránea para Dispositivo
        public int UsuarioId { get; set; }      // Clave foránea para Usuario

        public virtual Usuarios? Usuario { get; set; }   // Relación con la entidad Usuario
        public virtual Dispositivos? Dispositivo { get; set; } // Relación con la entidad Dispositivo
    }
}
