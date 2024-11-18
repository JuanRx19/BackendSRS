using BackendSRS.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendSRS.Models;
using Microsoft.EntityFrameworkCore;
using BackendSRS.Infrastructure.DBContexts;

namespace BackendSRS.Infrastructure.Repositories
{
    public class DispositivosRepository : IDispositivosRepository
    {
        private readonly BdtransporteUniversitarioContext _context;

        public DispositivosRepository(BdtransporteUniversitarioContext context)
        {
            _context = context;
        }

        public List<Dispositivos> GetDispositivos()
        {
            return _context.Dispositivos
                    .Select(u => new Dispositivos
                    {
                        Nombre = u.Nombre,
                        Tipo = u.Tipo,
                        Estado = u.Estado,
                        UbicacionActual = u.UbicacionActual,
                        Bateria = u.Bateria,
                        UltimaMantenimiento = u.UltimaMantenimiento,
                        FechaRegistro = u.FechaRegistro
                    })
                    .ToList();
        }
    }
}
