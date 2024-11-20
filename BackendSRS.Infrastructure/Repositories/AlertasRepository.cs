using BackendSRS.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendSRS.Models;

namespace BackendSRS.Infrastructure.Repositories
{
    public class AlertasRepository : IAlertasRepository
    {
        // Simulación de base de datos en memoria.
        private readonly List<Alertas> _alertas = new List<Alertas>();

        public List<Alertas> ObtenerAlertas()
        {
            return _alertas;
        }

        public void AgregarAlerta(Alertas alerta)
        {
            _alertas.Add(alerta);
        }
    }
}
