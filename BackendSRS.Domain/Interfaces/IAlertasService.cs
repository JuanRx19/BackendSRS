using BackendSRS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendSRS.Domain.Interfaces
{
    public interface IAlertasService
    {
        List<Alertas> ObtenerAlertas();
        void GenerarAlerta(string mensaje, string criticidad);
        void GenerarAlertaBateria(int dispositivoId, int porcentajeBateria);

    }
}
