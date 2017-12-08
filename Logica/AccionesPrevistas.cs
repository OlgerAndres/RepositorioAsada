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
        List<Prevista> listar();
        Prevista encontrarPorId(int Id);
        void agregar(int IdAbonado, int IdTarifa, int IdSector, string Direccion, string FolioReal);
        void actualizar(int Id, int IdAbonado, int IdTarifa, int IdSector, string Direccion, string FolioReal);
        void borrar(int Id);
        int cantidadPrevistasPorIdAbonado(int IdAbonado);
    }

    public class AccionesPrevistas : AccionesEntidades, IServiciosPrevistas
    {
        public List<Prevista> listar()
        {
            return this.contexto.Previstas.ToList();
        }

        public Prevista encontrarPorId(int Id)
        {
            return this.contexto.Previstas.Where(p => p.Id == Id).FirstOrDefault();
        }

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

        public void borrar(int Id)
        {
            this.contexto.Previstas.Remove(this.encontrarPorId(Id));
            this.contexto.SaveChanges();
        }


        public int cantidadPrevistasPorIdAbonado(int IdAbonado)
        {
            return this.contexto.Previstas.Where(p => p.IdAbonado == IdAbonado).Count();
        }
    }
}
