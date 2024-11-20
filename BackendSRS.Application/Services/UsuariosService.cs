using BackendSRS.Domain.Interfaces;
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

        private readonly IEncriptacionService _encriptacionService;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuariosService(IUsuarioRepository usuarioRepository, IEncriptacionService encriptacionService)
        {
            _encriptacionService = encriptacionService;
            _usuarioRepository = usuarioRepository;
        }
        public async Task CreateUsuario(string nombre, string email, string password, int rolId, DateTime fechaRegistro)
        {
            Usuarios usuario = new Usuarios();

            string passwordCifrado = _encriptacionService.Encriptar(password);

            usuario.Nombre = nombre;
            usuario.Email = email;
            usuario.Password = passwordCifrado;
            usuario.RolId = rolId;
            usuario.FechaRegistro = fechaRegistro;

            await _usuarioRepository.CreateUsuario(usuario);
        }

        public bool VerificarInicioSesion(string email, string password)
        {

            var usuario = GetUsuarioByEmail(email);
            if (usuario == null)
                return false;

            return _encriptacionService.VerificarPassword(password, usuario.Password);
        }

        public List<Usuarios> GetUsuarios() {
            return _usuarioRepository.GetUsuarios();
        }

        public Usuarios GetUsuarioByEmail(string email)
        {
            return _usuarioRepository.ObtenerUsuarioPorEmail(email);
        }

        public bool verificarContraseña(string email, string password)
        {
            var usuario = _usuarioRepository.ObtenerUsuarioPorEmail(email);
            if (usuario == null)
                return false;

            return _encriptacionService.VerificarPassword(password, usuario.Password);
        }

    }
}
