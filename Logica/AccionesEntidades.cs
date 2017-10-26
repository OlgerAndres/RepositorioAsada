using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class AccionesEntidades
    {

        protected ASADAEntidades contexto;

        public AccionesEntidades()
        {
            this.contexto = new ASADAEntidades();
        }

    }
}
