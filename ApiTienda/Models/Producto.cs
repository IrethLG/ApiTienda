using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTienda.Models
{
    public class Producto
    {
        [Key]

        public int idProducto
        {
            get; set;
        }
        public string nombre
        {
            get; set;
        }

        public string categoria
        {
            get; set;
        }
        public string descripccion
        {
            get; set;
        }
        public decimal precio
        {
            get; set;
        }
        public int cantidadStock
        {
            get; set;
        }
        public string marca
        {
            get; set;
        }

        public bool estatus
        {
            get; set;
        }
    }
}
