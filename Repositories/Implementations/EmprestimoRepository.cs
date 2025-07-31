using LaboratorioF.Data;
using LaboratorioF.models;
using LaboratorioF.Repositories.Interfaces;

namespace LaboratorioF.Repositories.Implementations
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly BibliotecaContext _context;

        public EmprestimoRepository(BibliotecaContext context)
        {
            _context = context;
        }

        public void Registrar(Emprestimo emprestimo)
        {
            _context.Emprestimos.Add(emprestimo);
            _context.SaveChanges();
        }

        public void Atualizar(Emprestimo emprestimo)
        {
            _context.Emprestimos.Update(emprestimo);
            _context.SaveChanges();
        }

        public Emprestimo? ObterEmprestimoEmAbertoPorLivro(int livroId)
        {
            return _context.Emprestimos
                .FirstOrDefault(e => e.LivroId == livroId && e.DataEntrega == null);
        }
    }
}
