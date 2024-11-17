using BackendSRS.Domain.Entities;

public interface IAlertasService
{
    List<Alerta> ObtenerAlertasCriticas();
}

public class AlertasService : IAlertasService
{
    public List<Alerta> ObtenerAlertasCriticas()
    {
        // Simulaci�n de l�gica para detectar alertas de baja bater�a o condiciones clim�ticas.
        return new List<Alerta>
        {
            new Alerta { Mensaje = "Bater�a baja en el dron X", Criticidad = "Alta" },
            new Alerta { Mensaje = "Condiciones clim�ticas peligrosas detectadas", Criticidad = "Alta" }
        };
    }
}



