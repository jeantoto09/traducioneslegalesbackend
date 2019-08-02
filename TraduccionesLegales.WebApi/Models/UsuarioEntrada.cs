using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TraduccionesLegales.WebApi.Utilidades;

namespace TraduccionesLegales.WebApi.Models
{
    public class UsuarioEntrada
    {
        [EmailAddress]
        public String Email { get; set; }

        [MinLength(8)]
        public String Contraseña { get; set; }

        [Compare(nameof(Contraseña))]
        [NotMapped]
        public String ConfirmarContraseña { get; set; }

        public Pais Pais { get; set; }

        public String Nombre { get; set; }

        public String Apellido { get; set; }

        public String NumeroDeTelefono { get; set; }

        public String NombreDeCompañia { get; set; }

        public TipoDeUsuario TipoDeUsuario { get; set; }

        public ICollection<ProyectoEntrada> Proyectos { get; set; }
    }
}
