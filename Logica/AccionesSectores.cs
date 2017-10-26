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
        List<Sectore> listar();
        Sectore encontrarPorId(int Id);
        void agregar(string Descripcion);
        void actualizar(int Id, string Descripcion);
        void borrar(int Id);
    }

    public class AccionesSectores : AccionesEntidades, IServiciosSectores 
    {
        public List<Sectore> listar()
        {
            return this.contexto.Sectores.ToList();
        }

        public Sectore encontrarPorId(int Id)
        {
            return this.contexto.Sectores.Where(s => s.Id == Id).FirstOrDefault();
        }

        public void agregar(string Descripcion)
        {
            this.contexto.Sectores.Add(new Sectore 
            {
                Descripcion = Descripcion
            });
            this.contexto.SaveChanges();
        }

        public void actualizar(int Id, string Descripcion)
        {
            Sectore sector = this.encontrarPorId(Id);
            sector.Descripcion = Descripcion;
            this.contexto.SaveChanges();
        }

        public void borrar(int Id)
        {
            this.contexto.SaveChanges();
        }
    }
}
