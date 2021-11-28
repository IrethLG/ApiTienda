using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTienda.Models
{
    public class ProductoProveedor
    {
        [Key]

        public int idProductoProveedor
        {
            get; set;
        }
      public int idProducto
        {
            get; set;
        }
        public int idProveedor
        {
            get; set;
        }

        public bool estatus
        {
            get; set;
        }
        
    }
}
