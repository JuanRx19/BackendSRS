using BackendSRS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendSRS.Domain.Repositories
{
    public interface IAlertasRepository
    {
        List<Alertas> ObtenerAlertas();
        void AgregarAlerta(Alertas alerta);
    }
}
