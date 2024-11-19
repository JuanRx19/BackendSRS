using BackendSRS.Domain.Entities.Models;

namespace BackendSRS.Domain.Repositories
{
    public interface IAlertasRepository
    {
        List<Alerta> ObtenerAlertas();
        void AgregarAlerta(Alerta alerta);
    }
}
