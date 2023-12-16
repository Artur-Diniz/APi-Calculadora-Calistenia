using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API_Calistenia.Migrations
{
    /// <inheritdoc />
    public partial class migracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TB_EXERCICIO",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TB_EXERCICIO",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TB_EXERCICIO",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TB_EXERCICIO",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TB_EXERCICIO",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TB_EXERCICIO",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TB_EXERCICIO",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TB_REPSERIE",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TB_REPSERIE",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TB_EXERCICIO",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "TB_USUARIO",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PassWord_H", "PassWord_S" },
                values: new object[] { new byte[] { 71, 194, 34, 185, 244, 185, 174, 244, 80, 23, 177, 183, 133, 30, 156, 232, 254, 56, 56, 206, 96, 190, 195, 171, 206, 201, 0, 14, 109, 51, 45, 173, 241, 18, 185, 41, 129, 81, 54, 18, 48, 130, 110, 31, 200, 255, 139, 61, 164, 13, 67, 180, 36, 184, 249, 13, 78, 119, 93, 134, 187, 148, 160, 55 }, new byte[] { 167, 209, 201, 129, 211, 104, 164, 181, 188, 135, 72, 102, 221, 134, 13, 28, 249, 145, 84, 144, 120, 206, 79, 176, 132, 103, 45, 81, 178, 12, 150, 145, 246, 31, 93, 143, 112, 149, 112, 16, 89, 43, 29, 152, 63, 133, 167, 242, 29, 17, 187, 140, 72, 88, 135, 213, 63, 92, 218, 159, 179, 144, 52, 131, 232, 174, 203, 50, 237, 86, 156, 177, 111, 173, 14, 35, 194, 36, 168, 99, 76, 65, 8, 64, 90, 237, 28, 32, 153, 85, 43, 229, 177, 115, 188, 169, 211, 0, 105, 31, 93, 162, 33, 210, 162, 71, 177, 177, 202, 247, 55, 27, 155, 193, 85, 138, 132, 133, 24, 60, 186, 127, 121, 19, 241, 180, 73, 230 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TB_EXERCICIO",
                columns: new[] { "Id", "Descricao", "Exercicio_Facilitado", "GpMuscular_1", "GpMuscular_2", "GpMuscular_3", "GpMuscular_4", "Modo", "Nome", "Tipo", "dificuldade" },
                values: new object[,]
                {
                    { 2, " ", "", 1, 2, 4, 5, "Repetição", "Flexão Pike", "PUSH", 3 },
                    { 3, " ", "", 10, 11, 0, 0, "Repetição", "Elevação de Pernas na barra", "CORE", 3 },
                    { 4, " ", "", 6, 3, 0, 0, "Repetição", "Barra Fixa Pronada", "PULL", 3 },
                    { 5, " ", "", 3, 8, 6, 0, "Repetição", "Barra Fixa Supinada", "PULL", 3 },
                    { 6, " ", "", 9, 0, 0, 0, "Repetição", "Flexão Lombar", "CORE", 2 },
                    { 7, " ", "", 12, 0, 0, 0, "Repetição", "Prancha Lateral", "CORE", 2 },
                    { 8, " ", "", 15, 14, 0, 0, "Repetição", "Afundos", "PERNA", 2 },
                    { 9, " ", "", 16, 0, 0, 0, "Repetição", "Elevação de Calcanhar", "PERNA", 2 }
                });

            migrationBuilder.UpdateData(
                table: "TB_USUARIO",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PassWord_H", "PassWord_S" },
                values: new object[] { new byte[] { 3, 7, 217, 60, 2, 26, 229, 204, 35, 62, 30, 137, 245, 31, 166, 166, 183, 229, 196, 27, 70, 147, 202, 134, 228, 114, 63, 113, 152, 184, 154, 209, 145, 231, 13, 90, 140, 250, 228, 194, 120, 206, 99, 120, 101, 253, 250, 17, 131, 196, 70, 55, 232, 251, 64, 88, 154, 94, 166, 89, 199, 183, 189, 103 }, new byte[] { 227, 121, 122, 119, 21, 228, 18, 169, 44, 151, 192, 122, 44, 23, 197, 26, 80, 69, 179, 135, 0, 155, 57, 2, 100, 64, 218, 128, 1, 103, 106, 91, 128, 115, 60, 172, 134, 10, 168, 203, 33, 152, 79, 219, 161, 46, 0, 120, 56, 229, 189, 152, 63, 20, 169, 225, 97, 91, 6, 25, 94, 92, 197, 12, 149, 90, 22, 229, 158, 59, 63, 187, 168, 156, 215, 220, 201, 57, 148, 152, 20, 72, 144, 129, 32, 111, 95, 227, 7, 22, 225, 34, 214, 74, 188, 125, 215, 49, 79, 20, 137, 222, 242, 166, 128, 22, 188, 62, 12, 38, 104, 27, 114, 79, 116, 212, 75, 67, 104, 208, 241, 233, 57, 68, 162, 98, 233, 137 } });

            migrationBuilder.InsertData(
                table: "TB_REPSERIE",
                columns: new[] { "Id", "Repeticao", "Serie", "exercicioId", "treinoId" },
                values: new object[,]
                {
                    { 2, 10, 2, 9, 1 },
                    { 3, 12, 2, 9, 1 }
                });
        }
    }
}
