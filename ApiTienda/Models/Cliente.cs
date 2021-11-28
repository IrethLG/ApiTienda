using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTienda.Models
{
    public class Cliente
    {
        [Key]

        public int idCliente
        {
            get; set;
        }
        public string nombre
        {
            get; set;
        }
        public string apellidoP
        {
            get; set;
        }
        public string apellidoM
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
