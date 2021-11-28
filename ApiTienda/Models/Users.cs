using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTienda.Models
{
    public class Users
    {
        
            [Key]

            public int idUser
        {
                get; set;
            }
            public string UserName
        {
                get; set;
            }
            public byte[] passwd
        {
                get; set;
            }
            public string role
        {
                get; set;
            }
           
            
        }
    
}

