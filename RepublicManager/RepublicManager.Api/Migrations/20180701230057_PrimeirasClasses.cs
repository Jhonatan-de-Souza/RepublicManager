using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RepublicManager.Api.Migrations
{
    public partial class PrimeirasClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aviso",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CriadoPor = table.Column<int>(nullable: false),
                    DataAviso = table.Column<DateTime>(nullable: false),
                    DataRegistro = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 250, nullable: false),
                    isAtivo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aviso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarrinhoDeCompra",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CriadoPor = table.Column<int>(nullable: false),
                    DataRegistro = table.Column<DateTime>(nullable: false),
                    RepublicaId = table.Column<int>(nullable: false),
                    isAtivo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrinhoDeCompra", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CarrinhoDeCompraId = table.Column<int>(nullable: false),
                    CriadoPor = table.Column<int>(nullable: false),
                    DataRegistro = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 250, nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    isAtivo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_CarrinhoDeCompra_CarrinhoDeCompraId",
                        column: x => x.CarrinhoDeCompraId,
                        principalTable: "CarrinhoDeCompra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produto_CarrinhoDeCompraId",
                table: "Produto",
                column: "CarrinhoDeCompraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aviso");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "CarrinhoDeCompra");
        }
    }
}
