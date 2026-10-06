using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TarefasComCategorias.Migrations
{
    /// <inheritdoc />
    public partial class ValorPadraoParaDataDeCriacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "data_criacao_tarefa",
                table: "Tarefas",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(2026, 10, 6),
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "data_criacao_tarefa",
                table: "Tarefas",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldDefaultValue: new DateOnly(2026, 10, 6));
        }
    }
}
