using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PuntoDeVenta
{
    public partial class ProdExistente : Form
    {
        AbrirBD op = new AbrirBD();
        Productos prod = new Productos();

        private void CargarTabla()
        {
            MySqlCommand cmd = new MySqlCommand(prod.BuscarProductoT(), op.conectar());
            MySqlDataReader readertabla = cmd.ExecuteReader();
            if (readertabla.Read())
            {
                readertabla.Close();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand seleccionar = new MySqlCommand();
                seleccionar.Connection = op.conectar();
                seleccionar.CommandText = prod.BuscarProductoT();
                adapter.SelectCommand = seleccionar;
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);
                dataGridView1.DataSource = tabla;
                readertabla.Close();
            }
            else
            { MessageBox.Show("Errox"); }

        }

        public ProdExistente()
        {
            InitializeComponent();
            CargarTabla();
        }



        private void HabilitarBotones()
        {
            txtDETALLE.Enabled = true;
            txtCOSTO.Enabled = true;
            txtPRECIOU.Enabled = true;
            txtPRECIOM.Enabled = true;
            txtEXISTENCIA.Enabled = true;
            txtEXMI.Enabled = true;
            txtEXMA.Enabled = true;
            button1.Enabled = true;
            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
        }

        private void DesabilitarBotones()
        {
            txtDETALLE.Enabled = false;
            txtCOSTO.Enabled = false;
            txtPRECIOU.Enabled = false;
            txtPRECIOM.Enabled = false;
            txtEXISTENCIA.Enabled = false;
            txtEXMI.Enabled = false;
            txtEXMA.Enabled = false;
            button1.Enabled = false;
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            //---
            txtID.Text = "";
            txtDETALLE.Text = "";
            txtCOSTO.Text = "";
            txtPRECIOU.Text = "";
            txtPRECIOM.Text = "";
            txtEXISTENCIA.Text = "";
            txtEXMI.Text = "";
            txtEXMA.Text = "";
            button1.Enabled = false;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            prod.idproducto = Convert.ToInt32(txtID.Text);
            MySqlCommand cmd = new MySqlCommand(prod.BuscarProductoU(), op.conectar());
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                HabilitarBotones();
                txtDETALLE.Text = reader["detalleproducto"].ToString();
                txtCOSTO.Text = reader["costo"].ToString();
                txtPRECIOU.Text = reader["precioventa"].ToString();
                txtPRECIOM.Text = reader["preciomayoreo"].ToString();
                txtEXISTENCIA.Text = reader["existencia"].ToString();
                txtEXMI.Text = reader["exminima"].ToString();
                txtEXMA.Text = reader["exmaxima"].ToString();
                if (reader["tipoventa"].ToString() == "unitario")
                {
                    radioButton1.Checked = true;
                }
                else { radioButton2.Checked = true; }
                reader.Close();
            }
            else
            {
                MessageBox.Show("No existe el producto", "X", MessageBoxButtons.OK, MessageBoxIcon.Error);
                reader.Close();
            }
        }

       

        private void button1_Click_1(object sender, EventArgs e)
        {
            prod.idproducto = Convert.ToInt32(txtID.Text);
            prod.detalleproducto = txtDETALLE.Text;
            prod.costo = Convert.ToDouble(txtCOSTO.Text);
            prod.precioventa = Convert.ToDouble(txtPRECIOU.Text);
            prod.preciomayoreo = Convert.ToDouble(txtPRECIOM.Text);
            prod.existencia = Convert.ToInt32(txtEXISTENCIA.Text);
            prod.exmaxima = Convert.ToInt32(txtEXMA.Text);
            prod.exminima = Convert.ToInt32(txtEXMI.Text);
            if (radioButton1.Checked == true)
            {
                prod.tipoventa = radioButton1.Text.ToLower();
            }
            else { prod.tipoventa = radioButton2.Text.ToLower(); }


            MySqlCommand cmd = new MySqlCommand(prod.BuscarProductoT(), op.conectar());
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                reader.Close();
                MySqlCommand cmd2 = new MySqlCommand(prod.EditarProducto(), op.conectar());
                MySqlDataReader reader2 = cmd2.ExecuteReader();
                MessageBox.Show("¡Editaste el producto!", "X", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reader2.Close();
                DesabilitarBotones();
            }
            else
            {
                MessageBox.Show("No existe el producto", "X", MessageBoxButtons.OK, MessageBoxIcon.Error);
                reader.Close();
            }
            CargarTabla();
        }
    }
}
