using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BackendSRS.Models;
using BackendSRS.Domain.Repositories;
using BackendSRS.Domain.Interfaces;
using System.Threading.Tasks;
using BackendSRS.Domain.Entities.Models;

namespace BackendSRS.Application.Services
{
    
    public class ReportesService
    {
        private readonly IReporteRepository _reporteRepository;

        public ReportesService(IReporteRepository reporteRepository)
        {
            _reporteRepository = reporteRepository;
        }

        public List<ReportesDetalle> ObtenerReportes()
        {
            return _reporteRepository.ObtenerReportes();
        }

    }
}
