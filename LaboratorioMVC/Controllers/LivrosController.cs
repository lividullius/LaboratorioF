using LaboratorioMVC.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LaboratorioMVC.Controllers
{
    public class LivroController : Controller
    {
        private readonly HttpClient _httpClient;

        public LivroController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("Api");
        }

        public async Task<IActionResult> Buscar(string? autor)
        {
            var livros = await _httpClient.GetFromJsonAsync<List<LivroDisponivelDTO>>($"api/emprestimos/livros-disponiveis?autor={autor}");
            return View(livros);
        }
    }
}
