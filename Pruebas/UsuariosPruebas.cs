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
        private int Id;

        public void ejecutar()
        {
            this.iniciarSession();
            this.encriptarClave();
            this.agregar();
            this.listar();
            this.encontrarPorId();
            this.actualizar();
            this.borrar();
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

        public void agregar()
        {
            string UsuarioNombre = "keboca";
            this.usuarios.agregar(UsuarioNombre, "secreto");
            this.Id = new ASADAEntidades().Usuarios
                .Where(u => u.UsuarioNombre == UsuarioNombre)
                .FirstOrDefault()
                .Id;
            Console.WriteLine("Nuevo usuario creado con ID: " + Id);
        }

        public void listar()
        {
            List<Usuario> lista = this.usuarios.listar();
            foreach (Usuario usuario in lista)
            {
                Console.WriteLine(usuario.UsuarioNombre);
            }
        }
    
        public void encontrarPorId()
        {
            Usuario usuario = this.usuarios.encontrarPorId(this.Id);
            Console.WriteLine("Usuario encontrado: " + usuario.UsuarioNombre);
        }

        public void actualizar()
        {
            this.usuarios.actualizar(this.Id, "nuevoNombre", "super-secreto");
            Console.WriteLine("Usuario actualizado.");
        }

        public void borrar()
        {
            this.usuarios.borrar(this.Id);
            Console.WriteLine("Usuario eliminado.");
        }
    }
}
