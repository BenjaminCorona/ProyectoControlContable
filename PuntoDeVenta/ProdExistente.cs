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

        public ProdExistente()
        {
            InitializeComponent();
        }

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
            {
                MessageBox.Show("Errox");
            }

        }

        private void HabilitarBotones()
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            prod.idproducto = Convert.ToInt32(txtID.Text);
            MySqlCommand cmd = new MySqlCommand(prod.BuscarProductoT(), op.conectar());
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                reader.Close();
                MySqlCommand cmd2 = new MySqlCommand(prod.BuscarProductoU(), op.conectar());
                MySqlDataReader reader2 = cmd2.ExecuteReader();
                reader2.Close();
            }
            else
            {
                MessageBox.Show("No existe el producto", "X", MessageBoxButtons.OK, MessageBoxIcon.Error);
                reader.Close();
            }
        }
    }
}
