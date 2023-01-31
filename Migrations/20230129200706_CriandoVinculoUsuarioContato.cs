using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteMVC.Migrations
{
    public partial class CriandoVinculoUsuarioContato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioModelId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Contatos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_UsuarioModelId",
                table: "Usuarios",
                column: "UsuarioModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_UsuarioId",
                table: "Contatos",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_Usuarios_UsuarioId",
                table: "Contatos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Usuarios_UsuarioModelId",
                table: "Usuarios",
                column: "UsuarioModelId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_Usuarios_UsuarioId",
                table: "Contatos");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Usuarios_UsuarioModelId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_UsuarioModelId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Contatos_UsuarioId",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "UsuarioModelId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Contatos");
        }
    }
}
