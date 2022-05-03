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
        
        public AdminProv()
        {
            InitializeComponent();
            
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
            }
            else
            {
                reader.Close();
                MySqlCommand cmd2 = new MySqlCommand(prov.AgregarProveedor(), op.conectar());
                MySqlDataReader reader2 = cmd2.ExecuteReader();
                MessageBox.Show("¡Proveedor nuevo agregado al inventario!","X", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtID.Clear();
                txtNOM.Clear();
            }
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
            }
            else
            {

                MessageBox.Show("No existe el proveedor", "X", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if(txtID.Text == "")
            {
                btnEditProv.Enabled = true;
                btnAddProv.Enabled = true;
                btnDelProv.Enabled = true;
            }
        }

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
                MySqlDataReader reader2 = cmd2.ExecuteReader();
                MessageBox.Show("¡Borraste proveedor!", "X", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtID.Clear();
                txtNOM.Clear();
            }
            else
            {

                MessageBox.Show("No existe el proveedor", "X", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
