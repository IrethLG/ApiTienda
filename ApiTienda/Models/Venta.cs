using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTienda.Models
{
    public class Venta
    {
        [Key]

        public int idVenta
        {
            get; set;
        }
        public decimal cantidad
        {
            get; set;
        }
        public DateTime fecha
        {
            get; set;
        }

        

        public bool estatus
        {
            get; set;
        }
        public int idEmpleado
        {
            get; set;
        }
        public int idCliente
        {
            get; set;
        }
    }
}
