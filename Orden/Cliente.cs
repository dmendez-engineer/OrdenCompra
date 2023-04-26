using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orden
{
    public class Cliente
    {
        public String Cedula { set; get; }
        public String Telefono { set; get; }
        public String TipoCliente { set; get; }

            
        public Cliente() { }
        public Cliente(string cedula, string telefono, string tipoCliente)
        {
            Cedula = cedula;
            Telefono = telefono;
            TipoCliente = tipoCliente;
        }
    }
}
