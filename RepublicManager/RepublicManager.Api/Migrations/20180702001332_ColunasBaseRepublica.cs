using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RepublicManager.Api.Migrations
{
    public partial class ColunasBaseRepublica : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CriadoPor",
                table: "Republicas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataRegistro",
                table: "Republicas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "isAtivo",
                table: "Republicas",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CriadoPor",
                table: "Republicas");

            migrationBuilder.DropColumn(
                name: "DataRegistro",
                table: "Republicas");

            migrationBuilder.DropColumn(
                name: "isAtivo",
                table: "Republicas");
        }
    }
}
