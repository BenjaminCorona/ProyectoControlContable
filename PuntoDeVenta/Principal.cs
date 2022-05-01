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
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Venta v = new Venta();
            v.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button5.Enabled) {
                button5.Enabled = false;
                button6.Enabled = false;
            }
            else
            {
                button5.Enabled = true;
                button6.Enabled = true;
            }

            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Nuevo cnp = new Nuevo();
            cnp.Show();
        }


        private void btnAProv_Click(object sender, EventArgs e)
        {
            AdminProv aProv = new AdminProv();
            aProv.Show();
        }
    }
}
