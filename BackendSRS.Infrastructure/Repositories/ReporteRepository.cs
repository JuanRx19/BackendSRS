
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BackendSRS.Domain.Repositories;
using BackendSRS.Infrastructure.DBContexts;
using BackendSRS.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using BackendSRS.Domain.Entities.Models;

namespace BackendSRS.Infrastructure.Repositories
{
    public class ReporteRepository : IReporteRepository
    {
        private readonly BdtransporteUniversitarioContext _context;

        public ReporteRepository(BdtransporteUniversitarioContext context)
        {
            _context = context;
        }

        public List<ReportesDetalle> ObtenerReportes()
        {
            //var consulta1 = _context.Reportes.Select(u => new Reportes
            //{
            //    ReporteID = u.ReporteID,
            //    Titulo = u.Titulo,
            //    Descripcion = u.Descripcion,
            //    DispositivoID = u.DispositivoID,
            //    ReservaID = u.ReservaID,
            //    FechaReporte = u.FechaReporte,
            //    AlertaID = u.AlertaID,
            //    UsuarioID = u.UsuarioID,

            //});

            //consulta1.ToList();

            var consulta = _context.Reportes
                .Include(rp => rp.Usuario)
                .Include(rp => rp.Reserva)
                .Include(rp => rp.Dispositivo)
                .Include(rp => rp.Alerta)
                .Select(rp => new ReportesDetalle
                {
                    ReporteID = rp.ReporteId,
                    Titulo = rp.Titulo,
                    Descripcion = rp.Descripcion,
                    FechaReporte = rp.FechaReporte,
                    NombreUsuario = rp.Usuario.Nombre,
                    FechaReserva = rp.Reserva.FechaReserva,
                    FechaInicio = rp.Reserva.FechaInicio,
                    FechaFin = rp.Reserva.FechaFin,
                    Estado = rp.Reserva.Estado,
                    TipoAlerta = rp.Alerta.TipoAlerta,
                    NombreDispositivo = rp.Dispositivo.Nombre,
                    TipoDispositivo = rp.Dispositivo.Tipo
                });

            return consulta.ToList();

        }
    }
}
