﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    //Atributos de la clase de abonados
    public interface IServiciosAbonados
    {
        List<Abonado> listar();
        Abonado encontrarPorId(int Id);
        void agregar(string Nombre, string PrimerApellido, string SegundoApellido, string Cedula, string Telefono, string Celular, string Direccion, string Correo, string NumberoAbonado, bool Afiliado);
        void actualizar(int Id, string Nombre, string PrimerApellido, string SegundoApellido, string Cedula, string Telefono, string Celular, string Direccion, string Correo, string NumberoAbonado, bool Afiliado);
        void borrar(int Id);
    }

    public class AccionesAbonados : AccionesEntidades, IServiciosAbonados
    {
        //Metodo de obtener todos 
        public List<Abonado> listar()
        {
            return this.contexto.Abonados.ToList();
        }
        //Encotrar por aboanado
        public Abonado encontrarPorId(int Id)
        {
            return this.contexto.Abonados.Where(a => a.Id == Id).FirstOrDefault();
        }
        //Meotodo de agregar un abonado
        public void agregar(string Nombre, string PrimerApellido, string SegundoApellido, string Cedula, string Telefono, string Celular, string Direccion, string Correo, string NumberoAbonado, bool Afiliado)
        {
            this.contexto.Abonados.Add(new Abonado 
            {
                Nombre = Nombre,
                PrimerApellido = PrimerApellido,
                SegundoApellido = SegundoApellido,
                Cedula = Cedula,
                Telefono = Telefono,
                Celular = Celular,
                Direccion = Direccion,
                Correo = Correo,
                NumeroAbonado = NumberoAbonado,
                Afiliado = Afiliado
            });
            this.contexto.SaveChanges();
        }
        //Metodo de actualizar un abonado
        public void actualizar(int Id, string Nombre, string PrimerApellido, string SegundoApellido, string Cedula, string Telefono, string Celular, string Direccion, string Correo, string NumberoAbonado, bool Afiliado)
        {
            Abonado abonado = this.encontrarPorId(Id);
            abonado.Nombre = Nombre;
            abonado.PrimerApellido = PrimerApellido;
            abonado.SegundoApellido = SegundoApellido;
            abonado.Cedula = Cedula;
            abonado.Telefono = Telefono;
            abonado.Celular = Celular;
            abonado.Direccion = Direccion;
            abonado.Correo = Correo;
            abonado.NumeroAbonado = NumberoAbonado;
            abonado.Afiliado = Afiliado;
            this.contexto.SaveChanges();
        }
        //Metodo de borrar un abonado
        public void borrar(int Id)
        {
            this.contexto.Abonados.Remove(this.encontrarPorId(Id));
            this.contexto.SaveChanges();
        }
    }
}
