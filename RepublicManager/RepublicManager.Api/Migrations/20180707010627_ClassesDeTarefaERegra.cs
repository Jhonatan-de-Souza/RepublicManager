using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace RepublicManager.Api.Migrations
{
    public partial class ClassesDeTarefaERegra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tarefa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CriadoPor = table.Column<int>(nullable: false),
                    DataRegistro = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    isAtivo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TarefasUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ComentarioAvaliacao = table.Column<string>(nullable: true),
                    CriadoPor = table.Column<int>(nullable: false),
                    DataDaTarefa = table.Column<DateTime>(nullable: false),
                    DataFimDaTarefa = table.Column<DateTime>(nullable: false),
                    DataRegistro = table.Column<DateTime>(nullable: false),
                    NotaAvaliacao = table.Column<int>(nullable: false),
                    TarefaId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    isAtivo = table.Column<bool>(nullable: false),
                    isCompleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TarefasUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TarefasUsuario_Tarefa_TarefaId",
                        column: x => x.TarefaId,
                        principalTable: "Tarefa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TarefasUsuario_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "TarefasUsuario");

            migrationBuilder.DropTable(
                name: "Tarefa");
        }
    }
}
