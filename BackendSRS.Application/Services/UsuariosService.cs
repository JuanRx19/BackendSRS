using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendSRS.Application.Services
{
    public class UsuariosService
    {
        public string GetUsuario(string valor, int id)
        {
            return id + " Usuario obtenido " + valor;
        }

        public string GetAyuda()
        {
            return "Ayuda obtenida";
        }

        public string CreateUsuario(string nombre, int edad)
        {
            return $"Usuario creado: {nombre}, Edad: {edad}";
        }
    }
}
