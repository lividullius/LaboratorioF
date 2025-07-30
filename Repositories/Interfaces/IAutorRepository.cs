using LaboratorioF.models;

namespace LaboratorioF.Repositories.Interfaces
{
    public interface IAutorRepository
    {
        IEnumerable<Autor> BuscarPorUltimoNome(string sobrenome);
        void Adicionar(Autor autor);
        void Atualizar(Autor autor);
    }
}
