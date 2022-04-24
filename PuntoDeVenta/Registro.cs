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
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void LblRegistro_Click(object sender, EventArgs e)
        {
            this.Close();
            Sesion reg = new Sesion();
            reg.Show();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            //va a abrir la base de datos

            AbrirBD op = new AbrirBD();
            op.conectar();

            //crea objeto para controlar los movimientos de admin

            Admin ad = new Admin();
            ad.idadmin = Convert.ToInt32(txtID.Text);
            ad.nombre = txtNOMBRE.Text;
            ad.password = txtPASSWORD.Text;
            ad.correo = txtCORREO.Text;

            //va a buscar la id para que no se repita

            MySqlCommand cmd = new MySqlCommand(ad.BuscarAdmin(), op.conectar());
            MySqlDataReader reader = cmd.ExecuteReader();

            //fin de la busqueda            
            //si encuentra a un usuario con esa id se la hace de pedo

            if (reader.Read())
            {
                MessageBox.Show("ID de usuario no disponible, pruebe con otra","",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                reader.Close();
                //si no encuentra la id, entonces lo aggrega al sistema

                MySqlCommand cmd2 = new MySqlCommand(ad.AgregarAdmin(), op.conectar());
                MySqlDataReader reader2 = cmd2.ExecuteReader();
                this.Close();
                Principal reg = new Principal();
                MessageBox.Show("Se registró correctamente");
                reg.Show();
            }




            
        }
    }
}
