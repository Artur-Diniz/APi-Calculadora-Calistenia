using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API_Calistenia.Migrations
{
    /// <inheritdoc />
    public partial class AddBlogCreatedTimestamp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_EXERCICIO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dificuldade = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GpMuscular_1 = table.Column<int>(type: "int", nullable: false),
                    GpMuscular_2 = table.Column<int>(type: "int", nullable: false),
                    GpMuscular_3 = table.Column<int>(type: "int", nullable: false),
                    GpMuscular_4 = table.Column<int>(type: "int", nullable: false),
                    Exercicio_Facilitado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_EXERCICIO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_TREINOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rep_1 = table.Column<int>(type: "int", nullable: false),
                    Rep_2 = table.Column<int>(type: "int", nullable: true),
                    Rep_3 = table.Column<int>(type: "int", nullable: true),
                    Rep_4 = table.Column<int>(type: "int", nullable: true),
                    Rep_5 = table.Column<int>(type: "int", nullable: true),
                    Rep_6 = table.Column<int>(type: "int", nullable: true),
                    Rep_7 = table.Column<int>(type: "int", nullable: true),
                    Rep_8 = table.Column<int>(type: "int", nullable: true),
                    Rep_9 = table.Column<int>(type: "int", nullable: true),
                    Rep_10 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TREINOS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_REPSERIE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Repeticao = table.Column<int>(type: "int", nullable: false),
                    Serie = table.Column<int>(type: "int", nullable: false),
                    exercicioId = table.Column<int>(type: "int", nullable: false),
                    treinoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_REPSERIE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_REPSERIE_TB_EXERCICIO_exercicioId",
                        column: x => x.exercicioId,
                        principalTable: "TB_EXERCICIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_REPSERIE_TB_TREINOS_treinoId",
                        column: x => x.treinoId,
                        principalTable: "TB_TREINOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TB_EXERCICIO",
                columns: new[] { "Id", "Descricao", "Exercicio_Facilitado", "GpMuscular_1", "GpMuscular_2", "GpMuscular_3", "GpMuscular_4", "Modo", "Nome", "Tipo", "dificuldade" },
                values: new object[,]
                {
                    { 1, " ", "", 1, 2, 4, 0, "Repetição", "Flexão Padrão", "PUSH", 2 },
                    { 2, " ", "", 1, 2, 4, 5, "Repetição", "Flexão Pike", "PUSH", 3 },
                    { 3, " ", "", 10, 11, 0, 0, "Repetição", "Elevação de Pernas na barra", "CORE", 3 },
                    { 4, " ", "", 6, 3, 0, 0, "Repetição", "Barra Fixa Pronada", "PULL", 3 },
                    { 5, " ", "", 3, 8, 6, 0, "Repetição", "Barra Fixa Supinada", "PULL", 3 },
                    { 6, " ", "", 9, 0, 0, 0, "Repetição", "Flexão Lombar", "CORE", 2 },
                    { 7, " ", "", 12, 0, 0, 0, "Repetição", "Prancha Lateral", "CORE", 2 },
                    { 8, " ", "", 15, 14, 0, 0, "Repetição", "Afundos", "PERNA", 2 },
                    { 9, " ", "", 16, 0, 0, 0, "Repetição", "Elevação de Calcanhar", "PERNA", 2 }
                });

            migrationBuilder.InsertData(
                table: "TB_TREINOS",
                columns: new[] { "Id", "Descricao", "Nome", "Rep_1", "Rep_10", "Rep_2", "Rep_3", "Rep_4", "Rep_5", "Rep_6", "Rep_7", "Rep_8", "Rep_9", "Tipo" },
                values: new object[] { 1, "ta potente essa perna fibrada ai meu mano", "treino de Perna", 1, null, null, null, null, null, null, null, null, null, "PERNA" });

            migrationBuilder.InsertData(
                table: "TB_REPSERIE",
                columns: new[] { "Id", "Repeticao", "Serie", "exercicioId", "treinoId" },
                values: new object[,]
                {
                    { 1, 8, 3, 9, 1 },
                    { 2, 10, 2, 9, 1 },
                    { 3, 12, 2, 9, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_REPSERIE_exercicioId",
                table: "TB_REPSERIE",
                column: "exercicioId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_REPSERIE_treinoId",
                table: "TB_REPSERIE",
                column: "treinoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_REPSERIE");

            migrationBuilder.DropTable(
                name: "TB_EXERCICIO");

            migrationBuilder.DropTable(
                name: "TB_TREINOS");
        }
    }
}
