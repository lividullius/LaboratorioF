using LaboratorioF.models;

namespace LaboratorioF.Repositories.Interfaces
{
    public interface IEmprestimoRepository
    {
        void Registrar(Emprestimo emprestimo);
        void Atualizar(Emprestimo emprestimo);
        Emprestimo? ObterEmprestimoEmAbertoPorLivro(int livroId);
    }
}
