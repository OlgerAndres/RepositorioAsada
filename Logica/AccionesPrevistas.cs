using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public interface IServiciosPrevistas
    {
        //Atributos de la clase de previstas
        List<Prevista> listar();
        Prevista encontrarPorId(int Id);
        void agregar(int IdAbonado, int IdTarifa, int IdSector, string Direccion, string FolioReal);
        void actualizar(int Id, int IdAbonado, int IdTarifa, int IdSector, string Direccion, string FolioReal);
        void borrar(int Id);
        int cantidadPrevistasPorIdAbonado(int IdAbonado);
    }

    public class AccionesPrevistas : AccionesEntidades, IServiciosPrevistas
    {
        //Método de obtener todos
        public List<Prevista> listar()
        {
            return this.contexto.Previstas.Include("Abonado").Include("Sectore").Include("Tarifa").ToList();
        }
        //Método de encontrar una prevista
        public Prevista encontrarPorId(int Id)
        {
            return this.contexto.Previstas.Where(p => p.Id == Id).FirstOrDefault();
        }
        //Método de agregar un prevista
        public void agregar(int IdAbonado, int IdTarifa, int IdSector, string Direccion, string FolioReal)
        {
            this.contexto.Previstas.Add(new Prevista 
            {
                IdAbonado = IdAbonado,
                IdTarifa = IdTarifa,
                IdSector = IdSector,
                Direccion = Direccion,
                FolioReal = FolioReal,
            });
            this.contexto.SaveChanges();
        }
        //Método de actualizar una prevista
        public void actualizar(int Id, int IdAbonado, int IdTarifa, int IdSector, string Direccion, string FolioReal)
        {
            Prevista prevista = this.encontrarPorId(Id);
            prevista.IdAbonado = IdAbonado;
            prevista.IdTarifa = IdTarifa;
            prevista.IdSector = IdSector;
            prevista.Direccion = Direccion;
            prevista.FolioReal = FolioReal;
            this.contexto.SaveChanges();
        }
        //Método de borrar una prevista
        public void borrar(int Id)
        {
            this.contexto.Previstas.Remove(this.encontrarPorId(Id));
            this.contexto.SaveChanges();
        }

        //Método de para contar la cantidad de previstas por abonado
        public int cantidadPrevistasPorIdAbonado(int IdAbonado)
        {
            return this.contexto.Previstas.Where(p => p.IdAbonado == IdAbonado).Count();
        }
    }
}
