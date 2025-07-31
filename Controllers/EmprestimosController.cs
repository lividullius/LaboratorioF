using LaboratorioF.models;
using LaboratorioF.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LaboratorioF.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmprestimosController : ControllerBase
    {
        private readonly IEmprestimoRepository _repository;

        public EmprestimosController(IEmprestimoRepository repository)
        {
            _repository = repository;
        }

        // 1. Emprestar um livro
        [HttpPost]
        public IActionResult EmprestarLivro([FromBody] Emprestimo emprestimo)
        {
            var emprestimoAberto = _repository.ObterEmprestimoEmAbertoPorLivro(emprestimo.LivroId);

            if (emprestimoAberto != null)
                return BadRequest("Livro já está emprestado.");

            emprestimo.DataEmprestimo = DateTime.Now;
            emprestimo.DataPrevistaEntrega = DateTime.Now.AddDays(7);
            _repository.Adicionar(emprestimo);

            return Created("", emprestimo);
        }

        // 2. Devolver livro
        [HttpPost("{id}/devolver")]
        public IActionResult DevolverLivro(int id)
        {
            var emprestimo = _repository.ObterPorId(id);
            if (emprestimo == null) return NotFound();

            emprestimo.DataEntrega = DateTime.Now;

            _repository.Atualizar(emprestimo);

            var atraso = (emprestimo.DataEntrega.Value - emprestimo.DataPrevistaEntrega).Days;
            var multa = atraso > 0 ? atraso * 2 : 0;

            return Ok(new { mensagem = "Livro devolvido.", multa });
        }

        // 3. Consultar livros por autor + disponibilidade + data futura
        [HttpGet("livros-disponiveis")]
        public IActionResult ConsultarLivros([FromQuery] string autor)
        {
            var livros = _repository.BuscarLivrosDisponiveisPorAutor(autor);
            return Ok(livros);
        }
    }
}
