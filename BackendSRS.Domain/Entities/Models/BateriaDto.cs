using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendSRS.Domain.Entities.Models
{
    // Clase para representar los datos de la batería
    public class BateriaDto
    {
        public int DispositivoId { get; set; }
        public int PorcentajeBateria { get; set; }
    }
}
