using BackendSRS.Domain.Entities;

public interface IAlertasService
{
    List<Alerta> ObtenerAlertasCriticas();
}

public class AlertasService : IAlertasService
{
    public List<Alerta> ObtenerAlertasCriticas()
    {
        // Simulación de lógica para detectar alertas de baja batería o condiciones climáticas.
        return new List<Alerta>
        {
            new Alerta { Mensaje = "Batería baja en el dron X", Criticidad = "Alta" },
            new Alerta { Mensaje = "Condiciones climáticas peligrosas detectadas", Criticidad = "Alta" }
        };
    }
}



