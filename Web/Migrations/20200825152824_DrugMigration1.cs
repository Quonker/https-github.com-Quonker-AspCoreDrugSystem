using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Migrations
{
    public partial class DrugMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrugItem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DrugItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    DrugId = table.Column<int>(type: "int", nullable: false),
                    DrugStoreId = table.Column<int>(type: "int", nullable: true),
                    IsRecipeNeeded = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrugItem_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrugItem_Drugs_DrugId",
                        column: x => x.DrugId,
                        principalTable: "Drugs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrugItem_DrugStores_DrugStoreId",
                        column: x => x.DrugStoreId,
                        principalTable: "DrugStores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DrugItem_CompanyId",
                table: "DrugItem",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_DrugItem_DrugId",
                table: "DrugItem",
                column: "DrugId");

            migrationBuilder.CreateIndex(
                name: "IX_DrugItem_DrugStoreId",
                table: "DrugItem",
                column: "DrugStoreId");
        }
    }
}
