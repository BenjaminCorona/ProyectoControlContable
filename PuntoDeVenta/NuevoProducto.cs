using MySql.Data.MySqlClient;
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
    public partial class Nuevo : Form
    {
        public Nuevo()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrirBD op = new AbrirBD();
            op.conectar();

            //despues de abrir mandamos los datos del form a la clase

            Productos p = new Productos();
            p.idproducto = Convert.ToInt32(txtCLAVE.Text);
            p.detalleproducto = txtDETALLE.Text;
            p.costo = Convert.ToDouble(txtCOSTO.Text);
            p.precioventa = Convert.ToDouble(txtPRECIOU.Text);
            p.preciomayoreo = Convert.ToDouble(txtPRECIOM.Text);
            p.existencia = Convert.ToInt32(txtEXISTENCIA.Text);
            p.exminima = Convert.ToInt32(txtEXMI.Text);
            p.exmaxima = Convert.ToInt32(txtEXMA.Text);
            if (radioButton1.Checked) { p.tipoventa = "unitario"; }
            if (radioButton2.Checked) { p.tipoventa = "mayoreo"; }

            //buscamos la id para saber si ya está alojada
            MySqlCommand cmd = new MySqlCommand(p.BuscarProductoU(), op.conectar());
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                MessageBox.Show("ID de producto no disponible, pruebe con otra", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                reader.Close();
                //si no encuentra la id, entonces lo agrega al sistema
                MySqlCommand cmd2 = new MySqlCommand(p.ComprarProductoNuevo(), op.conectar());
                MySqlDataReader reader2 = cmd2.ExecuteReader();
                MessageBox.Show("¡Producto nuevo agregado al inventario!");
                txtCLAVE.Clear();

                txtCOSTO.Clear();
                txtDETALLE.Clear();
                txtEXISTENCIA.Clear();
                txtEXMA.Clear();
                txtEXMI.Clear();
                txtPRECIOM.Clear();
                txtPRECIOU.Clear();
                radioButton1.Checked = false;
                radioButton2.Checked = false;
            }
            
                //
            }
        }
}
