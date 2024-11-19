using BackendSRS.Domain.Entities.Models;

namespace BackendSRS.Infrastructure.Repositories
{
    public interface IAlertasRepository
    {
        List<Alerta> ObtenerAlertas();
        void AgregarAlerta(Alerta alerta);
    }

    public class AlertasRepository : IAlertasRepository
    {
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
