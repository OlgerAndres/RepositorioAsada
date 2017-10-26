using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logica;
using Datos;

namespace Pruebas
{
    class UsuariosPruebas
    {
        private IServiciosUsuarios usuarios = new AccionesUsuarios();

        public void ejecutar()
        {
            this.iniciarSession();
            this.encriptarClave();
        }

        public void iniciarSession()
        {
            //
            Usuario usuario = null;
            if (this.usuarios.iniciarSession("kbolivar", "secreto", out usuario))
            {
                Console.WriteLine("Session abierta!");
            }
            else
            {
                Console.WriteLine("Session fallida.");
            }
            if (usuario != null)
            {
                Console.WriteLine("Entidad de Usuario cargado.");
            }
            else 
            {
                Console.WriteLine("Entidad de Usuario NO cargada.");
            }
        }

        public void encriptarClave()
        {
            //
            Console.WriteLine("Encriptada: {0}", this.usuarios.encriptarClave("secreto"));
        }
    }
}
