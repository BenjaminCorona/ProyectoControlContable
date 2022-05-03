using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta
{
    class Proveedores
    {
        public int idproveedor { get; set; }
        public string detalleproveedor { get; set; }

        public string BuscarProveedor()
        {
            string bProv = "select * from mydb.proveedor where idproveedor=" + idproveedor + "";
            return bProv;
        }
        public string BuscaTodosProv()
        {
            string bProv = "select * from mydb.proveedor";
            return bProv;
        }
        public string BorrarProveedor()
        {
            string borrProv = "delete from mydb.proveedor where idproveedor=" + idproveedor + "";
            return borrProv;
        }

        public string AgregarProveedor()
        {
            string addProv = "insert into mydb.proveedor(idproveedor,detalleproveedor)VALUES('" + idproveedor + "','" + detalleproveedor +  "')";
            return addProv;
        }
        public string EditarProveedor()
        {
            string editProv = "update mydb.proveedor set detalleproveedor = " + detalleproveedor + "where idproveedor=" + idproveedor + "";
            return editProv;
        }
        //UPDATE `mydb`.`proveedor` SET `detalleproveedor` = 'sNike SA. de CV.' WHERE(`idproveedor` = '1');
    }
}
