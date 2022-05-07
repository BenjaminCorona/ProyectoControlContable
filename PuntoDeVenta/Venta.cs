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
    public partial class Venta : Form
    {
        public Venta()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            AbrirBD op = new AbrirBD();
            Productos productos = new Productos();
            if (txtCLAVE.Text.Equals("")) {
                MessageBox.Show("DEBE INTRODUCIR UNA CLAVE ANTES DE BUSCAR", "ERROR", MessageBoxButtons.OK,MessageBoxIcon.Error);
            } else {
                productos.idproducto = Convert.ToInt32(txtCLAVE.Text);
            }
            productos.BuscarProductoU();
            MySqlCommand cmd = new MySqlCommand(productos.BuscarProductoU(), op.conectar());
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                reader.Close();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand seleccionar = new MySqlCommand();
                seleccionar.Connection = op.conectar();
                seleccionar.CommandText = productos.BuscarProductoU();
                adapter.SelectCommand = seleccionar;
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);
                dataGrid.DataSource = tabla;
                
            }
            else
            {
                MessageBox.Show("Producto no encontrado, revise la ID", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGrid.ClearSelection(); 
            
      
        }
    }
}
