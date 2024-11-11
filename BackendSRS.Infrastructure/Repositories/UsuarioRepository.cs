using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendSRS.Domain.Repositories;
using BackendSRS.Models;

namespace BackendSRS.Infrastructure.Repositories
{

    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly BdtransporteUniversitarioContext _context;

        public UsuarioRepository(BdtransporteUniversitarioContext context)
        {
            _context = context;
        }

        public async Task<string> VerificarInicioSesion(string email, string password)
        {
            var usuario = _context.Usuarios.FirstOrDefault(x => x.Email == email && x.Password == password);
            if (usuario == null)
            {
                return "Usuario no encontrado";
            }
            return "Usuario encontrado";
        }

        public async Task CreateUsuario(string nombre, string apellido, string email, string password, int rolId, DateTime fechaRegistro)
        {
            // Implementar
            Console.WriteLine("Implementar");
        }


    }
}
