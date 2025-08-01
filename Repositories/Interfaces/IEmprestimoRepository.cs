using LaboratorioF.models;
using LaboratorioMVC.Models.DTOs;

namespace LaboratorioF.Repositories.Interfaces
{
    public interface IEmprestimoRepository
    {
        void Adicionar(Emprestimo emprestimo);
        void Atualizar(Emprestimo emprestimo);
        Emprestimo? ObterPorId(int id);
        Emprestimo? ObterEmprestimoEmAbertoPorLivro(int livroId);
        IEnumerable<LivroDisponivelDTO> BuscarLivrosDisponiveisPorAutor(string autor);
}
    }

