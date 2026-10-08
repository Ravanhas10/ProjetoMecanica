using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoMecanica.Data;
using ProjetoMecanica.Models;

namespace ProjetoMecanica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clientes>>> GetClientes()
        {
            return await _context.Cliente.ToListAsync();
        }

        [HttpPost]
        public async  Task<ActionResult> CriarCliente(Clientes cliente)
        {
            _context.Cliente.Add(cliente);

            await _context.SaveChangesAsync();

            return Ok("Cliente criado com sucesso!");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> AlterarCliente(int id, Clientes cliente)
        {
            var clienteAtual = await _context.Cliente.FindAsync(id);
            if (clienteAtual == null)
            {
                return NotFound();
            }

            clienteAtual.CPF = cliente.CPF;
            clienteAtual.Telefone = cliente.Telefone;
            clienteAtual.Nome = cliente.Nome;
            clienteAtual.Endereco = cliente.Endereco;

            await _context.SaveChangesAsync();

            return Ok("Cliente alterado com sucesso!");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletarCliente(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            if(cliente == null)
            {
                return NotFound();
            }

            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();
            return Ok("Cliente deletado com sucesso!");
        }
    }
}
