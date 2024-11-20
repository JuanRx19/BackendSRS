using BackendSRS.Domain.Interfaces;
using BackendSRS.Domain.Repositories;
using BackendSRS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendSRS.Application.Services
{
    public class InventarioService
    {
        private readonly IDispositivosRepository _dispositivosRepository;

        public InventarioService(IDispositivosRepository dispositivosRepository)
        {
            _dispositivosRepository = dispositivosRepository;
        }

        public List<Dispositivos> GetInventario()
        {
            return _dispositivosRepository.GetDispositivos();
        }


        public void AddDevice(string Nombre, string Ubicacion, string Bateria, string Tipo)
        {
            Dispositivos dispositivo = new Dispositivos
            {
                Nombre = Nombre,
                UbicacionActual = Ubicacion,
                Bateria = int.Parse(Bateria),
                Tipo = Tipo,
                Estado = "Disponible",
                UltimaMantenimiento = DateTime.Now,
                FechaRegistro = DateTime.Now
            };
            _dispositivosRepository.AddDevice(dispositivo);
        }
    }
}
