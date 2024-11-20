using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendSRS.Domain.Entities.DTO
{
    public class DispositivoTO
    {
        public string Nombre { get; set; } = null!;
        public string Ubicacion { get; set; } = null!;
        public string Bateria { get; set; } = null!;
        public string Tipo { get; set; } = null!;
    }
}
