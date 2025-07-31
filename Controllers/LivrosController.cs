using LaboratorioF.models;
using LaboratorioF.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LaboratorioF.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivrosController : ControllerBase
    {
        private readonly ILivroRepository _livroRepository;

        public LivrosController(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        // GET: api/livros?titulo=Dom
        [HttpGet]
        public IActionResult BuscarPorTitulo([FromQuery] string titulo)
        {
            var livros = _livroRepository.BuscarPorTitulo(titulo);
            return Ok(livros);
        }

        // POST: api/livros
        [HttpPost]
        public IActionResult AdicionarLivro([FromBody] Livro livro)
        {
            _livroRepository.Adicionar(livro);
            return CreatedAtAction(nameof(BuscarPorTitulo), new { titulo = livro.Titulo }, livro);
        }

        // PUT: api/livros/{id}
        [HttpPut("{id}")]
        public IActionResult AtualizarLivro(int id, [FromBody] Livro livro)
        {
            if (livro.Id != id)
                return BadRequest("ID do livro não confere.");

            _livroRepository.Atualizar(livro);
            return NoContent();
        }
    }
}
