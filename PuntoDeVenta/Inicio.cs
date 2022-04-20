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
    public partial class Inicio : Form
    {
        private int progress = 0;
        public Inicio()
        {
            InitializeComponent();

            timer1.Enabled = true;
            timer1.Start();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progress <= 100)
            {
                progressBar1.Value = progress;
                progress = progress + 10;
            }
            else {
                timer1.Stop();
                timer1.Enabled = false;

                this.Hide();
                Sesion reg = new Sesion();
                reg.Show();
            }
            
        }
    }
}
