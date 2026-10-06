using System.ComponentModel.DataAnnotations;

namespace TarefasComCategorias.DTOs
{
    public class TarefaDto
    {
        [Required(ErrorMessage = "O título da tarefa precisa ser preenchido.")]
        [MaxLength(50, ErrorMessage = "O título deve possuir, no máximo, 100 caracteres.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O status de conclusão da tarefa precisa ser preenchido.")]
        public bool Concluida { get; set; } = false;

        [Required(ErrorMessage = "O Id da categoria a qual a tarefa pertence precisa ser preenchida.")]
        public Guid CategoriaId { get; set; }
    }
}
