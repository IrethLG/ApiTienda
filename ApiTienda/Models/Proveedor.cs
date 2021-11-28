using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTienda.Models
{
    public class Proveedor
    {
        [Key]

        public int idProveedor
        {
            get; set;
        }
        public string nombre
        {
            get; set;
        }
      
        public string direccion
        {
            get; set;
        }
        public string telefono
        {
            get; set;
        }

        public bool estatus
        {
            get; set;
        }
    }
}
