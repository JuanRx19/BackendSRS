using BackendSRS.Domain.Repositories;
using BackendSRS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendSRS.Application.Services
{
    public class UsuariosService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuariosService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<string> VerificarInicioSesion(string email, string password)
        {
            return await _usuarioRepository.VerificarInicioSesion(email, password);
        }

        public string GetAyuda()
        {
            return "Ayuda obtenida";
        }

        public async Task CreateUsuario(string nombre, string apellido, string email, string password, int rolId, DateTime fechaRegistro)
        {
            Usuarios usuario = new Usuarios();

            usuario.Nombre = nombre;
            usuario.Email = email;
            usuario.Password = password;
            usuario.RolId = rolId;
            usuario.FechaRegistro = fechaRegistro;

            return await _usuarioRepository.CreateUsuario(usuario);
        }
    }
}
