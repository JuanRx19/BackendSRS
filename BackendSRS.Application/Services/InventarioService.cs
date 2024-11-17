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
    }
}
