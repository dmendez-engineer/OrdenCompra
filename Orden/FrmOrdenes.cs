using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orden
{
    public partial class FrmOrdenes : Form
    {
        public FrmOrdenes()
        {
            InitializeComponent();
        }
        List<Producto> listaProducto = new List<Producto>();
        List<Producto> productosSeleccioandos = new List<Producto>();
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            double totalPagar = 0;
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                totalPagar += Double.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
            }
            txtTotalPagar.Text = totalPagar.ToString();

            String cedula = mskCedula.Text;
            String numero = mskTelefono.Text;
            String tipoCliente;
            if (radioButton1.Checked)
            {
                tipoCliente = radioButton1.Text;
            }
            else
            {
                tipoCliente = radioButton2.Text;
            }

            Cliente c = new Cliente(cedula,numero,tipoCliente);
            int orden = Int32.Parse(txtOrden.Text);
            Factura f1 = new Factura();
            f1.cliente = c;
            f1.productos = productosSeleccioandos;
            f1.CodigoFactura = orden;
            

            rtbResumen.Text = "Detalle de la factura numero: "+f1.CodigoFactura+ "\n" + "Cliente: "+f1.cliente.Cedula+ "\n";

            foreach (var p in f1.productos)
            {
                rtbResumen.AppendText(p.Name+ "\n");
            }
            rtbResumen.AppendText("Total: " + totalPagar);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int indiceProducto=cboProductos.SelectedIndex;
            Producto pSeleccionado;
            pSeleccionado=this.listaProducto.Find(p=>p.Codigo==indiceProducto);
            String cantidad = nudCantidad.Value.ToString();
            productosSeleccioandos.Add(pSeleccionado);

            int numeroFilas = dataGridView1.Rows.Add();

            dataGridView1.Rows[numeroFilas].Cells[0].Value = pSeleccionado.Codigo+1;
            dataGridView1.Rows[numeroFilas].Cells[1].Value = pSeleccionado.Name;
            dataGridView1.Rows[numeroFilas].Cells[2].Value = pSeleccionado.Precio;
            dataGridView1.Rows[numeroFilas].Cells[3].Value = cantidad;
            dataGridView1.Rows[numeroFilas].Cells[4].Value = pSeleccionado.Precio*Double.Parse(cantidad);//Subtotal
            dataGridView1.Rows[numeroFilas].Cells[5].Value = pSeleccionado.TipoProducto;//Tipo producto

            
        }

        private void FrmOrdenes_Load(object sender, EventArgs e)
        {
            

            listaProducto.Add(new Producto("Galletas", 500,"Harina"));
            listaProducto.Add(new Producto("Pan", 1500, "Harina"));
            listaProducto.Add(new Producto("Leche", 2500,"Lacteos"));

            foreach (Producto p in listaProducto)
            {
                cboProductos.Items.Add(p.Name);
            }

        }
    }
}
