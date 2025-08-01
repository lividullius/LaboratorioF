using LaboratorioF.Data;
using LaboratorioF.models;
using LaboratorioF.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using LaboratorioMVC.Models.DTOs;

namespace LaboratorioF.Repositories.Implementations
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly BibliotecaContext _context;

        public EmprestimoRepository(BibliotecaContext context)
        {
            _context = context;
        }

        public void Adicionar(Emprestimo emprestimo)
        {
            _context.Emprestimos.Add(emprestimo);
            _context.SaveChanges();
        }

        public void Atualizar(Emprestimo emprestimo)
        {
            _context.Emprestimos.Update(emprestimo);
            _context.SaveChanges();
        }

        public Emprestimo? ObterPorId(int id)
        {
            return _context.Emprestimos
                .Include(e => e.Livro)
                .FirstOrDefault(e => e.Id == id);
        }

        public Emprestimo? ObterEmprestimoEmAbertoPorLivro(int livroId)
        {
            return _context.Emprestimos
                .FirstOrDefault(e => e.LivroId == livroId && e.DataEntrega == null);
        }

        
        public IEnumerable<LivroDisponivelDTO> BuscarLivrosDisponiveisPorAutor(string autor)
{
    var livrosComEmprestimos = _context.Livros
        .Include(l => l.Autor)
        .Include(l => l.Emprestimos)
        .Where(l => l.Autor != null && l.Autor.UltimoNome != null && l.Autor.UltimoNome.Contains(autor))
        .Select(l => new LivroDisponivelDTO
        {
            Titulo = l.Titulo!,
            Autor = l.Autor!.PrimeiroNome + " " + l.Autor.UltimoNome,
            Disponivel = !l.Emprestimos.Any(e => e.DataEntrega == null),
            ProximaDisponibilidade = l.Emprestimos
                .Where(e => e.DataEntrega == null)
                .Select(e => e.DataPrevistaEntrega)
                .FirstOrDefault()
        });

    return livrosComEmprestimos.ToList();
}

    }
}
