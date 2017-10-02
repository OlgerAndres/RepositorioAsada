using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logica;

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
            if (this.usuarios.iniciarSession("kbolivar", "secreto"))
            {
                Console.WriteLine("Session abierta!");
            }
            else
            {
                Console.WriteLine("Session fallida.");
            }
        }

        public void encriptarClave()
        {
            //
            Console.WriteLine("Encriptada: {0}", this.usuarios.encriptarClave("secreto"));
        }
    }
}
