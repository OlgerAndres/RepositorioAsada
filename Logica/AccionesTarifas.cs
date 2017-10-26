using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public interface IServiciosTarifas
    {
        List<Tarifa> listar();
        Tarifa encontrarPorId(int Id);
        void agregar(string Descripcion, decimal Precio);
        void actualizar(int Id, string Descripcion, decimal Precio);
        void borrar(int Id);
    }

    public class AccionesTarifas : AccionesEntidades, IServiciosTarifas
    {
        public List<Tarifa> listar()
        {
            return this.contexto.Tarifas.ToList();
        }

        public Tarifa encontrarPorId(int Id)
        {
            return this.contexto.Tarifas.Where(t => t.Id == Id).FirstOrDefault();
        }

        public void agregar(string Descripcion, decimal Precio)
        {
            this.contexto.Tarifas.Add(new Tarifa 
            {
                Descripcion = Descripcion,
                Precio = Precio
            });
            this.contexto.SaveChanges();
        }

        public void actualizar(int Id, string Descripcion, decimal Precio)
        {
            Tarifa tarifa = this.encontrarPorId(Id);
            tarifa.Descripcion = Descripcion;
            tarifa.Precio = Precio;
            this.contexto.SaveChanges();
        }

        public void borrar(int Id)
        {
            this.contexto.Tarifas.Remove(this.encontrarPorId(Id));
            this.contexto.SaveChanges();
        }
    }
}
