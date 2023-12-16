using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Calistenia.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "TB_TREINOS",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TB_USUARIO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    U_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassWord_H = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PassWord_S = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    Dt_Acesso = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Perfil = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Usuario"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USUARIO", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "TB_TREINOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Rep_2", "UsuarioId" },
                values: new object[] { 3, null });

            migrationBuilder.InsertData(
                table: "TB_USUARIO",
                columns: new[] { "Id", "Dt_Acesso", "Email", "Foto", "Latitude", "Longitude", "PassWord_H", "PassWord_S", "Perfil", "U_Name" },
                values: new object[] { 1, null, "arturdiniz06@gmail.com", null, -23.520024100000001, -46.596497999999997, new byte[] { 167, 149, 184, 175, 194, 230, 236, 163, 148, 58, 241, 8, 128, 23, 21, 101, 166, 244, 205, 10, 21, 204, 28, 62, 97, 175, 40, 157, 250, 22, 206, 97, 167, 218, 103, 202, 141, 98, 40, 222, 18, 38, 239, 90, 90, 87, 83, 124, 59, 7, 85, 179, 84, 36, 252, 36, 178, 91, 17, 238, 206, 191, 255, 81 }, new byte[] { 116, 63, 152, 220, 188, 64, 209, 247, 233, 157, 254, 187, 4, 137, 41, 116, 244, 151, 113, 190, 36, 254, 218, 203, 160, 97, 3, 12, 34, 145, 58, 28, 24, 125, 161, 150, 199, 70, 19, 67, 24, 115, 246, 117, 197, 160, 98, 126, 100, 236, 76, 114, 56, 118, 121, 76, 4, 61, 198, 204, 239, 208, 87, 194, 5, 40, 51, 227, 231, 161, 163, 246, 219, 217, 61, 234, 7, 88, 208, 35, 131, 176, 73, 207, 38, 124, 81, 117, 17, 154, 161, 185, 3, 235, 241, 48, 233, 238, 182, 229, 225, 159, 174, 103, 163, 119, 190, 249, 253, 13, 33, 126, 225, 149, 144, 100, 198, 71, 246, 162, 206, 186, 56, 175, 85, 37, 78, 149 }, "Admin", "UsuarioAdmin" });

            migrationBuilder.CreateIndex(
                name: "IX_TB_TREINOS_UsuarioId",
                table: "TB_TREINOS",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_TREINOS_TB_USUARIO_UsuarioId",
                table: "TB_TREINOS",
                column: "UsuarioId",
                principalTable: "TB_USUARIO",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_TREINOS_TB_USUARIO_UsuarioId",
                table: "TB_TREINOS");

            migrationBuilder.DropTable(
                name: "TB_USUARIO");

            migrationBuilder.DropIndex(
                name: "IX_TB_TREINOS_UsuarioId",
                table: "TB_TREINOS");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "TB_TREINOS");

            migrationBuilder.UpdateData(
                table: "TB_TREINOS",
                keyColumn: "Id",
                keyValue: 1,
                column: "Rep_2",
                value: null);
        }
    }
}
