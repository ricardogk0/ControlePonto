using AutoMapper;
using Backend.DTOs;
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
        private readonly IMapper _mapper;

        public MarcacaoController(BatidaPontoContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public  async Task<IEnumerable<MarcacaoDTO>> ExibirRegistros()
        {
            var registro = await _context.Marcacoes.ToListAsync();
            var registroDTO = _mapper.Map<List<MarcacaoDTO>>(registro);
            return registroDTO;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarRegistro(int id)
        {
            var registro = await _context.Marcacoes.FirstOrDefaultAsync(registro => registro.Id == id);
            if (registro == null)
                return NotFound();

            var registroDTO = _mapper.Map<MarcacaoDTO>(registro);
            return Ok(registroDTO);
        }

        [HttpGet("dia")]
        public async Task<IActionResult> BuscarRegistroDia(int diaDesejado)
        {            
            var registro = await _context.Marcacoes.ToListAsync();
            var registroDTO = _mapper.Map<List<MarcacaoDTO>>(registro);
            var registroDia = registroDTO.Where(r => DateTime.Parse(r.Data).Day == diaDesejado).ToList();
            if(registroDia == null)
                return NotFound();
            return Ok(registroDia);      
        }

        [HttpGet("mes")]
        public async Task<IActionResult> BuscarRegistroMes(int mesDesejado)
        {            
            var registro = await _context.Marcacoes.ToListAsync();
            var registroDTO = _mapper.Map<List<MarcacaoDTO>>(registro);
            var registroMes = registroDTO.Where(r => DateTime.Parse(r.Data).Month == mesDesejado).ToList();
            if(registroMes == null)
                return NotFound();
            return Ok(registroMes);      
        }

        [HttpPost("auto")]
        public async Task<IActionResult> AdicionarRegistroAuto()
        {
            var novoRegistro = new MarcacaoDTO
            {
                Data = DateTime.Now.ToString("dd-MM-yyyy"),
                Horario = DateTime.Now.ToString("HH:mm:ss"),
                Status = (Enums.Status)1
            };
            
            _context.Marcacoes.Add(_mapper.Map<Marcacao>(novoRegistro));
            await _context.SaveChangesAsync();
            return Ok(novoRegistro);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarRegistroManual([FromBody] MarcacaoDTO marcacaoDTO)
        {
            var marcacao = _mapper.Map<Marcacao>(marcacaoDTO);
            _context.Marcacoes.Add(marcacao);
            await _context.SaveChangesAsync();
            CreatedAtAction(nameof(BuscarRegistro), new { id = marcacao.Id }, marcacao);
            return Ok(marcacao);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarRegistro(int id)
        {
            var registro = await _context.Marcacoes.FirstOrDefaultAsync(registro => registro.Id == id);
            if (registro == null)
                return NotFound();
            
            var registroDTO = _mapper.Map<MarcacaoDTO>(registro);
            _context.Marcacoes.Remove(registro);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}