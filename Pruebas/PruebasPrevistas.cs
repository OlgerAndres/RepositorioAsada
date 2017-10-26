using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logica;
using Datos;
using System.Data.Entity.Infrastructure;

namespace Pruebas
{
    class PruebasPrevistas
    {
        private IServiciosPrevistas previstas = new AccionesPrevistas();
        private int Id;

        private ASADAEntidades contexto = new ASADAEntidades();
        private Abonado Abonado;
        private Tarifa Tarifa;
        private Sector Sector;

        public void ejecutar()
        {
            this.Abonado = new Abonado { 
                Nombre = "AbonadoY",
                PrimerApellido = "Apellido1",
                SegundoApellido = "Apellido2",
                Cedula = "CedulaY",
                Telefono = "TelefonoY",
                Direccion = "DireccionY",
                NumeroAbonado = "NumeroAbonadoY",
                Afiliado = true
            };
            this.contexto.Abonados.Add(this.Abonado);

            this.Tarifa = new Tarifa {
                Descripcion = "Descripcion Tarifa Y" ,
                Precio = 0
            };
            this.contexto.Tarifas.Add(this.Tarifa);
            
            this.Sector = new Sector { Descripcion = "Descripcion Sector Y" };
            this.contexto.Sectores.Add(this.Sector);

            this.contexto.SaveChanges();

            this.agregar();
            this.listar();
            this.encontrarPorId();
            this.actualizar();
            this.borrar();

            this.contexto.Abonados.Remove(this.Abonado);
            this.contexto.Tarifas.Remove(this.Tarifa);
            this.contexto.Sectores.Remove(this.Sector);

            try
            {
                this.contexto.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Update the values of the entity that failed to save from the store 
                ex.Entries.Single().Reload();
                this.contexto.SaveChanges();
            } 
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
            this.previstas.actualizar(this.Id, this.Abonado.Id, this.Tarifa.Id, this.Sector.Id, "NuevaDireccion", "NuevoFolioReal");
            Console.WriteLine("Prevista actualizada.");
        }

        public void borrar()
        {
            this.previstas.borrar(this.Id);
            Console.WriteLine("Prevista eliminada.");
        }
    }
}
