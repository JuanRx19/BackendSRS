using BackendSRS.Domain.Entities.Models;
using BackendSRS.Domain.Repositories;

namespace BackendSRS.Infrastructure.Repositories
{
    public class AlertasRepository : IAlertasRepository
    {
        // Simulación de base de datos en memoria.
        private readonly List<Alerta> _alertas = new List<Alerta>();

        public List<Alerta> ObtenerAlertas()
        {
            return _alertas;
        }

        public void AgregarAlerta(Alerta alerta)
        {
            _alertas.Add(alerta);
        }
    }
}
