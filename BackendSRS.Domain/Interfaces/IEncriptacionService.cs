using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendSRS.Domain.Interfaces
{
    public interface IEncriptacionService
    {
        string Encriptar(string texto);
        bool Verificar(string texto, string hash);
    }
}
