using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TraduccionesLegales.WebApi.Models;

namespace TraduccionesLegales.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly ContextoApplicacion _context;

        public AccountController(ContextoApplicacion contexto)
        {
            _context = contexto;
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> PostLogin(Models.Login login)
        {
            var usuario = _context.Usuarios.FirstOrDefault(U => U.Email == login.Email && U.Contraseña == login.Contraseña);
            return usuario;
        }
    }
}