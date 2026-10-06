using TarefasComCategorias.Models;

namespace TarefasComCategorias.Repositories.Interfaces
{
    public interface ITarefaRepository
    {
        public Task<IEnumerable<Tarefa>> GetTarefasAsync();

        public Task<Tarefa?> GetTarefaByIdAsync(Guid id);

        public Task<Tarefa> CriarTarefaAsync(Tarefa tarefa);

        public Task<Tarefa> AtualizarTarefaAsync(Tarefa tarefa);

    }
}
