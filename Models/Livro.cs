namespace LaboratorioF.models;

public class Livro
{
    public int Id { get; set; }
    public string? Titulo { get; set; }

    public int AutorId { get; set; }
    public Autor? Autor { get; set; }

    public ICollection<Emprestimo> Emprestimos { get; set; } = new List<Emprestimo>();

}