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
            this.Hide();
            Sesion reg = new Sesion();
            reg.Show();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            this.Close();
            Principal reg = new Principal();
            MessageBox.Show("Se registró correctamente");
            reg.Show();
        }
    }
}
