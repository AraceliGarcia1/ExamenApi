using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyExam.Models;
using System.Net;
namespace MyExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropietarioController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PropietarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var listPropietarios = await _context.Propietarios.ToListAsync();
            if (listPropietarios == null || listPropietarios.Count == 0)
            {
                return NoContent();
            }
            return Ok(listPropietarios);
        }

        [HttpGet("Show")]
        public async Task<IActionResult> Show(int id)
        {
            var propietario = await _context.Propietarios.FindAsync(id);
            if (propietario == null)
            {
                return NotFound();
            }
            return Ok(propietario);
        }

        [HttpPost("Store")]
        public async Task<HttpStatusCode> Store([FromBody] Propietario propietario)
        {
            if (propietario == null)
            {
                return HttpStatusCode.BadRequest;
            }
            _context.Add(propietario);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Propietario propietario)
        {
            if (propietario == null)
            {
                return BadRequest(); //Error code 400
            }
            var entity = await _context.Propietarios.FindAsync(propietario.Id);
            if (entity == null)
            {
                return NotFound(); //Error code 404
            }
            entity.Nombre = propietario.Nombre;
            entity.Apellidos = propietario.Apellidos;
            entity.Direccion = propietario.Direccion;
            entity.CorreoElectronico = propietario.CorreoElectronico;
            entity.Telefono=propietario.Telefono;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("Destroy")]
        public async Task<IActionResult> Destroy(int id)
        {
            var propietario = await _context.Propietarios.FindAsync(id);
            if (propietario == null)
            {
                return NotFound();
            }
            _context.Propietarios.Remove(propietario);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }


}
