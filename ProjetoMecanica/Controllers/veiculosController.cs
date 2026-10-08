using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoMecanica.Data;
using ProjetoMecanica.Models;

namespace ProjetoMecanica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class veiculosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public veiculosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Veiculos>>> GetVeiculos()
        {
            return await _context.Veiculo.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> CriarVeiculo(Veiculos veiculo)
        {
            _context.Veiculo.Add(veiculo);

            await _context.SaveChangesAsync();

            return Ok("Veiculo criado com sucesso!");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> AlterarVeiculo(int id, Veiculos veiculo)
        {
            var veiculoAtual = await _context.Veiculo.FindAsync(id);
            if (veiculoAtual == null)
            {
                return NotFound();
            }

            veiculoAtual.Placa = veiculo.Placa; 
            veiculoAtual.Modelo = veiculo.Modelo;
            veiculoAtual.Marca = veiculo.Marca;
            veiculoAtual.Cor = veiculo.Cor;

            await _context.SaveChangesAsync();

            return Ok("Veiculo alterado com sucesso!");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletarVeiculo(int id)
        {
            var veiculo = await _context.Veiculo.FindAsync(id);
            if (veiculo == null)
            {
                return NotFound();
            }

            _context.Veiculo.Remove(veiculo);
            await _context.SaveChangesAsync();
            return Ok("Veiculo deletado com sucesso!");
        }
    }
}

