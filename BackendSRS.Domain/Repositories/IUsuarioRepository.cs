﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendSRS.Domain.Repositories
{
    public interface IUsuarioRepository
    {

        public async Task<string> VerificarInicioSesion(string email, string password);
        public async Task CreateUsuario(string nombre, string apellido, string email, string password, int rolId, DateTime fechaRegistro);

    }
}
