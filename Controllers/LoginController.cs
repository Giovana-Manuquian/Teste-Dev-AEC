using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteDevAEC.Data;
using TesteDevAEC.Security;

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
            var user = _context.Usuarios.AsNoTracking()
                .FirstOrDefault(u => u.UsuarioLogin == login);

            if (user != null && PasswordHasher.Verify(senha, user.SenhaSalt, user.SenhaHash))
            {
                HttpContext.Session.SetInt32("UsuarioLogadoId", user.Id);
                return RedirectToAction("Index", "Endereco");
            }

            ViewBag.Erro = "Usuário ou senha inválidos!";
            return View("Index");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Index));
        }
    }
}