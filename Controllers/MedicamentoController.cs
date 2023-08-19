using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using MyExam.Models;

namespace MyExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicamentoController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        public MedicamentoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var listMedicamento = await _context.Medicamentos.ToListAsync();
            if (listMedicamento == null || listMedicamento.Count == 0)
            {
                return NoContent();
            }
            return Ok(listMedicamento);
        }

        [HttpPost("Store")]
        public async Task<HttpStatusCode> Store([FromBody] Medicamento medicamento)
        {
            if (medicamento == null)
            {
                return HttpStatusCode.BadRequest;
            }
            _context.Add(medicamento);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }

        [HttpGet("Show")]
        public async Task<IActionResult> Show(int id)
        {
            var medicamento = await _context.Medicamentos.FindAsync(id);
            if (medicamento == null)
            {
                return NotFound();
            }
            return Ok(medicamento);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Medicamento medicamento)
        {
            if (medicamento == null)
            {
                return BadRequest(); //Error code 400
            }
            var entity = await _context.Medicamentos.FindAsync(medicamento.Id);
            if (entity == null)
            {
                return NotFound(); //Error code 404
            }
            entity.Nombre = medicamento.Nombre;
            entity.Description = medicamento.Description;
            entity.DosisRecomendada = medicamento.DosisRecomendada;
            entity.FormaAdministracion = medicamento.FormaAdministracion;
            entity.Indicaciones = medicamento.Indicaciones;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("Destroy")]
        public async Task<IActionResult> Destroy(int id)
        {
            var medicamento = await _context.Medicamentos.FindAsync(id);
            if (medicamento == null)
            {
                return NotFound();
            }
            _context.Medicamentos.Remove(medicamento);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }


}
