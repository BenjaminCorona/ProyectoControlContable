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
                //obtenemos valores como variables por medio del reader
                lblDETALLE.Text = reader.GetValue(1).ToString();
                lblPRECIOU.Text = reader.GetValue(3).ToString();
                lblPRECIOM.Text = reader.GetValue(4).ToString();

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


        //BOTÓN PARA OPERAR ANTES DE INGRESAR AL CARRITO
        private void button4_Click(object sender, EventArgs e)
        {
            

            if (button2.Enabled == false)
            {
                button4.Enabled = false;
                button2.Enabled = true;
            }

            int cantidad = Convert.ToInt32(txtCANTIDAD.Text);
            double descuento = Convert.ToDouble(txtDESCUENTO.Text);

            AbrirBD op = new AbrirBD();
            Productos productos = new Productos();
            productos.idproducto = Convert.ToInt32(txtCLAVE.Text);
            productos.BuscarProductoU();

            MySqlCommand cmd = new MySqlCommand(productos.BuscarProductoU(), op.conectar());
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                //obtenemos valores como variables por medio del reader
                double  precio= (Convert.ToDouble(reader.GetValue(3)))*cantidad;
                double preciot = precio-(descuento * ((precio)/100));
             //   MessageBox.Show("Aqui llega");
                txtPRECIOT.Text = preciot.ToString();
                txtPRECIOU.Text = precio.ToString();

                productos.preciou = precio;
                productos.preciot = preciot;
                productos.cantidad = cantidad;
                productos.fecha = txtFECHA.Text;

                reader.Close();
            }
            else
            {
                MessageBox.Show("Aqui no llega");
            }



            



            }

        private void button2_Click(object sender, EventArgs e)
        {
            int cantidad = Convert.ToInt32(txtCANTIDAD.Text);
            double descuento = Convert.ToDouble(txtDESCUENTO.Text);
            double precio = 0;
            double preciot = 0;
            //BOTON PARA AGREGAR AL CARRITO
            AbrirBD op = new AbrirBD();
            Productos productos = new Productos();
            //Busca de nuevo el producto:C
            productos.idproducto = Convert.ToInt32(txtCLAVE.Text);
            productos.BuscarProductoU();
          
            MySqlCommand cmd = new MySqlCommand(productos.BuscarProductoU(), op.conectar());
            MySqlDataReader reader = cmd.ExecuteReader();
            
            if (reader.Read())
            {
                
                //obtenemos valores como variables por medio del reader
                 precio = (Convert.ToDouble(reader.GetValue(3))) * cantidad;
                 preciot = precio - (descuento * ((precio) / 100));
                reader.Close();
            }
            else
            {
                reader.Close();
                MessageBox.Show("antes de crear el carrito, no busca el producto");
            }

            //CREAMOS EL CARRITO
            AbrirBD op2 = new AbrirBD();
            Productos productos2 = new Productos();
            productos2.CrearCarrito();
            productos2.idproducto = Convert.ToInt32(txtCLAVE.Text);
            productos2.preciou = precio;
            productos2.detalleproducto = lblDETALLE.Text;
            productos2.preciot = preciot;
            productos2.cantidad = cantidad;
            productos2.fecha = txtFECHA.Text;
            productos2.descuento = descuento;            
            MySqlCommand cmd2 = new MySqlCommand(productos2.CrearCarrito(), op2.conectar());
            MySqlDataReader reader2 = cmd2.ExecuteReader();

            if (reader2.Read()) {
                MessageBox.Show("se creó el carrito");
                reader2.Close();
                MySqlCommand cmd3 = new MySqlCommand(productos.AgregarCarrito(), op.conectar());
                MySqlDataReader reader3 = cmd3.ExecuteReader();

                if (reader3.Read())
                {
                    MessageBox.Show("Se agregó al carrito:)");  
                    reader3.Close();


                    //MOSTRAR CARRITO EN EL SEGUNDO DATAGRID
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    MySqlCommand seleccionar = new MySqlCommand();
                    seleccionar.Connection = op.conectar();
                    seleccionar.CommandText = productos.VerCarrito();
                    adapter.SelectCommand = seleccionar;
                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);
                    dataGrid2.DataSource = tabla;


                }
                else
                {
                    MessageBox.Show("No se agregó al carrito:)");
                    reader3.Close();
                }


            }
            else {
                reader2.Close();
                MessageBox.Show("No se creó el carrito");
                    }
            

                if (button4.Enabled==false) {
                button4.Enabled = true;
                button2.Enabled = false;
            }

            
            

            //LIMPIAMOS EL DATAGRID
            dataGrid.DataSource = null;
            dataGrid.ClearSelection();

            txtCANTIDAD.Clear();
            txtCLAVE.Clear();
            txtDESCUENTO.Clear();
            txtPRECIOT.Clear();
            txtPRECIOU.Clear();
            lblDETALLE.Text = "";
            lblPRECIOM.Text = "0.00";
            lblPRECIOU.Text = "0.00";

            

        }

       
    }

}
