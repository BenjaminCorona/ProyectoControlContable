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
    public partial class Sesion : Form
    {
        public Sesion()
        {
            InitializeComponent();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LblRegistro_Click(object sender, EventArgs e)
        {
            this.Close();
            Registro reg = new Registro();
            reg.Show();
        }

        private void BtnIniciar_Click(object sender, EventArgs e)
        {
        
            AbrirBD op = new AbrirBD();
            op.conectar();
            //inicio de sesion
            string login = "select idadmin,password from admin where idadmin='" + TxtUsuario.Text + "' AND password='" + textBox1.Text + "'";
           
            MySqlCommand cmd = new MySqlCommand(login, op.conectar());
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                this.Close();
                Principal reg = new Principal();
                reg.Show();

                MessageBox.Show("Bienvenido al sistema");
            }
            else
            {
                MessageBox.Show("Error, usuario no encontrado");
            }
            

        }
    }
}
