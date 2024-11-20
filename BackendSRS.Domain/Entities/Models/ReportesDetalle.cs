using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendSRS.Domain.Entities.Models
{
    public class ReportesDetalle
    {
        public int ReporteID { get; set; }
        public string Titulo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public DateTime? FechaReporte { get; set; }
        public string NombreUsuario { get; set; } = null!;
        public DateTime? FechaReserva { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Estado { get; set; } = null!;
        public string TipoAlerta { get; set; } = null!;
        public string NombreDispositivo { get; set; } = null!;
        public string TipoDispositivo { get; set; } = null!;
    }
}
