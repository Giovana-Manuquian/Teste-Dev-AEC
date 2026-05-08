using Microsoft.AspNetCore.Mvc;
using TesteDevAEC.Data;
using TesteDevAEC.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace TesteDevAEC.Controllers
{
    public class EnderecoController : Controller
    {
        private readonly AppDbContext _context;

        public EnderecoController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var lista = _context.Enderecos.ToList();
            return View(lista);
        }

        public IActionResult Create()
        {
            // Opcional: Verificar se o usuário está logado antes de abrir a tela
            if (HttpContext.Session.GetInt32("UsuarioLogadoId") == null)
                return RedirectToAction("Index", "Login");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Endereco endereco)
        {
            int? usuarioId = HttpContext.Session.GetInt32("UsuarioLogadoId");

            if (usuarioId == null)
            {
                return RedirectToAction("Index", "Login");
            }

            // Atribui o ID real do login ao endereço
            endereco.UsuarioId = usuarioId.Value;

            // Remove a validação do objeto "Usuario" para o ModelState não travar o salvamento
            ModelState.Remove("Usuario");

            if (ModelState.IsValid)
            {
                _context.Enderecos.Add(endereco);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(endereco);
        }
    }
}