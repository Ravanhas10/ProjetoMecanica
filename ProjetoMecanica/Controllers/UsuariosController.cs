using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoMecanica.Data;
using ProjetoMecanica.Models;

namespace ProjetoMecanica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
        _context = context; 
        }

        [HttpPost]
        public IActionResult login(Usuarios usuario)
        {
            var user = _context.Usuario.FirstOrDefault(u => u.Nome == usuario.Nome && usuario.Senha == usuario.Senha);

            if (user == null)
            {
                return Unauthorized("Vc é burro tente novamente");
            }

            return Ok(new { Nome = user.Nome });
        }
    }
}
