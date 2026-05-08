using Microsoft.AspNetCore.Mvc;
using TesteDevAEC.Data;
using TesteDevAEC.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace TesteDevAEC.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Autenticar(string login, string senha)
        {
            var user = _context.Usuarios
                .FirstOrDefault(u => u.UsuarioLogin == login && u.Senha == senha);

            if (user != null)
            {
                // Guarda o ID do usuário na sessão de forma limpa
                HttpContext.Session.SetInt32("UsuarioLogadoId", user.Id);
                return RedirectToAction("Index", "Endereco");
            }

            ViewBag.Erro = "Usuário ou senha inválidos!";
            return View("Index");
        }
    }
}