﻿using BackendSRS.Domain.Interfaces;
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
        public async Task CreateUsuario(string nombre, string apellido, string email, string password, int rolId, DateTime fechaRegistro)
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

        public string GetPassword(string email)
        {
            return _usuarioRepository.GetPassword(email);
        }

        public string VerificarInicioSesion(string email, string password)
        {

            string passwordCifrado = _encriptacionService.Encriptar(password);

            return _usuarioRepository.VerificarInicioSesion(email, passwordCifrado);
        }

        
    }
}
