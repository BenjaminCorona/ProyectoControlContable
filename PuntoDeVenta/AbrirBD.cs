
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PuntoDeVenta
{
    class AbrirBD
    {
        MySqlConnection connection = new MySqlConnection();
        static string server = "localhost";
        static string puerto = "3306";
        static string usuario = "Enriqlon";
        static string psswd = "1234";
        string conn = "server=" + server + "; port=" + puerto + "; user id=" + usuario + "; password=" + psswd + "; database=mydb;";

        public MySqlConnection conectar()
        {
            try {
                connection.ConnectionString = conn;
                connection.Open();
                MessageBox.Show("Conectado a la base de datos");
            } catch (MySqlException ex) {
                //MessageBox.Show(ex.ToString());
            }
            return connection;
        }        
       

    }
}
