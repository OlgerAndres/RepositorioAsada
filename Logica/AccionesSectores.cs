using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    //Atributos de la clase de sectores
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
        //Método de obtner todos
        public List<Sector> listar()
        {
            return this.contexto.Sectores.ToList();
        }
        //Método de encontrar un sector
        public Sector encontrarPorId(int Id)
        {
            return this.contexto.Sectores.Where(s => s.Id == Id).FirstOrDefault();
        }

        //Método de agregar un sector
        public void agregar(string Descripcion)
        {
            this.contexto.Sectores.Add(new Sector 
            {
                Descripcion = Descripcion
            });
            this.contexto.SaveChanges();
        }
        //Método de actualizar un sector
        public void actualizar(int Id, string Descripcion)
        {
            Sector sector = this.encontrarPorId(Id);
            sector.Descripcion = Descripcion;
            this.contexto.SaveChanges();
        }
        //Método de borrar una sector
        public void borrar(int Id)
        {
            this.contexto.Sectores.Remove(this.encontrarPorId(Id));
            this.contexto.SaveChanges();
        }
    }
}
