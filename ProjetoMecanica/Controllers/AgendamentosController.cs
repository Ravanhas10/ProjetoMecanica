using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoMecanica.Data;
using ProjetoMecanica.Models;

namespace ProjetoMecanica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AgendamentosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agendamentos>>> GetAgendamneto()
        {
            return await _context.Agendamentos.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> CriarAgendamento(Agendamentos agendamento)
        {
            _context.Agendamentos.Add(agendamento);

            await _context.SaveChangesAsync();

            return Ok("Agendamento criado com sucesso!");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> AlterarAgendamneto(int id, Agendamentos agendamentos)
        {
            var agendamentoAtual = await _context.Agendamentos.FindAsync(id);
            if (agendamentoAtual == null)
            {
                return NotFound();
            }

            agendamentoAtual.Data = agendamentos.Data;
            agendamentoAtual.Servico = agendamentos.Servico;

            await _context.SaveChangesAsync();

            return Ok("Agendamento alterado com sucesso!");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletarAgendamento(int id)
        {
            var agendamento = await _context.Agendamentos.FindAsync(id);
            if (agendamento == null)
            {
                return NotFound();
            }

            _context.Agendamentos.Remove(agendamento);
            await _context.SaveChangesAsync();
            return Ok("Agendamento deletado com sucesso!");
        }
    }
}

