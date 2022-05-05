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
    public partial class AdminProv : Form
    {
        AbrirBD op = new AbrirBD();
        Proveedores prov = new Proveedores();
        
        private void CargarTabla()
        {
            MySqlCommand cmd = new MySqlCommand(prov.BuscaTodosProv(), op.conectar());
            MySqlDataReader readertabla = cmd.ExecuteReader();
            if (readertabla.Read())
            {
                readertabla.Close();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand seleccionar = new MySqlCommand();
                seleccionar.Connection = op.conectar();
                seleccionar.CommandText = prov.BuscaTodosProv();
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
            btnDelProv.Enabled = false;
            btnAddProv.Enabled = false;
            btnEditProv.Enabled = false;

        }


        public AdminProv()
        {
            InitializeComponent();
            prov.BuscaTodosProv();
            CargarTabla();
            
        }

        

        
        private void btnAddProv_Click(object sender, EventArgs e)
        {
            
            prov.idproveedor = Convert.ToInt32(txtID.Text);
            prov.detalleproveedor = txtNOM.Text;
            MySqlCommand cmd = new MySqlCommand(prov.BuscarProveedor(), op.conectar());
            MySqlDataReader reader = cmd.ExecuteReader();
            
            if (reader.Read())
            {
                MessageBox.Show("Ya existe esta id de proveedor", "X", MessageBoxButtons.OK, MessageBoxIcon.Error);
                reader.Close();
            }
            else
            {
                reader.Close();
                MySqlCommand cmd2 = new MySqlCommand(prov.AgregarProveedor(), op.conectar());
                MySqlDataReader reader2 = cmd2.ExecuteReader();
                MessageBox.Show("¡Proveedor nuevo agregado ","X", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtID.Clear();
                txtNOM.Clear();
                reader2.Close();
            }
            CargarTabla();
        }

        private void btnEditProv_Click(object sender, EventArgs e)
        {
            prov.idproveedor = Convert.ToInt32(txtID.Text);
            prov.detalleproveedor = txtNOM.Text;
            MySqlCommand cmd = new MySqlCommand(prov.BuscarProveedor(), op.conectar());
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                reader.Close();
                MySqlCommand cmd2 = new MySqlCommand(prov.EditarProveedor(), op.conectar());
                MySqlDataReader reader2 = cmd2.ExecuteReader();
                MessageBox.Show("¡Editaste proveedor!", "X", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtID.Clear();
                txtNOM.Clear();
                reader2.Close();
            }
            else
            {
                MessageBox.Show("No existe el proveedor", "X", MessageBoxButtons.OK, MessageBoxIcon.Error);
                reader.Close();
            }
            CargarTabla();
        }

        private void txtID_TextChanged(object sender, EventArgs e)  { }

        private void btnDelProv_Click(object sender, EventArgs e)
        {
            prov.idproveedor = Convert.ToInt32(txtID.Text);
            prov.detalleproveedor = txtNOM.Text;
            MySqlCommand cmd = new MySqlCommand(prov.BuscarProveedor(), op.conectar());
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                reader.Close();
                MySqlCommand cmd2 = new MySqlCommand(prov.BorrarProveedor(), op.conectar());
                try {
                    MySqlDataReader reader2 = cmd2.ExecuteReader();
                    MessageBox.Show("¡Borraste proveedor!", "X", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reader2.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("El proveedor que se quiere borrar tiene actualmente producto en stock", "X", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                txtID.Clear();
                txtNOM.Clear();

            }
            else
            {
                MessageBox.Show("No existe el proveedor", "X", MessageBoxButtons.OK, MessageBoxIcon.Error);
                reader.Close();
            }
            CargarTabla();
        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if(txtID.Text != null)
            {
                btnEditProv.Enabled = true;
                btnAddProv.Enabled = true;
                btnDelProv.Enabled = true;
            }else
            {
                btnEditProv.Enabled = false;
                btnAddProv.Enabled = false;
                btnDelProv.Enabled = false;
            }
        }

        private void txtNOM_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
