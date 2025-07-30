using LaboratorioF.models;
using LaboratorioF.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LaboratorioF.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutoresController : ControllerBase
    {
        private readonly IAutorRepository _autorRepository;

        public AutoresController(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }

        // GET: api/autores?sobrenome=Silva
        [HttpGet]
        public IActionResult BuscarPorSobrenome([FromQuery] string sobrenome)
        {
            var autores = _autorRepository.BuscarPorUltimoNome(sobrenome);
            return Ok(autores);
        }

        // POST: api/autores
        [HttpPost]
        public IActionResult AdicionarAutor([FromBody] Autor autor)
        {
            _autorRepository.Adicionar(autor);
            return CreatedAtAction(nameof(BuscarPorSobrenome), new { sobrenome = autor.UltimoNome }, autor);
        }

        // PUT: api/autores/{id}
        [HttpPut("{id}")]
        public IActionResult AtualizarAutor(int id, [FromBody] Autor autor)
        {
            if (autor.Id != id)
                return BadRequest("ID do autor não confere.");

            _autorRepository.Atualizar(autor);
            return NoContent();
        }
    }
}
