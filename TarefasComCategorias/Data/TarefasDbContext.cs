using Microsoft.EntityFrameworkCore;
using TarefasComCategorias.Models;

namespace TarefasComCategorias.Data
{
    public class TarefasDbContext : DbContext
    {
        public TarefasDbContext(DbContextOptions options) : base(options){ }
        
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TarefasDbContext).Assembly);
        }
    }
}
