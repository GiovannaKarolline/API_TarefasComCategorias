using TarefasComCategorias.DTOs;

namespace TarefasComCategorias.Services.Interfaces
{
    public interface ICategoriaService
    {
        public Task<IEnumerable<CategoriaDto>> GetCategoriasAsync();

        public Task<CategoriaDto?> GetCategoriaByIdAsync(Guid id);

        public Task<CategoriaDto?> CriarCategoriaAsync(CategoriaDto categoria);

        public Task<CategoriaDto?> AtualizarCategoriaAsync(Guid id, CategoriaDto categoria);
    }
}
