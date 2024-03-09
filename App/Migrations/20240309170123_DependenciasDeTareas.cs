using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Migrations
{
    /// <inheritdoc />
    public partial class DependenciasDeTareas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TareaTarea",
                columns: table => new
                {
                    TareasHijasId = table.Column<int>(type: "integer", nullable: false),
                    TareasPaisId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TareaTarea", x => new { x.TareasHijasId, x.TareasPaisId });
                    table.ForeignKey(
                        name: "FK_TareaTarea_Tareas_TareasHijasId",
                        column: x => x.TareasHijasId,
                        principalTable: "Tareas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TareaTarea_Tareas_TareasPaisId",
                        column: x => x.TareasPaisId,
                        principalTable: "Tareas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TareaTarea_TareasPaisId",
                table: "TareaTarea",
                column: "TareasPaisId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TareaTarea");
        }
    }
}
