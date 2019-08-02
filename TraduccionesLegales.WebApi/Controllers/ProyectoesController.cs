using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TraduccionesLegales.WebApi;
using TraduccionesLegales.WebApi.Models;

namespace TraduccionesLegales.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectosController : ControllerBase
    {
        private readonly ContextoApplicacion _context;

        public ProyectosController(ContextoApplicacion context)
        {
            _context = context;
        }

        // GET: api/Proyectoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proyecto>>> GetProyectos()
        {
            return await _context.Proyectos.ToListAsync();
        }

        // GET: api/Proyectes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Proyecto>> GetProyecto(int id)
        {
            var proyecto = await _context.Proyectos.FindAsync(id);

            if (proyecto == null)
            {
                return NotFound();
            }

            return proyecto;
        }

        // PUT: api/Proyectos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProyecto(int id, ProyectoEntrada proyecto)
        {
            Proyecto proyectoOriginal = new Proyecto();
            proyectoOriginal.ProyectoId = proyecto.ProyectoId;
            proyectoOriginal.IdiomaOriginDePais = proyecto.IdiomaOriginDePais;
            proyectoOriginal.IdiomaDestinoDePais = proyecto.IdiomaOriginDePais;
      //      proyectoOriginal.Archivo = proyecto.GetArchivoBytes();
            proyectoOriginal.Instrucciones = proyecto.Instrucciones;
            proyectoOriginal.Pagado = proyecto.Pagado;
            proyectoOriginal.Usuario = await _context.Usuarios.FindAsync(proyecto.Usuario);

            if (id != proyectoOriginal.ProyectoId)
            {
                return BadRequest();
            }

            _context.Entry(proyectoOriginal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProyectoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Proyectos
        [HttpPost]
        public async Task<ActionResult<Proyecto>> PostProyecto(ProyectoEntrada proyecto)
        {
            Proyecto proyectoOriginal = new Proyecto();
            proyectoOriginal.ProyectoId = proyecto.ProyectoId; 
            proyectoOriginal.IdiomaOriginDePais = proyecto.IdiomaOriginDePais;
            proyectoOriginal.IdiomaDestinoDePais = proyecto.IdiomaOriginDePais;
            proyectoOriginal.Archivo = proyecto.GetArchivoBytes();
            proyectoOriginal.Instrucciones = proyecto.Instrucciones;
            proyectoOriginal.Pagado = proyecto.Pagado;
            proyectoOriginal.Usuario = await _context.Usuarios.FindAsync(proyecto.Usuario);

            _context.Proyectos.Add(proyectoOriginal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProyecto", new { id = proyecto.ProyectoId }, proyecto);
        }

        // DELETE: api/Proyectoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Proyecto>> DeleteProyecto(int id)
        {
            var proyecto = await _context.Proyectos.FindAsync(id);
            if (proyecto == null)
            {
                return NotFound();
            }

            _context.Proyectos.Remove(proyecto);
            await _context.SaveChangesAsync();

            return proyecto;
        }

        private bool ProyectoExists(int id)
        {
            return _context.Proyectos.Any(e => e.ProyectoId == id);
        }
    }
}
