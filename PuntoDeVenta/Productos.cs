using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta
{
    class Productos
    {
        //parametros para operaciones de venta
        public int cantidad { get; set; } 
        public double preciou { get; set; }
        public double preciot { get; set; }
        public double descuento { get; set; }
        public string fecha { get; set; }


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

        public string EditarProducto()
        {
            string editProd = "update mydb.producto set detalleproducto = '" + detalleproducto + "', costo = '" + costo + "', " +
                "precioventa = '" + precioventa + "', preciomayoreo = '" + preciomayoreo + "', " +
                "existencia = '" + existencia + "', exminima = '" + exminima + "', " +
                "exmaxima = '" + exmaxima + "', tipoventa = '" + tipoventa + "' where idproducto='" + idproducto + "'";
            return editProd;
            //UPDATE `mydb`.`producto` SET `detalleproducto` = 'Teniz', `costo` = '7', `precioventa` = '36', 
            //`preciomayoreo` = '1', `existencia` = '11', 
            //`exminima` = '9', `exmaxima` = '3', `tipoventa` = 'uni' WHERE(`idproducto` = '5');
        }

        public string ActualizarExistenciaInventario()
         {
             string editex = "update mydb.producto set existencia=existencia-'"+cantidad+"' where idproducto='"+idproducto+"'";
             return editex;
         }


        public string CrearCarrito()
        {
            string creacar = "create temporary table if not exists mydb.carrito(idproducto int not null,detalleproducto varchar(450) not null,cantidad int not null,preciou double not null,descuento double not null,preciot double not null,fecha varchar(45)) ";
            return creacar;
        }

        public string AgregarCarrito()
        {
            string addcar = "insert into mydb.carrito (idproducto, detalleproducto, cantidad, preciou, descuento, preciot, fecha)values ('"+idproducto+"','"+detalleproducto+"','"+cantidad+"','"+preciou+"','"+descuento+"','"+preciot+"','"+fecha+"')";
            return addcar;
        }


        public string AgregarDetalleVenta()
        {
            string adddetail = "insert into mydb.detalleventa (idproducto, detalleproducto, cantidad, preciou, descuento, preciot, fecha)values ('" + idproducto + "','" + detalleproducto + "','" + cantidad + "','" + preciou + "','" + descuento + "','" + preciot + "','" + fecha + "');";
            return adddetail;
        }


        public string VerCarrito()
        {
            string seecar = "select * from mydb.carrito"; 
            return seecar;
        }
    }
}
