using Microsoft.EntityFrameworkCore.Migrations;

namespace RepublicManager.Api.Migrations
{
    public partial class prepopulatingcommonroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           migrationBuilder.InsertData(
           table: "Role",
           columns: new[] { "Id","RoleName" },
           values: new object[] { 1,"Usuário Padrão" });
            migrationBuilder.InsertData(
           table: "Role",
           columns: new[] { "Id", "RoleName" },
           values: new object[] { 2,"Gerente República" });
            migrationBuilder.InsertData(
           table: "Role",
           columns: new[] { "Id", "RoleName" },
           values: new object[] {3, "Administrador" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
