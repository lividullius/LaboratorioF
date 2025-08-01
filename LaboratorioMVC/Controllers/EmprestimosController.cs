using LaboratorioMVC.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace LaboratorioMVC.Controllers
{
    public class EmprestimosController : Controller
    {
        private readonly HttpClient _client;

        public EmprestimosController(IHttpClientFactory factory)
        {
            _client = factory.CreateClient();
            _client.BaseAddress = new Uri("https://localhost:7032/api/"); // AJUSTE a URL da sua API
        }

        public IActionResult Emprestar() => View();
        public IActionResult Devolver() => View();

        [HttpPost]
        public async Task<IActionResult> Emprestar(EmprestimoDTO emprestimo)
        {
            var json = JsonConvert.SerializeObject(emprestimo);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("emprestimos", content);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Emprestar");

            ModelState.AddModelError("", "Erro ao emprestar livro.");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Devolver(int id)
        {
            var response = await _client.PostAsync($"emprestimos/{id}/devolver", null);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Devolver");

            ModelState.AddModelError("", "Erro ao devolver livro.");
            return View();
        }
    }
}
