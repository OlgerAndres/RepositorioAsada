using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    //Atributos de la clase de usuarios
    public interface IServiciosUsuarios
    {
        bool iniciarSession(string UsuarioNombre, string clave, out Usuario usuario);
        string encriptarClave(string clave);
        List<Usuario> listar();
        Usuario encontrarPorId(int Id);
        void agregar(string UsuarioNombre, string Clave);
        void actualizar(int Id, string UsuarioNombre, string Clave);
        void borrar(int Id);
    }

    public class AccionesUsuarios : AccionesEntidades, IServiciosUsuarios
    {
        //Método de iniciar la sesión 
        public bool iniciarSession(string UsuarioNombre, string clave, out Usuario usuario)
        {
            string encriptada = this.encriptarClave(clave);
            usuario = this.contexto
                .Usuarios
                .FirstOrDefault(u => u.Nombre.Equals(UsuarioNombre) && u.Clave.Equals(encriptada));
            return usuario != null;
        }
        //Método para encriptar la clave del usuario
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
        //Método para obtener todos
        public List<Usuario> listar()
        {
            return this.contexto.Usuarios.ToList();
        }
        //Método  en encontrar
        public Usuario encontrarPorId(int Id)
        {
            return this.contexto.Usuarios.Where(u => u.Id == Id).FirstOrDefault();
        }
        //Método de agregar un usuario
        public void agregar(string UsuarioNombre, string Clave)
        {
            this.contexto.Usuarios.Add(new Usuario
            {
                Nombre = UsuarioNombre,
                Clave = this.encriptarClave(Clave)
            });
            this.contexto.SaveChanges();
        }
        //Método de actualizar  usuarios
        public void actualizar(int Id, string UsuarioNombre, string Clave)
        {
            Usuario usuario = this.encontrarPorId(Id);
            usuario.Nombre = UsuarioNombre;
            if (!usuario.Clave.Equals(Clave))
            {
                usuario.Clave = this.encriptarClave(Clave);
            }
            this.contexto.SaveChanges();
        }
        //Método de borrar un usuario
        public void borrar(int Id)
        {
            this.contexto.Usuarios.Remove(this.encontrarPorId(Id));
            this.contexto.SaveChanges();
        }
    }
}
