using BackendSRS.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendSRS.Models;
using BackendSRS.Infrastructure.DBContexts;
using Microsoft.EntityFrameworkCore;

namespace BackendSRS.Infrastructure.Repositories
{
    public class VideosRepository : IVideosRepository
    {
        private readonly BdtransporteUniversitarioContext _context;

        public VideosRepository(BdtransporteUniversitarioContext context)
        {
            _context = context;
        }
        public List<Videos> GetVideos()
        {
            return _context.Videos
                    .Include(d => d.Dispositivo)
                    .Select(u => new Videos
                    {
                        VideoId = u.VideoId,
                        RutaVideo = u.RutaVideo,
                        FechaGrabacion = u.FechaGrabacion,
                        Duracion = u.Duracion,
                        Tipo = u.Tipo,
                        Dispositivo = new Dispositivos
                        {
                            DispositivoId = u.Dispositivo.DispositivoId,
                            Nombre = u.Dispositivo.Nombre,
                            Tipo = u.Dispositivo.Tipo,
                            Estado = u.Dispositivo.Estado,
                            UbicacionActual = u.Dispositivo.UbicacionActual,
                            Bateria = u.Dispositivo.Bateria,
                            UltimaMantenimiento = u.Dispositivo.UltimaMantenimiento,
                            FechaRegistro = u.Dispositivo.FechaRegistro
                        }
                    })
                    .ToList();
        }
    }
}
