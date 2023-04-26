using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orden
{
    public class Producto
    {
        private static int Id { set; get; }
        public String Name { set; get; }
        public double Precio { set; get; }
        public int Codigo { set;get; }
        public String TipoProducto { set; get; }
        public Producto() { }

        public Producto(String name, double precio,string tipo)
        {
            this.Codigo = Producto.ultimoId();
            this.Name = name;
            this.Precio = precio;
            this.TipoProducto = tipo;
        }


        public static int ultimoId()
        {
            return Producto.Id++;
        }
    }
}
