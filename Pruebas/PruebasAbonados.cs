using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logica;
using Datos;

namespace Pruebas
{
    class PruebasAbonados
    {
        private IServiciosAbonados abonados = new AccionesAbonados();
        private int Id;

        public void ejecutar()
        {
            this.agregar();
            this.listar();
            this.encontrarPorId();
            this.actualizar();
            this.borrar();
        }

        public void agregar()
        {
            string Nombre = "AbonadoX";
            this.abonados.agregar(Nombre, "PrimerApellido", "SegundoApellido", "Cedula", "Telefono", "Celular", "Direccion", "Correo", "NombreAbonado", true);
            this.Id = new ASADAEntidades().Abonados
                .Where(a => a.Nombre == Nombre)
                .FirstOrDefault()
                .Id;
            Console.WriteLine("Nuevo abonado creado con ID: " + Id);
        }

        public void listar()
        {
            List<Abonado> lista = this.abonados.listar();
            foreach (Abonado abonado in lista)
            {
                Console.WriteLine(abonado.Nombre);
            }
        }

        public void encontrarPorId()
        {
            Abonado abonado = this.abonados.encontrarPorId(this.Id);
            Console.WriteLine("Abonado encontrado: " + abonado.Nombre);
        }

        public void actualizar()
        {
            this.abonados.actualizar(this.Id, "NuevoNombre", "NuevoPrimerApellido", "NuevoSegundoApellido", "NuevaCedula", "NuevoTelefono", "NuevoCelular", "NuevaDireccion", "NuevoCorreo", "NuevoNumeroAbonado", false);
            Console.WriteLine("Abonado actualizado.");
        }

        public void borrar()
        {
            this.abonados.borrar(this.Id);
            Console.WriteLine("Abonado eliminado.");
        }
    }
}
