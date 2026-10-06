using Microsoft.EntityFrameworkCore;
using TarefasComCategorias.Data;
using TarefasComCategorias.Models;
using TarefasComCategorias.Repositories.Interfaces;

namespace TarefasComCategorias.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly TarefasDbContext _context;

        public CategoriaRepository(TarefasDbContext context)
        {
            _context = context;
        }

        public async Task<Categoria> AtualizarCategoriaAsync(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            await _context.SaveChangesAsync();

            return await Task.FromResult(categoria);
        }

        public async Task<Categoria> CriarCategoriaAsync(Categoria categoria)
        {
            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();

            return await Task.FromResult(categoria);
        }

        public async Task<IEnumerable<Categoria>> GetCategoriasAsync()
        {
            return await _context.Categorias
                .Include(categoria => categoria.Tarefas)
                .ToListAsync();
        }

        public async Task<Categoria?> GetCategoriaByIdAsync(Guid id)
        {
            return await _context.Categorias
                .Include(categoria => categoria.Tarefas)
                .FirstOrDefaultAsync();
        }
    }
}