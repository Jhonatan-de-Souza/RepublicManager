using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RepublicManager.Api.Migrations
{
    public partial class AddingListOfRolesToUsuarioTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Roles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_UsuarioId",
                table: "Roles",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Usuario_UsuarioId",
                table: "Roles",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Usuario_UsuarioId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_UsuarioId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Roles");
        }
    }
}
