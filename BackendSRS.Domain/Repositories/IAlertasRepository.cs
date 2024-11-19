
using System;
using System.Collections.Generic;
using BackendSRS.Models;

namespace BackendSRS.Domain.Repositories
{
    public interface IAlertasRepository
    {
        List<Alerta> ObtenerAlertas();
        void AgregarAlerta(Alerta alerta);
    }
}
