using TarefasComCategorias.DTOs;

namespace TarefasComCategorias.Services.Interfaces
{
    public interface ITarefaService
    {
        public Task<IEnumerable<TarefaDto>> GetTarefasAsync();

        public Task<TarefaDto?> GetTarefaByIdAsync(Guid id);

        public Task<TarefaDto?> CriarTarefaAsync(TarefaDto tarefa);

        public Task<TarefaDto?> AtualizarTarefaAsync(Guid id, TarefaDto tarefa);
    }
}