using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoDeVenta
{
    public partial class Venta : Form
    {
        public Venta()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirBD op = new AbrirBD();
            op.conectar();

            Productos productos = new Productos();
            productos.idproducto = Convert.ToInt32(txtCLAVE.Text);
            productos.BuscarProductoU();
        }
    }
}
