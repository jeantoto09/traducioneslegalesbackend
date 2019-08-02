using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TraduccionesLegales.WebApi.Models
{
    public class Login
    {
        [EmailAddress]
        public String Email { get; set; }

        [MinLength(8)]
        public String Contraseña { get; set; }
    }
}
