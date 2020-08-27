using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Migrations
{
    public partial class AddDrugStore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrugStores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugStores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drugs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tradename = table.Column<string>(nullable: false),
                    UmageUrl = table.Column<string>(nullable: true),
                    NonProprietaryName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Composition = table.Column<string>(nullable: true),
                    PharmacotherapeuticGroup = table.Column<string>(nullable: true),
                    PharmacotherapeuticProperties = table.Column<string>(nullable: true),
                    CodeATX = table.Column<string>(nullable: true),
                    ClinicalPharmacology = table.Column<string>(nullable: true),
                    Indications = table.Column<string>(nullable: true),
                    Usage = table.Column<string>(nullable: true),
                    Contraindications = table.Column<string>(nullable: true),
                    Warnings = table.Column<string>(nullable: true),
                    Precautions = table.Column<string>(nullable: true),
                    AdverseReactions = table.Column<string>(nullable: true),
                    Dependence = table.Column<string>(nullable: true),
                    Overdosage = table.Column<string>(nullable: true),
                    Dosage = table.Column<string>(nullable: true),
                    HowSupplied = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drugs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drugs_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DrugItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    IsRecipeNeeded = table.Column<int>(nullable: false),
                    DrugId = table.Column<int>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false),
                    DrugStoreId = table.Column<int>(nullable: true)
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

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Medtronic" },
                    { 3, "Cardinal Health" },
                    { 2, "Abbott" },
                    { 4, "Baxter " },
                    { 5, "Romfarm " }
                });

            migrationBuilder.InsertData(
                table: "Drugs",
                columns: new[] { "Id", "AdverseReactions", "ClinicalPharmacology", "CodeATX", "CompanyId", "Composition", "Contraindications", "Dependence", "Description", "Dosage", "HowSupplied", "Indications", "NonProprietaryName", "Overdosage", "PharmacotherapeuticGroup", "PharmacotherapeuticProperties", "Precautions", "Tradename", "UmageUrl", "Usage", "Warnings" },
                values: new object[] { 2, null, null, null, 1, null, null, null, null, null, null, null, null, null, null, null, null, "Almagel", null, null, null });

            migrationBuilder.InsertData(
                table: "Drugs",
                columns: new[] { "Id", "AdverseReactions", "ClinicalPharmacology", "CodeATX", "CompanyId", "Composition", "Contraindications", "Dependence", "Description", "Dosage", "HowSupplied", "Indications", "NonProprietaryName", "Overdosage", "PharmacotherapeuticGroup", "PharmacotherapeuticProperties", "Precautions", "Tradename", "UmageUrl", "Usage", "Warnings" },
                values: new object[] { 3, null, null, null, 2, null, null, null, null, null, null, null, null, null, null, null, null, "Colchicine", null, null, null });

            migrationBuilder.InsertData(
                table: "Drugs",
                columns: new[] { "Id", "AdverseReactions", "ClinicalPharmacology", "CodeATX", "CompanyId", "Composition", "Contraindications", "Dependence", "Description", "Dosage", "HowSupplied", "Indications", "NonProprietaryName", "Overdosage", "PharmacotherapeuticGroup", "PharmacotherapeuticProperties", "Precautions", "Tradename", "UmageUrl", "Usage", "Warnings" },
                values: new object[] { 1, null, null, null, 5, null, null, null, null, null, null, null, null, null, null, null, null, "Slezin", null, null, null });

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

            migrationBuilder.CreateIndex(
                name: "IX_Drugs_CompanyId",
                table: "Drugs",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrugItem");

            migrationBuilder.DropTable(
                name: "Drugs");

            migrationBuilder.DropTable(
                name: "DrugStores");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
