namespace LaboratorioMVC.Models.DTOs
{
    public class LivroDisponivelDTO
    {
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public bool Disponivel { get; set; }
        public DateTime? ProximaDisponibilidade { get; set; }
    }
}
