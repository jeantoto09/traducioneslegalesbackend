using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TraduccionesLegales.WebApi.Models
{
    public class Proyecto
    {
        
        public int ProyectoId { get; set; }
        public Pais IdiomaOriginDePais { get; set; }
        public Pais IdiomaDestinoDePais { get; set; }

        [Column(TypeName = nameof(System.Data.SqlDbType.Binary))]
        public Byte[] Archivo { get; set; }

        public String Instrucciones { get; set; }

        public Boolean Pagado { get; set; }
        public Estado Estado { get; set; }

        public Usuario Usuario { get; set; }
    }
}
