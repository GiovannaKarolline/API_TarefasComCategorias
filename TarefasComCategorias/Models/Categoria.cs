namespace TarefasComCategorias.Models
{
    public class Categoria
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public IEnumerable<Tarefa> Tarefas { get; set; }
    }
}
