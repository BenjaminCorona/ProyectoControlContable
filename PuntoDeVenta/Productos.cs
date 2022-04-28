using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta
{
    class Productos
    {
        public int idproducto { get; set; }
        public string detalleproducto { get; set; }
        public double costo { get; set; }
        public double precioventa { get; set; }
        public double preciomayoreo { get; set; }
        public int existencia { get; set; }
        public int exminima { get; set; }
        public int exmaxima { get; set; }
        public string tipoventa { get; set; }


        public string BuscarProductoU()
        {
            string seeku = "select * from mydb.producto where idproducto="+idproducto+"";
            return seeku;
        }
        public string BuscarProductoT()
        {
            string seekt = "select * from mydb.producto";
            return seekt;
        }

        public string ComprarProductoNuevo()
        {
            string buyn = "insert into mydb.producto(idproducto,detalleproducto,costo,precioventa,preciomayoreo,existencia,exminima,exmaxima,tipoventa)VALUES('"+idproducto+"','"+detalleproducto+"','"+costo+"','"+precioventa+"','"+preciomayoreo+"','"+existencia+"','"+exminima+"','"+exmaxima+"','"+tipoventa+"')";
            return buyn;
        }

        public string ComprarProductoExistente()
        {
            string buye="update mydb.producto set existencia= "+existencia+" where (idproducto="+idproducto+")";
            return buye;
        }
    }
}
