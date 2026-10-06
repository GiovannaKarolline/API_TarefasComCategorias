namespace TarefasComCategorias.Models
{
    public class Tarefa
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }

        public bool Concluida { get; set; }
        public DateOnly DataCriacao { get; set; }
        public Guid CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
