using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logica;
using Datos;

namespace Pruebas
{
    class PruebasSectores
    {
        private IServiciosSectores sectores = new AccionesSectores();
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
            string descripcion = "SectorX";
            this.sectores.agregar(descripcion);
            this.Id = new ASADAEntidades().Sectores
                .Where(s => s.Descripcion == descripcion)
                .FirstOrDefault()
                .Id;
            Console.WriteLine("Nuevo sector creado con ID: " + Id);
        }

        private void listar()
        {
            List<Sectore> lista = this.sectores.listar();
            foreach (Sectore sector in lista)
            {
                Console.WriteLine(sector.Descripcion);
            }
        }

        private void encontrarPorId()
        {
            Sectore sector = this.sectores.encontrarPorId(this.Id);
            Console.WriteLine("Sector encontrado: " + sector.Descripcion);
        }

        private void actualizar()
        {
            this.sectores.actualizar(this.Id, "SectorY");
            Console.WriteLine("Sector actualizado.");
        }

        private void borrar()
        {
            this.sectores.borrar(this.Id);
            Console.WriteLine("Sector eliminado.");
        }
    }
}
