using TarefasComCategorias.Models;

namespace TarefasComCategorias.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        public Task<IEnumerable<Categoria>> GetCategoriasAsync();

        public Task<Categoria?> GetCategoriaByIdAsync(Guid id);

        public Task<Categoria> CriarCategoriaAsync(Categoria categoria);

        public Task<Categoria> AtualizarCategoriaAsync(Categoria categoria);
    }
}
