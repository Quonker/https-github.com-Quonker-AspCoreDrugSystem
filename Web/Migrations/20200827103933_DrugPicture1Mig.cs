using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Migrations
{
    public partial class DrugPicture1Mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdverseReactions",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "ClinicalPharmacology",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "CodeATX",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "Composition",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "Contraindications",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "Dependence",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "Dosage",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "HowSupplied",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "Indications",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "NonProprietaryName",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "Overdosage",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "PharmacotherapeuticGroup",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "PharmacotherapeuticProperties",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "Precautions",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "UmageUrl",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "Usage",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "Warnings",
                table: "Drugs");

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Drugs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Path",
                table: "Drugs");

            migrationBuilder.AddColumn<string>(
                name: "AdverseReactions",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClinicalPharmacology",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodeATX",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Composition",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Contraindications",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Dependence",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Dosage",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HowSupplied",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Indications",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NonProprietaryName",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Overdosage",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PharmacotherapeuticGroup",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PharmacotherapeuticProperties",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Precautions",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UmageUrl",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Usage",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Warnings",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
