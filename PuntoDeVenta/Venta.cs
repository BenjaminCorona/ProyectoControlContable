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
        bool carrito;
        public Venta()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            AbrirBD op = new AbrirBD();
            Productos productos = new Productos();


            if (txtCLAVE.Text.Equals(""))
            {
                MessageBox.Show("DEBE INTRODUCIR UNA CLAVE ANTES DE BUSCAR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
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
                double precio = (Convert.ToDouble(reader.GetValue(3))) * cantidad;
                double preciot = precio - (descuento * ((precio) / 100));
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
               // MessageBox.Show("Aqui no llega");
            }
        }
        //AGREGAR A DETALLE VENTA DE ONE
        private void button2_Click(object sender, EventArgs e)
        {
            int cantidad = Convert.ToInt32(txtCANTIDAD.Text);
            double descuento = Convert.ToDouble(txtDESCUENTO.Text);
            double precio = 0;
            double preciot = 0;
            AbrirBD op = new AbrirBD();
            Productos productos = new Productos();
            //Busca de nuevo el producto:C
            productos.idproducto = Convert.ToInt32(txtCLAVE.Text);
            productos.BuscarProductoU();

            MySqlCommand cmd = new MySqlCommand(productos.BuscarProductoU(), op.conectar());
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {

                precio = (Convert.ToDouble(reader.GetValue(3))) * cantidad;
                preciot = precio - (descuento * ((precio) / 100));
                reader.Close();
            }
            else
            {
                reader.Close();
            }


            try
            {
                MySqlCommand cmd4 = new MySqlCommand(productos.BuscarCarrito(), op.conectar());
                cmd4.ExecuteNonQuery();
                if (cmd4.ExecuteNonQuery()!=0)
                {
                    carrito = true;
                    cmd4.Dispose();
                    productos.idproducto = Convert.ToInt32(txtCLAVE.Text);
                    productos.preciou = precio;
                    productos.detalleproducto = lblDETALLE.Text;
                    productos.preciot = preciot;
                    productos.cantidad = cantidad;
                    productos.fecha = txtFECHA.Text;
                    productos.descuento = Convert.ToDouble(txtDESCUENTO.Text);

                    MySqlCommand cmd5 = new MySqlCommand(productos.AgregarCarrito(), op.conectar());
                    MySqlDataReader reader3 = cmd5.ExecuteReader();

                    if (reader3.Read())
                    {
                        reader3.Close();

                    }
                    cmd5.Dispose();
                    reader3.Close();

                    MySqlCommand cmda = new MySqlCommand(productos.AgregarDetalleVenta(), op.conectar());
                    MySqlDataReader readera = cmda.ExecuteReader();
                    if (readera.Read())
                    {
                    }
                    readera.Close();

                    productos.idproducto = Convert.ToInt32(txtCLAVE.Text);
                    productos.cantidad = Convert.ToInt32(txtCANTIDAD.Text);

                    //ACTUALIZAR EXISTENCIA
                    MySqlCommand cm6 = new MySqlCommand(productos.ActualizarExistenciaInventario(), op.conectar());
                    MySqlDataReader readerac = cm6.ExecuteReader();
                    readerac.Read();
                    readerac.Close();


                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    MySqlCommand seleccionar = new MySqlCommand();
                    seleccionar.Connection = op.conectar();
                    seleccionar.CommandText = productos.VerCarrito();
                    adapter.SelectCommand = seleccionar;
                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);
                    dataGrid2.DataSource = tabla;


                }
            }
            catch (MySqlException ex) { 

                carrito = false;
              
                Productos productos2 = new Productos();
                MySqlCommand cmd2 = new MySqlCommand("drop table if exists mydb.carrito;", op.conectar());
                MySqlCommand cmd3 = new MySqlCommand(productos.CrearCarrito(), op.conectar());


                if (cmd2.ExecuteNonQuery() == 0 && cmd3.ExecuteNonQuery() == 0)
                {
                    productos.idproducto = Convert.ToInt32(txtCLAVE.Text);
                    productos.preciou = precio;
                    productos.detalleproducto = lblDETALLE.Text;
                    productos.preciot = preciot;
                    productos.cantidad = cantidad;
                    productos.fecha = txtFECHA.Text;
                    productos.descuento = Convert.ToDouble(txtDESCUENTO.Text);


                    cmd2.Dispose();
                    cmd3.Dispose();

                    MySqlCommand cmda = new MySqlCommand(productos.AgregarDetalleVenta(),op.conectar());
                    MySqlDataReader readera = cmda.ExecuteReader();
                    if (readera.Read())
                    {
                    }
                    readera.Close();
                    productos.idproducto = Convert.ToInt32(txtCLAVE.Text);
                    productos.cantidad = Convert.ToInt32(txtCANTIDAD.Text);

                    //ACTUALIZAR EXISTENCIA
                    MySqlCommand cm6 = new MySqlCommand(productos.ActualizarExistenciaInventario(), op.conectar());
                    MySqlDataReader readerac = cm6.ExecuteReader();
                    readerac.Read();
                    readerac.Close();


                    MySqlCommand cmd5 = new MySqlCommand(productos.AgregarCarrito(), op.conectar());
                    MySqlDataReader reader3 = cmd5.ExecuteReader();

                    if (reader3.Read())
                    {
                        reader3.Close();

                    }
                    cmd5.Dispose();
                    reader3.Close();
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
                }

            }
            
            
            

            //MySqlDataAdapter adapter = new MySqlDataAdapter();
            //MySqlCommand seleccionar = new MySqlCommand();
            //seleccionar.Connection = op.conectar();
            //seleccionar.CommandText = productos.VerCarrito();
            //adapter.SelectCommand = seleccionar;
            //DataTable tabla = new DataTable();
            //adapter.Fill(tabla);
            //dataGrid2.DataSource = tabla;

            if (button4.Enabled == false)
            {
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
            txtFECHA.Text = "DD-MM-AAAA";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Productos p = new Productos();
            AbrirBD op = new AbrirBD();
            //MySqlCommand cmd = new MySqlCommand(p.AgregarDetalleVenta(),op.conectar());
            //MySqlDataReader reader = cmd.ExecuteReader();

            //if (reader.Read())
            //{
            //    reader.Close();
              //  MessageBox.Show("Vendido correctamente");

                MySqlCommand cmd2 = new MySqlCommand(p.EliminarCarrito(), op.conectar());
                MySqlDataReader reader2 = cmd2.ExecuteReader();
            dataGrid2.DataSource = null;
            dataGrid2.ClearSelection();
            reader2.Read();
                
                    //MessageBox.Show("Carrito eliminado");
                
            //}


        }
    }

}
