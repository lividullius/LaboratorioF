using LaboratorioF.Data;
using LaboratorioF.models;
using LaboratorioF.Repositories.Interfaces;

namespace LaboratorioF.Repositories.Implementations
{
    public class AutorRepository : IAutorRepository
    {
        private readonly BibliotecaContext _context;

        public AutorRepository(BibliotecaContext context)
        {
            _context = context;
        }

        public IEnumerable<Autor> BuscarPorUltimoNome(string sobrenome)
        {
            return _context.Autores
                .Where(a => a.UltimoNome == sobrenome)
                .ToList();
        }

        public void Adicionar(Autor autor)
        {
            _context.Autores.Add(autor);
            _context.SaveChanges();
        }

        public void Atualizar(Autor autor)
        {
            _context.Autores.Update(autor);
            _context.SaveChanges();
        }
    }
}
