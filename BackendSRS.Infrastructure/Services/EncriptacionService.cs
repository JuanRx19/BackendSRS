using BackendSRS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BackendSRS.Infrastructure.Services
{
    public class EncriptacionService : IEncriptacionService
    {
        public string Encriptar(string texto)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(texto));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public bool Verificar(string texto, string hash)
        {
            var hashDeTexto = Encriptar(texto);
            return hash == hashDeTexto;
        }
    }

}
