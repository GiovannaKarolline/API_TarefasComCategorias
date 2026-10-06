using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TarefasComCategorias.Models;

namespace TarefasComCategorias.Data.Configurations
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder
                .ToTable("Categorias");

            builder
                .HasKey(categoria => categoria.Id);

            builder
                .Property(categoria => categoria.Titulo)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("titulo_categoria");

            builder
                .HasIndex(categoria => categoria.Titulo)
                .IsUnique();

            builder
                .HasMany(categoria => categoria.Tarefas)
                .WithOne(tarefa => tarefa.Categoria)
                .HasForeignKey(tarefa => tarefa.CategoriaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
