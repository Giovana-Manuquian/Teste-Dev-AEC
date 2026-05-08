using Microsoft.AspNetCore.Mvc;
using TesteDevAEC.Data;
using TesteDevAEC.Models;
using System.Linq;

namespace TesteDevAEC.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Login
        public IActionResult Index()
        {
            return View();
        }

        // POST: Login/Autenticar
        [HttpPost]
        public IActionResult Autenticar(string login, string senha)
        {
            // Busca o usuário no MySQL
            var user = _context.Usuarios
                .FirstOrDefault(u => u.UsuarioLogin == login && u.Senha == senha);

            if (user != null)
            {
                // Se achou, vai para a tela de endereços (que vamos criar)
                return RedirectToAction("Index", "Endereco");
            }

            // Se não achou, manda mensagem de erro
            ViewBag.Erro = "Usuário ou senha inválidos!";
            return View("Index");
        }
    }
}