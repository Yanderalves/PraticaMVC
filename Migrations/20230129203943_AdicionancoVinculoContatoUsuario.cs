using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteMVC.Migrations
{
    public partial class AdicionancoVinculoContatoUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Usuarios_UsuarioModelId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_UsuarioModelId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "UsuarioModelId",
                table: "Usuarios");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioModelId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_UsuarioModelId",
                table: "Usuarios",
                column: "UsuarioModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Usuarios_UsuarioModelId",
                table: "Usuarios",
                column: "UsuarioModelId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }
    }
}
