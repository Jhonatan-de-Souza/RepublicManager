using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace RepublicManager.Api.Migrations
{
    public partial class TornadoCampoDescricaoNaTabelaRegraObrigatorio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Regra",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CriadoPor = table.Column<int>(nullable: false),
                    DataRegistro = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 250, nullable: false),
                    RepublicaId = table.Column<int>(nullable: false),
                    isAtivo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regra", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Regra");
        }
    }
}
