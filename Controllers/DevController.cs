using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TesteDevAEC.Data;
using TesteDevAEC.Models;
using TesteDevAEC.Security;

namespace TesteDevAEC.Controllers
{
    [Route("dev")]
    public class DevController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _env;

        public DevController(AppDbContext context, IConfiguration config, IWebHostEnvironment env)
        {
            _context = context;
            _config = config;
            _env = env;
        }

        [HttpGet("seed")]
        public IActionResult Seed()
        {
            if (!_env.IsDevelopment())
                return NotFound();

            var login = _config["SeedUser:Login"] ?? "giovana";
            var senha = _config["SeedUser:Senha"] ?? "123456";
            var nome = _config["SeedUser:Nome"] ?? "Giovana Dev";

            var exists = _context.Usuarios.Any(u => u.UsuarioLogin == login);
            if (exists)
                return Ok($"Usuário '{login}' já existe.");

            var (salt, hash) = PasswordHasher.Hash(senha);

            _context.Usuarios.Add(new Usuario
            {
                Nome = nome,
                UsuarioLogin = login,
                SenhaSalt = salt,
                SenhaHash = hash
            });

            _context.SaveChanges();

            return Ok($"Usuário criado: login='{login}' senha='{senha}' (apenas DEV).");
        }
    }
}