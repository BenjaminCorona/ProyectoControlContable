using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta
{
    class Admin
    {
        public int idadmin { get; set; }
        public string nombre { get; set; }
        public string password { get; set; }
        public string correo { get; set; }

        public string AgregarAdmin() {
            string register = "insert into mydb.admin(idadmin,nombre,password,correo)VALUES('"+idadmin+"','"+nombre+"','"+password+"','"+correo+"')";
            return register;
        }

        public string BuscarAdmin()
        {
            string seek = "select * from mydb.admin where idadmin="+idadmin+"";
            return seek;
        }
        public string EliminarAdmin()
        {
            string delete = "";
            return delete;
        }
    }
}
