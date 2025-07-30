namespace LaboratorioF.models;

public class Emprestimo
{
    public int Id { get; set; }
    public int LivroId { get; set; }
    public Livro? Livro { get; set; }

    public DateTime DataEmprestimo { get; set; }
    public DateTime DataPrevistaEntrega { get; set; }
    public DateTime? DataEntrega { get; set; }
}