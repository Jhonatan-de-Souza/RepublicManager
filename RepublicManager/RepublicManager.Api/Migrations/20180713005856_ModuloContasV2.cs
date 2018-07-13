using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RepublicManager.Api.Migrations
{
    public partial class ModuloContasV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contas_Usuario_UsuarioId",
                table: "Contas");

            migrationBuilder.DropIndex(
                name: "IX_Contas_UsuarioId",
                table: "Contas");

            migrationBuilder.AddColumn<int>(
                name: "ContaId",
                table: "Usuario",
                //nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_ContaId",
                table: "Usuario",
                column: "ContaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Contas_ContaId",
                table: "Usuario",
                column: "ContaId",
                principalTable: "Contas",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Contas_ContaId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_ContaId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "ContaId",
                table: "Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Contas_UsuarioId",
                table: "Contas",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_Usuario_UsuarioId",
                table: "Contas",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
