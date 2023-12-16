using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Calistenia.Migrations
{
    /// <inheritdoc />
    public partial class @in : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_REPSERIE_TB_TREINOS_treinoId",
                table: "TB_REPSERIE");

            migrationBuilder.AlterColumn<int>(
                name: "treinoId",
                table: "TB_REPSERIE",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "TB_USUARIO",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PassWord_H", "PassWord_S" },
                values: new object[] { new byte[] { 3, 7, 217, 60, 2, 26, 229, 204, 35, 62, 30, 137, 245, 31, 166, 166, 183, 229, 196, 27, 70, 147, 202, 134, 228, 114, 63, 113, 152, 184, 154, 209, 145, 231, 13, 90, 140, 250, 228, 194, 120, 206, 99, 120, 101, 253, 250, 17, 131, 196, 70, 55, 232, 251, 64, 88, 154, 94, 166, 89, 199, 183, 189, 103 }, new byte[] { 227, 121, 122, 119, 21, 228, 18, 169, 44, 151, 192, 122, 44, 23, 197, 26, 80, 69, 179, 135, 0, 155, 57, 2, 100, 64, 218, 128, 1, 103, 106, 91, 128, 115, 60, 172, 134, 10, 168, 203, 33, 152, 79, 219, 161, 46, 0, 120, 56, 229, 189, 152, 63, 20, 169, 225, 97, 91, 6, 25, 94, 92, 197, 12, 149, 90, 22, 229, 158, 59, 63, 187, 168, 156, 215, 220, 201, 57, 148, 152, 20, 72, 144, 129, 32, 111, 95, 227, 7, 22, 225, 34, 214, 74, 188, 125, 215, 49, 79, 20, 137, 222, 242, 166, 128, 22, 188, 62, 12, 38, 104, 27, 114, 79, 116, 212, 75, 67, 104, 208, 241, 233, 57, 68, 162, 98, 233, 137 } });

            migrationBuilder.AddForeignKey(
                name: "FK_TB_REPSERIE_TB_TREINOS_treinoId",
                table: "TB_REPSERIE",
                column: "treinoId",
                principalTable: "TB_TREINOS",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_REPSERIE_TB_TREINOS_treinoId",
                table: "TB_REPSERIE");

            migrationBuilder.AlterColumn<int>(
                name: "treinoId",
                table: "TB_REPSERIE",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "TB_USUARIO",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PassWord_H", "PassWord_S" },
                values: new object[] { new byte[] { 68, 178, 137, 126, 223, 202, 62, 204, 235, 109, 171, 187, 107, 45, 123, 127, 233, 224, 0, 8, 90, 156, 248, 132, 232, 137, 181, 48, 101, 121, 12, 96, 244, 3, 20, 93, 102, 77, 139, 9, 43, 202, 207, 94, 221, 73, 141, 91, 188, 41, 100, 48, 190, 20, 6, 182, 142, 62, 152, 105, 216, 193, 226, 68 }, new byte[] { 98, 29, 246, 76, 72, 90, 69, 170, 191, 125, 54, 184, 79, 141, 176, 71, 34, 157, 53, 85, 17, 183, 173, 119, 10, 104, 77, 87, 164, 175, 162, 25, 14, 144, 114, 132, 78, 40, 245, 255, 225, 151, 27, 16, 60, 60, 172, 158, 252, 174, 229, 4, 61, 13, 244, 93, 167, 84, 230, 22, 93, 221, 224, 244, 49, 37, 233, 84, 112, 161, 84, 94, 43, 211, 80, 211, 239, 92, 62, 169, 74, 78, 5, 157, 103, 96, 40, 100, 136, 155, 171, 245, 72, 73, 174, 41, 210, 35, 171, 9, 116, 216, 73, 4, 116, 221, 25, 155, 210, 8, 148, 244, 172, 186, 167, 11, 147, 103, 10, 187, 24, 97, 141, 120, 97, 169, 221, 8 } });

            migrationBuilder.AddForeignKey(
                name: "FK_TB_REPSERIE_TB_TREINOS_treinoId",
                table: "TB_REPSERIE",
                column: "treinoId",
                principalTable: "TB_TREINOS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
