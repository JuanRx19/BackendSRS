using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendSRS.Models;

namespace BackendSRS.Domain.Repositories
{
    public interface IDispositivosRepository
    {
        public List<Dispositivos> GetDispositivos();
        public void AddDevice(Dispositivos dispositivo);
    }
}
