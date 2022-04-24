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


        public void comprar() { }
        public void vender() { }
        public void actualizar() { }
        public void buscarpp() { }
        public void buscart() { }
    }
}
