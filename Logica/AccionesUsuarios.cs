using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public interface IServiciosUsuarios
    {
        bool iniciarSession(string usuario, string clave);
        string encriptarClave(string clave);
    }

    public class AccionesUsuarios : IServiciosUsuarios
    {
        private ASADAEntidades contexto;

        public AccionesUsuarios()
        {
            this.contexto = new ASADAEntidades();
        }

        public bool iniciarSession(string usuarioNombre, string clave)
        {
            string encriptada = this.encriptarClave(clave);
            Usuario usuario = this.contexto
                .Usuarios
                .FirstOrDefault(u => u.UsuarioNombre.Equals(usuarioNombre) && u.Clave.Equals(encriptada));
            return usuario != null;
        }

        public string encriptarClave(string clave)
        {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] datos = md5.ComputeHash(Encoding.Default.GetBytes(clave));
            StringBuilder strConstructor = new StringBuilder();
            for (int i = 0; i < datos.Length; i++)
            {
                strConstructor.Append(datos[i].ToString("x2"));
            }
            return strConstructor.ToString();
        }
    }
}
