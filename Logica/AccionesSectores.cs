using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public interface IServiciosSectores
    {
        List<Sector> listar();
        Sector encontrarPorId(int Id);
        void agregar(string Descripcion);
        void actualizar(int Id, string Descripcion);
        void borrar(int Id);
    }

    public class AccionesSectores : AccionesEntidades, IServiciosSectores 
    {
        public List<Sector> listar()
        {
            return this.contexto.Sectores.ToList();
        }

        public Sector encontrarPorId(int Id)
        {
            return this.contexto.Sectores.Where(s => s.Id == Id).FirstOrDefault();
        }

        public void agregar(string Descripcion)
        {
            this.contexto.Sectores.Add(new Sector 
            {
                Descripcion = Descripcion
            });
            this.contexto.SaveChanges();
        }

        public void actualizar(int Id, string Descripcion)
        {
            Sector sector = this.encontrarPorId(Id);
            sector.Descripcion = Descripcion;
            this.contexto.SaveChanges();
        }

        public void borrar(int Id)
        {
            this.contexto.Sectores.Remove(this.encontrarPorId(Id));
            this.contexto.SaveChanges();
        }
    }
}
