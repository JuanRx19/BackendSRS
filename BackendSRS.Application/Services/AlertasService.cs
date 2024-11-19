using BackendSRS.Domain.Entities.Models;
using BackendSRS.Infrastructure.Repositories;

namespace BackendSRS.Application.Services
{
    public interface IAlertasService
    {
        List<Alerta> ObtenerAlertasCriticas();
        void GenerarAlerta(string mensaje, string criticidad);
    }

    public class AlertasService : IAlertasService
    {
        private readonly IAlertasRepository _repository;

        public AlertasService(IAlertasRepository repository)
        {
            _repository = repository;
        }

        public List<Alerta> ObtenerAlertasCriticas()
        {
            return _repository.ObtenerAlertas();
        }

        public void GenerarAlerta(string mensaje, string criticidad)
        {
            var alerta = new Alerta
            {
                Id = new Random().Next(1, 1000), // Simulación de ID único
                Mensaje = mensaje,
                Criticidad = criticidad,
                FechaCreacion = DateTime.Now
            };
            _repository.AgregarAlerta(alerta);
        }
    }
}
