using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraduccionesLegales.WebApi.Models
{
    public class ProyectoEntrada 
    {
        public int ProyectoId { get; set; }
        public Pais IdiomaOriginDePais { get; set; }
        public Pais IdiomaDestinoDePais { get; set; }

        public IFormFile Archivo { get; set; }

        public Byte[] GetArchivoBytes()
        {
            var File = new System.IO.MemoryStream();
            Archivo.CopyTo(File);
            return File.GetBuffer();
        }

        public String Instrucciones { get; set; }

        public Boolean Pagado { get; set; }
        public Estado Estado { get; set; }

        public String Usuario { get; set; }
    }
}
