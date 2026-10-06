using System.ComponentModel.DataAnnotations;

namespace TarefasComCategorias.DTOs
{
    public class CategoriaDto
    {
        [Required(ErrorMessage = "O título da categoria precisa ser preenchido.")]
        [MaxLength(50, ErrorMessage = "O título deve possuir, no máximo, 50 caracteres.")]
        public string Titulo { get; set; }
    }
}
