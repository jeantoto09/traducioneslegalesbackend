using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TraduccionesLegales.WebApi.Models;

namespace TraduccionesLegales.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ContextoApplicacion>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc(option => option.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            {
                //app.UseHsts();
            }

            var context = app.ApplicationServices.GetService<ContextoApplicacion>();
            AddTestData(context);
            app.UseHttpsRedirection();
            app.UseMvcWithDefaultRoute();
        }

        private static void AddTestData(ContextoApplicacion context)
        {

            var pais = new Pais
            {
                PaisId = 1,
                NombrePais = "Rumania",
                Idioma = "Rumany"
            };

            var pais2 = new Pais
            {
                PaisId = 2,
                NombrePais = "Reino unido",
                Idioma = "Ingles"
            };


            var testUser1 = new Usuario
            {
                UserName = "YanCarlo123",
                Email = "yan@gmail.com",
                Contraseña = "Skywalker",
                Nombre = "yancarlo",
                Apellido = "Vasquez",
                NumeroDeTelefono = "20000000",
                NombreDeCompañia = "Cualquier compañia",
                TipoDeUsuario = Utilidades.TipoDeUsuario.Administrador
            };

            context.Pais.Add(pais);
            context.Pais.Add(pais2);
            context.Usuarios.Add(testUser1);
            context.SaveChanges();
        }


    }
}
