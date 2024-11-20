using BackendSRS.Domain.Entities.Models;
using BackendSRS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendSRS.Domain.Repositories
{
    public interface IReporteRepository
    {
        public List<ReportesDetalle> ObtenerReportes();
    }
}
