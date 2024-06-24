using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArticulosAPi.DAL;
using Shared.Models;
using ArticulosAPi.Services;

namespace ArticulosAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController(ArticulosService articuloService) : ControllerBase
    {

        // GET: api/Articulos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Articulos>>> GetArticulos()
        {
            var articulo = await articuloService.Listar(a => true);
            if (articulo == null)
                return NotFound();

            return Ok(articulo);
        }

        // GET: api/Articulos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Articulos>> GetArticulos(int id)
        {
            var articulo = await articuloService.Buscar(id);
            if (articulo == null)
                return NotFound();

            return articulo;
        }

        // PUT: api/Articulos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticulos(int id, Articulos articulo)
        {
            if (id != articulo.ArticuloId)
            {
                return BadRequest();
            }
            var guardo = await articuloService.Guardar(articulo);
            if (!guardo)
            {
                return NotFound();
            }
            return NoContent();
        }

        // POST: api/Articulos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Articulos>> PostArticulos(Articulos articulos)
        {
            var result = await articuloService.Guardar(articulos);

            if (!result)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrio un error durante la creacion.");
            }

            return CreatedAtAction("GetArticulos", new { id = articulos.ArticuloId }, articulos);
        }

        // DELETE: api/Articulos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticulos(int id)
        {
            var articulos = await articuloService.Buscar(id);
            if (articulos == null)
            {
                return NotFound();
            }
            var result = await articuloService.Eliminar(articulos);
            if (!result)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrio un error durante la eliminacion.");
            }
            return NoContent();
        }

    }
}
