using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orden
{
    public class Factura
    {
        public int CodigoFactura { set; get; }
        public Cliente cliente { set; get; }
        public List<Producto> productos { set; get; }

        public Factura() { }

    }
}
