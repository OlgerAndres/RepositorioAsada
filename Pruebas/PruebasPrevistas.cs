using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logica;
using Datos;

namespace Pruebas
{
    class PruebasPrevistas
    {
        private IServiciosPrevistas previstas = new AccionesPrevistas();
        private int Id;

        private ASADAEntidades contexto = new ASADAEntidades();
        private Abonado Abonado;
        private Tarifa Tarifa;
        private Sectore Sector;

        public void ejecutar()
        {
            this.Abonado = new Abonado { Nombre = "AbonadoY" };
            this.contexto.Abonados.Add(this.Abonado);

            this.Tarifa = new Tarifa { Descripcion = "Descripcion Tarifa Y" };
            this.contexto.Tarifas.Add(this.Tarifa);
            
            this.Sector = new Sectore { Descripcion = "Descripcion Sector Y" };
            this.contexto.Sectores.Add(this.Sector);

            this.contexto.SaveChanges();

            this.agregar();
            this.listar();
            this.encontrarPorId();
            this.actualizar();
            this.borrar();
        }

        public void agregar()
        {   
            this.previstas.agregar(this.Abonado.Id, this.Tarifa.Id, this.Sector.Id, "Direccion", "FolioReal");
            this.Id = contexto.Previstas
                .Where(p => p.IdAbonado == this.Abonado.Id &&
                    p.IdTarifa == this.Tarifa.Id &&
                    p.IdSector == this.Sector.Id)
                .FirstOrDefault()
                .Id;
            Console.WriteLine("Nueva prevista creado con ID: " + Id);
        }

        public void listar()
        {
            List<Prevista> lista = this.previstas.listar();
            foreach (Prevista prevista in lista)
            {
                Console.WriteLine(prevista.Id.ToString());
            }
        }

        public void encontrarPorId()
        {
            Prevista prevista = this.previstas.encontrarPorId(this.Id);
            Console.WriteLine("Prevista encontrada: " + prevista.Id.ToString());
        }

        public void actualizar()
        {
            this.previstas.actualizar(this.Id, 1, 1, 1, "NuevaDireccion", "NuevoFolioReal");
            Console.WriteLine("Prevista actualizada.");
        }

        public void borrar()
        {
            this.previstas.borrar(this.Id);
            Console.WriteLine("Prevista eliminada.");

            this.contexto.Abonados.Remove(this.Abonado);
            this.contexto.Tarifas.Remove(this.Tarifa);
            this.contexto.Sectores.Remove(this.Sector);
            this.contexto.SaveChanges();
        }
    }
}
