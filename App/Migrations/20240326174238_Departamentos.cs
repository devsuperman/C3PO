using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace App.Migrations
{
    /// <inheritdoc />
    public partial class Departamentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Tareas");

            migrationBuilder.DropColumn(
                name: "Responsable",
                table: "Tareas");

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoId",
                table: "Tareas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_DepartamentoId",
                table: "Tareas",
                column: "DepartamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tareas_Departamentos_DepartamentoId",
                table: "Tareas",
                column: "DepartamentoId",
                principalTable: "Departamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tareas_Departamentos_DepartamentoId",
                table: "Tareas");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropIndex(
                name: "IX_Tareas_DepartamentoId",
                table: "Tareas");

            migrationBuilder.DropColumn(
                name: "DepartamentoId",
                table: "Tareas");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Tareas",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Responsable",
                table: "Tareas",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
