using beckend.Data;
using beckend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace beckend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MarcacaoController : ControllerBase
    {
        private readonly BatidaPontoContext _context;

        public MarcacaoController(BatidaPontoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public  async Task<IEnumerable<Marcacao>> ExibirRegistros()
        {
            return await _context.Marcacoes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarRegistro(int id)
        {
            var registro = await _context.Marcacoes.FirstOrDefaultAsync(registro => registro.Id == id);
            if (registro == null)
                return NotFound();
            return Ok(registro);
        }

        [HttpGet("dia")]
        public async Task<IActionResult> BuscarRegistroDia(int diaDesejado)
        {            
            var registros = await _context.Marcacoes.ToListAsync();
            var registroDia = registros.Where(r => DateTime.Parse(r.Data).Day == diaDesejado).ToList();
            if(registroDia == null)
                return NotFound();
            return Ok(registroDia);      
        }

        [HttpGet("mes")]
        public async Task<IActionResult> BuscarRegistroMes(int mesDesejado)
        {            
            var registros = await _context.Marcacoes.ToListAsync();
            var registroMes = registros.Where(r => DateTime.Parse(r.Data).Month == mesDesejado).ToList();
            if(registroMes == null)
                return NotFound();
            return Ok(registroMes);      
        }

        [HttpPost("auto")]
        public async Task<IActionResult> AdicionarRegistroAuto()
        {
            var novoRegistro = new Marcacao
            {
                Data = DateTime.Now.ToString("dd-MM-yyyy"),
                Horario = DateTime.Now.ToString("hh:MM:ss"),
            };
            
            _context.Marcacoes.Add(novoRegistro);
            await _context.SaveChangesAsync();
            return Ok(novoRegistro);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarRegistroManual([FromBody] Marcacao marcacoes)
        {
            _context.Marcacoes.Add(marcacoes);
            await _context.SaveChangesAsync();
            CreatedAtAction(nameof(BuscarRegistro), new { id = marcacoes.Id }, marcacoes);
            return Ok(marcacoes);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarRegistro(int id)
        {
            var registro = await _context.Marcacoes.FirstOrDefaultAsync(registro => registro.Id == id);
            if (registro == null)
                return NotFound();
            _context.Marcacoes.Remove(registro);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}