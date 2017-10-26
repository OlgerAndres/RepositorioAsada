using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pruebas
{
    class Pruebas
    {
        static void Main(string[] args)
        {
            new PruebasAbonados().ejecutar();
            new PruebasPrevistas().ejecutar();
            new PruebasSectores().ejecutar();
            new PruebasTarifas().ejecutar();
            new UsuariosPruebas().ejecutar();
            Console.ReadKey();
        }
    }
}
