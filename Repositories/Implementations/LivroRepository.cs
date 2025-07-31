using LaboratorioF.Data;
using LaboratorioF.models;
using LaboratorioF.Repositories.Interfaces;

namespace LaboratorioF.Repositories.Implementations
{
    public class LivroRepository : ILivroRepository
    {
        private readonly BibliotecaContext _context;

        public LivroRepository(BibliotecaContext context)
        {
            _context = context;
        }

        public IEnumerable<Livro> BuscarTodos()
        {
            return _context.Livros.ToList();
        }

        public Livro? BuscarPorId(int id)
        {
            return _context.Livros.FirstOrDefault(l => l.Id == id);
        }

        public void Adicionar(Livro livro)
        {
            _context.Livros.Add(livro);
            _context.SaveChanges();
        }

        public void Atualizar(Livro livro)
        {
            _context.Livros.Update(livro);
            _context.SaveChanges();
        }

        public void Remover(int id)
        {
            var livro = _context.Livros.Find(id);
            if (livro != null)
            {
                _context.Livros.Remove(livro);
                _context.SaveChanges();
            }
        }
    }
}


