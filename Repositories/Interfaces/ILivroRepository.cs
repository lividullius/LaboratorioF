using LaboratorioF.models;

namespace LaboratorioF.Repositories.Interfaces
{
    public interface ILivroRepository
    {
        // Métodos, por exemplo:
        void Adicionar(Livro livro);
        IEnumerable<Livro> BuscarTodos();
        IEnumerable<Livro> BuscarPorTitulo(string titulo);
        Livro? BuscarPorId(int id);
        void Atualizar(Livro livro);
        void Remover(int id);
    }
}
