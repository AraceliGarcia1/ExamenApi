using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyExam.Models;
using System.Net;
namespace MyExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PacienteController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var listPacientes = await _context.Paciente.ToListAsync();
            if (listPacientes == null || listPacientes.Count == 0)
            {
                return NoContent();
            }
            return Ok(listPacientes);
        }

        [HttpGet("Show")]
        public async Task<IActionResult> Show(int id)
        {
            var paciente = await _context.Paciente.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }
            return Ok(paciente);
        }

        [HttpPost("Store")]
        public async Task<HttpStatusCode> Store([FromBody] Paciente paciente)
        {
            if (paciente == null)
            {
                return HttpStatusCode.BadRequest;
            }
            _context.Add(paciente);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Paciente paciente)
        {
            if (paciente == null)
            {
                return BadRequest(); //Error code 400
            }
            var entity = await _context.Paciente.FindAsync(paciente.Id);
            if (entity == null)
            {
                return NotFound(); //Error code 404
            }
            entity.Nombre = paciente.Nombre;
            entity.Especie = paciente.Especie;
            entity.Raza = paciente.Raza;
            entity.Peso = paciente.Peso;
            entity.FechaNacimiento=paciente.FechaNacimiento;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("Destroy")]
        public async Task<IActionResult> Destroy(int id)
        {
            var paciente = await _context.Paciente.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }
            _context.Paciente.Remove(paciente);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }

}
