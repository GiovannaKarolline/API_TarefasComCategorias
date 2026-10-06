using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TarefasComCategorias.Models;

namespace TarefasComCategorias.Data.Configurations
{
    public class TarefaConfiguration : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder
                .ToTable("Tarefas");

            builder
                .HasKey(tarefa => tarefa.Id);

            builder
                .Property(tarefa => tarefa.Titulo)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("titulo_tarefa");

            builder
                .Property(tarefa => tarefa.DataCriacao)
                .HasDefaultValue(new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day))
                .HasColumnName("data_criacao_tarefa");

            builder
                .Property(tarefa => tarefa.Concluida)
                .IsRequired()
                .HasDefaultValue(false)
                .HasColumnName("status_concluida");

            builder
                .Property(tarefa => tarefa.CategoriaId)
                .HasColumnName("categoria_id");

        }
    }
}
