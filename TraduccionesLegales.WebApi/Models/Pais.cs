using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraduccionesLegales.WebApi.Models
{
    public class Pais
    {
        public int PaisId { get; set; }
        public String NombrePais { get; set; }
        
        public String Idioma { get; set; }
        public IEnumerable<Usuario> Usuarios { get; set; }
    }
}
