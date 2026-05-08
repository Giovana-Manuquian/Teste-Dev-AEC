using Microsoft.AspNetCore.Mvc;
using TesteDevAEC.Data;
using TesteDevAEC.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Text; // NECESSÁRIO PARA O STRINGBUILDER

namespace TesteDevAEC.Controllers
{
    public class EnderecoController : Controller
    {
        private readonly AppDbContext _context;

        public EnderecoController(AppDbContext context)
        {
            _context = context;
        }

        // Listagem de Endereços
        public IActionResult Index()
        {
            int? usuarioId = HttpContext.Session.GetInt32("UsuarioLogadoId");
            if (usuarioId == null) return RedirectToAction("Index", "Login");

            // Lista apenas os endereços do usuário logado
            var lista = _context.Enderecos.Where(e => e.UsuarioId == usuarioId).ToList();
            return View(lista);
        }

        public IActionResult Create()
        {
            if (HttpContext.Session.GetInt32("UsuarioLogadoId") == null)
                return RedirectToAction("Index", "Login");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Endereco endereco)
        {
            int? usuarioId = HttpContext.Session.GetInt32("UsuarioLogadoId");

            if (usuarioId == null) return RedirectToAction("Index", "Login");

            endereco.UsuarioId = usuarioId.Value;
            ModelState.Remove("Usuario");

            if (ModelState.IsValid)
            {
                _context.Enderecos.Add(endereco);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(endereco);
        }

        // --- NOVO MÉTODO: EXPORTAR CSV ---
        public IActionResult ExportarCsv()
        {
            int? usuarioId = HttpContext.Session.GetInt32("UsuarioLogadoId");

            if (usuarioId == null) return RedirectToAction("Index", "Login");

            var enderecos = _context.Enderecos.Where(e => e.UsuarioId == usuarioId).ToList();

            var builder = new StringBuilder();
            // Cabeçalho do CSV
            builder.AppendLine("CEP;Logradouro;Complemento;Bairro;Cidade;UF;Numero");

            foreach (var end in enderecos)
            {
                builder.AppendLine($"{end.Cep};{end.Logradouro};{end.Complemento};{end.Bairro};{end.Cidade};{end.Uf};{end.Numero}");
            }

            // O uso do ';' (ponto e vírgula) é melhor para o Excel em português abrir direto sem bugar
            return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "meus_enderecos.csv");
        }
    }
}