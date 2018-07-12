using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RepublicManager.Api.Migrations
{
    public partial class RecreateDataBase : Migration
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
                    IsAtivo = table.Column<bool>(nullable: false)
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
                    IsAtivo = table.Column<bool>(nullable: false),
                    RepublicaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrinhoDeCompra", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Republica",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CriadoPor = table.Column<int>(nullable: false),
                    DataRegistro = table.Column<DateTime>(nullable: false),
                    IsAtivo = table.Column<bool>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Vagas = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Republica", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tarefa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CriadoPor = table.Column<int>(nullable: false),
                    DataRegistro = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 150, nullable: true),
                    IsAtivo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoContas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CriadoPor = table.Column<int>(nullable: false),
                    DataRegistro = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    IsAtivo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoContas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CriadoPor = table.Column<int>(nullable: false),
                    DataFinalContrato = table.Column<DateTime>(nullable: false),
                    DataRegistro = table.Column<DateTime>(nullable: false),
                    IsAtivo = table.Column<bool>(nullable: false),
                    Login = table.Column<string>(nullable: false),
                    Senha = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
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
                    IsAtivo = table.Column<bool>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_CarrinhoDeCompra_CarrinhoDeCompraId",
                        column: x => x.CarrinhoDeCompraId,
                        principalTable: "CarrinhoDeCompra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Regras",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CriadoPor = table.Column<int>(nullable: false),
                    DataRegistro = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 250, nullable: false),
                    IsAtivo = table.Column<bool>(nullable: false),
                    RepublicaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Regras_Republica_RepublicaId",
                        column: x => x.RepublicaId,
                        principalTable: "Republica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Contas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CriadoPor = table.Column<int>(nullable: false),
                    DataRegistro = table.Column<DateTime>(nullable: false),
                    IsAtivo = table.Column<bool>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contas_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TarefasUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ComentarioAvaliacao = table.Column<string>(maxLength: 250, nullable: true),
                    CriadoPor = table.Column<int>(nullable: false),
                    DataDaTarefa = table.Column<DateTime>(nullable: false),
                    DataRegistro = table.Column<DateTime>(nullable: false),
                    IsAtivo = table.Column<bool>(nullable: false),
                    IsCompleted = table.Column<bool>(nullable: false),
                    NotaAvaliacao = table.Column<int>(nullable: false),
                    PrevisaoDeConclusao = table.Column<DateTime>(nullable: false),
                    TarefaId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TarefasUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TarefasUsuario_Tarefa_TarefaId",
                        column: x => x.TarefaId,
                        principalTable: "Tarefa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TarefasUsuario_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ContasAPagar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContaId = table.Column<int>(nullable: false),
                    CriadoPor = table.Column<int>(nullable: false),
                    DataRegistro = table.Column<DateTime>(nullable: false),
                    IsAtivo = table.Column<bool>(nullable: false),
                    TipoContaId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasAPagar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContasAPagar_Contas_ContaId",
                        column: x => x.ContaId,
                        principalTable: "Contas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ContasAPagar_TipoContas_TipoContaId",
                        column: x => x.TipoContaId,
                        principalTable: "TipoContas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ContasAPagar_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ContasAReceber",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContaId = table.Column<int>(nullable: false),
                    CriadoPor = table.Column<int>(nullable: false),
                    DataRegistro = table.Column<DateTime>(nullable: false),
                    IsAtivo = table.Column<bool>(nullable: false),
                    TipoContaId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasAReceber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContasAReceber_Contas_ContaId",
                        column: x => x.ContaId,
                        principalTable: "Contas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ContasAReceber_TipoContas_TipoContaId",
                        column: x => x.TipoContaId,
                        principalTable: "TipoContas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ContasAReceber_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contas_UsuarioId",
                table: "Contas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ContasAPagar_ContaId",
                table: "ContasAPagar",
                column: "ContaId");

            migrationBuilder.CreateIndex(
                name: "IX_ContasAPagar_TipoContaId",
                table: "ContasAPagar",
                column: "TipoContaId");

            migrationBuilder.CreateIndex(
                name: "IX_ContasAPagar_UsuarioId",
                table: "ContasAPagar",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ContasAReceber_ContaId",
                table: "ContasAReceber",
                column: "ContaId");

            migrationBuilder.CreateIndex(
                name: "IX_ContasAReceber_TipoContaId",
                table: "ContasAReceber",
                column: "TipoContaId");

            migrationBuilder.CreateIndex(
                name: "IX_ContasAReceber_UsuarioId",
                table: "ContasAReceber",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_CarrinhoDeCompraId",
                table: "Produto",
                column: "CarrinhoDeCompraId");

            migrationBuilder.CreateIndex(
                name: "IX_Regras_RepublicaId",
                table: "Regras",
                column: "RepublicaId");

            migrationBuilder.CreateIndex(
                name: "IX_TarefasUsuario_TarefaId",
                table: "TarefasUsuario",
                column: "TarefaId");

            migrationBuilder.CreateIndex(
                name: "IX_TarefasUsuario_UsuarioId",
                table: "TarefasUsuario",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aviso");

            migrationBuilder.DropTable(
                name: "ContasAPagar");

            migrationBuilder.DropTable(
                name: "ContasAReceber");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Regras");

            migrationBuilder.DropTable(
                name: "TarefasUsuario");

            migrationBuilder.DropTable(
                name: "Contas");

            migrationBuilder.DropTable(
                name: "TipoContas");

            migrationBuilder.DropTable(
                name: "CarrinhoDeCompra");

            migrationBuilder.DropTable(
                name: "Republica");

            migrationBuilder.DropTable(
                name: "Tarefa");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
