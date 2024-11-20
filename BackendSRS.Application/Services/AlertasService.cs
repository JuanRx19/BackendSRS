
using System;
using System.Collections.Generic;
using BackendSRS.Models;
using BackendSRS.Domain.Repositories;

namespace BackendSRS.Application.Services
{
    public interface IAlertasService
    {
        List<Alerta> ObtenerAlertas();
        void GenerarAlerta(string mensaje, string criticidad);
        void GenerarAlertaBateria(int dispositivoId, int porcentajeBateria);

    }

    public class AlertasService : IAlertasService
    {
        private readonly IAlertasRepository _alertasRepository;

        public AlertasService(IAlertasRepository alertasRepository)
        {
            _alertasRepository = alertasRepository;
        }

        public List<Alerta> ObtenerAlertas()
        {
            return _alertasRepository.ObtenerAlertas();
        }

        public void GenerarAlerta(string mensaje, string criticidad)
        {
            var alerta = new Alerta
            {
                //Id = new Random().Next(1, 10000), // Simulación de ID único.
                Mensaje = mensaje,
                Criticidad = criticidad,
                FechaCreacion = DateTime.Now
            };
            _alertasRepository.AgregarAlerta(alerta);
        }
        public void GenerarAlertaBateria(int dispositivoId, int porcentajeBateria)
        {
            if (porcentajeBateria <50) // Si el porcentaje de batería es menor al 20%
            {
                var mensaje = $"Batería baja en el dispositivo {dispositivoId}. Porcentaje: {porcentajeBateria}%.";
                Console.WriteLine("Alerta generada con mensaje: " + mensaje);
                GenerarAlerta(mensaje, "Alta");

            }
        }



    }
}
