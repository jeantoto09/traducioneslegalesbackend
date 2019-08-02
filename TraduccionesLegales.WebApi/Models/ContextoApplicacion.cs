using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraduccionesLegales.WebApi.Models;

namespace TraduccionesLegales.WebApi
{
    public class ContextoApplicacion : DbContext
    {
        public ContextoApplicacion()
        {
        }

        //Constructor con parametros para la configuracion
        public ContextoApplicacion(DbContextOptions options)
        : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }

        public DbSet<Pais> Pais { get; set; }
    }
}
