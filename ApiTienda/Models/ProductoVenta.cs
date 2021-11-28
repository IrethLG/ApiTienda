using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTienda.Models
{
    public class ProductoVenta
    {
        [Key]

        public int idProductoVenta
        {
            get; set;
        }
        public int idProducto
        {
            get; set;
        }
        public int idVenta
        {
            get; set;
        }
        public string nombreProducto
        {
            get; set;
        }
        public int cantidadProducto
        {
            get; set;
        }
        public bool estatus
        {
            get; set;
        }
    }
}
