using Microsoft.EntityFrameworkCore;
using TarefasComCategorias.Data;
using TarefasComCategorias.Models;
using TarefasComCategorias.Repositories.Interfaces;

namespace TarefasComCategorias.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly TarefasDbContext _context;

        public TarefaRepository(TarefasDbContext context)
        {
            _context = context;
        }

        public async Task<Tarefa> AtualizarTarefaAsync(Tarefa tarefa)
        {
            _context.Tarefas.Update(tarefa);
            await _context.SaveChangesAsync();

            return await Task.FromResult(tarefa);
        }

        public async Task<Tarefa> CriarTarefaAsync(Tarefa tarefa)
        {
            await _context.Tarefas.AddAsync(tarefa);
            await _context.SaveChangesAsync();

            return await Task.FromResult(tarefa);
        }

        public async Task<IEnumerable<Tarefa>> GetTarefasAsync()
        {
            return await _context.Tarefas
                .Include(tarefa => tarefa.Categoria)
                .ToListAsync();
        }

        public async Task<Tarefa?> GetTarefaByIdAsync(Guid id)
        {
            return await _context.Tarefas
                .Include(tarefa => tarefa.Categoria)
                .Where(tarefa => tarefa.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
