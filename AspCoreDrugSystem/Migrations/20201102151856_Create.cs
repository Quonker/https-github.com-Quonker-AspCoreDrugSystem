using Microsoft.EntityFrameworkCore.Migrations;

namespace AspCoreDrugSystem.Migrations
{
    public partial class Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drugs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tradename = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drugs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Drugs",
                columns: new[] { "Id", "Tradename" },
                values: new object[] { 1, "Slezin" });

            migrationBuilder.InsertData(
                table: "Drugs",
                columns: new[] { "Id", "Tradename" },
                values: new object[] { 2, "Almagel" });

            migrationBuilder.InsertData(
                table: "Drugs",
                columns: new[] { "Id", "Tradename" },
                values: new object[] { 3, "Colchicine" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drugs");
        }
    }
}
