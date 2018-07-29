using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace RepublicManager.Api.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Republica",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CriadoPor = table.Column<int>(),
                    DataRegistro = table.Column<DateTime>(),
                    IsAtivo = table.Column<bool>(),
                    Nome = table.Column<string>(maxLength: 100),
                    Vagas = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Republica", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tarefa",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CriadoPor = table.Column<int>(),
                    DataRegistro = table.Column<DateTime>(),
                    Descricao = table.Column<string>(maxLength: 150, nullable: true),
                    IsAtivo = table.Column<bool>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoContas",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CriadoPor = table.Column<int>(),
                    DataRegistro = table.Column<DateTime>(),
                    Descricao = table.Column<string>(nullable: true),
                    IsAtivo = table.Column<bool>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoContas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Aviso",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CriadoPor = table.Column<int>(),
                    DataAviso = table.Column<DateTime>(),
                    DataRegistro = table.Column<DateTime>(),
                    Descricao = table.Column<string>(maxLength: 250),
                    IsAtivo = table.Column<bool>(),
                    RepublicaId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aviso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aviso_Republica_RepublicaId",
                        column: x => x.RepublicaId,
                        principalTable: "Republica",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CarrinhoDeCompra",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CriadoPor = table.Column<int>(),
                    DataRegistro = table.Column<DateTime>(),
                    IsAtivo = table.Column<bool>(),
                    RepublicaId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrinhoDeCompra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarrinhoDeCompra_Republica_RepublicaId",
                        column: x => x.RepublicaId,
                        principalTable: "Republica",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Regras",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CriadoPor = table.Column<int>(),
                    DataRegistro = table.Column<DateTime>(),
                    Descricao = table.Column<string>(maxLength: 250),
                    IsAtivo = table.Column<bool>(),
                    RepublicaId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Regras_Republica_RepublicaId",
                        column: x => x.RepublicaId,
                        principalTable: "Republica",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContaId = table.Column<int>(nullable: true),
                    CriadoPor = table.Column<int>(),
                    DataFinalContrato = table.Column<DateTime>(),
                    DataRegistro = table.Column<DateTime>(),
                    IsAtivo = table.Column<bool>(),
                    Login = table.Column<string>(),
                    RepublicaId = table.Column<int>(nullable: true),
                    Senha = table.Column<string>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Republica_RepublicaId",
                        column: x => x.RepublicaId,
                        principalTable: "Republica",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CarrinhoDeCompraId = table.Column<int>(),
                    CriadoPor = table.Column<int>(),
                    DataRegistro = table.Column<DateTime>(),
                    Descricao = table.Column<string>(maxLength: 250),
                    IsAtivo = table.Column<bool>(),
                    UsuarioId = table.Column<int>(),
                    Valor = table.Column<decimal>(type: "decimal(18, 2)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_CarrinhoDeCompra_CarrinhoDeCompraId",
                        column: x => x.CarrinhoDeCompraId,
                        principalTable: "CarrinhoDeCompra",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Contas",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CriadoPor = table.Column<int>(),
                    DataRegistro = table.Column<DateTime>(),
                    IsAtivo = table.Column<bool>(),
                    UsuarioId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contas_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TarefasUsuario",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(),
                    TarefaId = table.Column<int>(),
                    ComentarioAvaliacao = table.Column<string>(maxLength: 250, nullable: true),
                    CriadoPor = table.Column<int>(),
                    DataDaTarefa = table.Column<DateTime>(),
                    DataRegistro = table.Column<DateTime>(),
                    IsAtivo = table.Column<bool>(),
                    IsCompleted = table.Column<bool>(),
                    NotaAvaliacao = table.Column<int>(),
                    PrevisaoDeConclusao = table.Column<DateTime>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TarefasUsuario", x => new { x.UsuarioId, x.TarefaId });
                    table.ForeignKey(
                        name: "FK_TarefasUsuario_Tarefa_TarefaId",
                        column: x => x.TarefaId,
                        principalTable: "Tarefa",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TarefasUsuario_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContasAPagar",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContaId = table.Column<int>(),
                    CriadoPor = table.Column<int>(),
                    DataRegistro = table.Column<DateTime>(),
                    IsAtivo = table.Column<bool>(),
                    TipoContaId = table.Column<int>(),
                    Valor = table.Column<decimal>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasAPagar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContasAPagar_Contas_ContaId",
                        column: x => x.ContaId,
                        principalTable: "Contas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContasAPagar_TipoContas_TipoContaId",
                        column: x => x.TipoContaId,
                        principalTable: "TipoContas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContasAReceber",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContaId = table.Column<int>(),
                    CriadoPor = table.Column<int>(),
                    DataRegistro = table.Column<DateTime>(),
                    IsAtivo = table.Column<bool>(),
                    TipoContaId = table.Column<int>(),
                    Valor = table.Column<decimal>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasAReceber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContasAReceber_Contas_ContaId",
                        column: x => x.ContaId,
                        principalTable: "Contas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContasAReceber_TipoContas_TipoContaId",
                        column: x => x.TipoContaId,
                        principalTable: "TipoContas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aviso_RepublicaId",
                table: "Aviso",
                column: "RepublicaId");

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoDeCompra_RepublicaId",
                table: "CarrinhoDeCompra",
                column: "RepublicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Contas_UsuarioId",
                table: "Contas",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContasAPagar_ContaId",
                table: "ContasAPagar",
                column: "ContaId");

            migrationBuilder.CreateIndex(
                name: "IX_ContasAPagar_TipoContaId",
                table: "ContasAPagar",
                column: "TipoContaId");

            migrationBuilder.CreateIndex(
                name: "IX_ContasAReceber_ContaId",
                table: "ContasAReceber",
                column: "ContaId");

            migrationBuilder.CreateIndex(
                name: "IX_ContasAReceber_TipoContaId",
                table: "ContasAReceber",
                column: "TipoContaId");

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
                name: "IX_Usuario_RepublicaId",
                table: "Usuario",
                column: "RepublicaId");
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
                name: "Tarefa");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Republica");
        }
    }
}
