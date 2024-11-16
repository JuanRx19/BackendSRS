using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendSRS.Domain.Repositories;
using BackendSRS.Infrastructure.DBContexts;
using BackendSRS.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendSRS.Infrastructure.Repositories
{

    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly BdtransporteUniversitarioContext _context;

        public UsuarioRepository(BdtransporteUniversitarioContext context)
        {
            _context = context;
        }

        public bool VerificarInicioSesion(string email, string password)
        {
            var usuario = _context.Usuarios.FirstOrDefault(x => x.Email == email && x.Password == password);
            if (usuario == null)
            {
                return false;
            }



            return true;
        }

        public Usuarios ObtenerUsuarioPorEmail(string email)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Email == email);
        }

        public async Task CreateUsuario(Usuarios usuario)
        {
            // Implementar
            Console.WriteLine("Implementar");

            _context.Usuarios.Add(usuario);

            _context.SaveChanges();
        }

        public List<Usuarios> GetUsuarios()
        {
            return _context.Usuarios
                .Include(u => u.Rol)
                .Select(u => new Usuarios
                {
                    UsuarioId = u.UsuarioId,
                    Nombre = u.Nombre,
                    Email = u.Email,
                    FechaRegistro = u.FechaRegistro,
                    Rol = new Roles
                    {
                        RolId = u.Rol.RolId,
                        NombreRol = u.Rol.NombreRol
                    }
                })
                .ToList();
        }
    }
}
