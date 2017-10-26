using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logica;
using Datos;

namespace Pruebas
{
    class PruebasTarifas
    {
        private IServiciosTarifas tarifas = new AccionesTarifas();
        private int Id;

        public void ejecutar()
        {
            this.agregar();
            this.listar();
            this.encontrarPorId();
            this.actualizar();
            this.borrar();
        }

        private void agregar()
        {
            string descripcion = "TarifaX";
            this.tarifas.agregar(descripcion, 0);
            this.Id = new ASADAEntidades().Tarifas
                .Where(t => t.Descripcion == descripcion)
                .FirstOrDefault()
                .Id;
            Console.WriteLine("Nueva tarifa creado con ID: " + Id);
        }

        private void listar()
        {
            List<Tarifa> lista = this.tarifas.listar();
            foreach (Tarifa tarifa in lista)
            {
                Console.WriteLine(tarifa.Descripcion);
            }
        }

        private void encontrarPorId()
        {
            Tarifa tarifa = this.tarifas.encontrarPorId(this.Id);
            Console.WriteLine("Tarifa encontrada: " + tarifa.Descripcion);
        }

        private void actualizar()
        {
            this.tarifas.actualizar(this.Id,"TarifaY", 0);
            Console.WriteLine("Tarifa actualizada.");
        }

        private void borrar()
        {
            this.tarifas.borrar(this.Id);
            Console.WriteLine("Tarifa eliminada.");
        }
    }
}
