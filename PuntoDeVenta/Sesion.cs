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
            this.Hide();
            Registro reg = new Registro();
            reg.Show();
        }

        private void BtnIniciar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Principal reg = new Principal();
            reg.Show();
        }
    }
}
