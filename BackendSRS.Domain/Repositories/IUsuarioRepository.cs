using BackendSRS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendSRS.Domain.Repositories
{
    public interface IUsuarioRepository
    {
        public Usuarios ObtenerUsuarioPorEmail(string email);
        public bool VerificarInicioSesion(string email, string password);
        public Task CreateUsuario(Usuarios usuario);

        public List<Usuarios> GetUsuarios();
    }
}
