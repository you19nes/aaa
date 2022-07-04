using Microsoft.EntityFrameworkCore.Migrations;

namespace aaa.Migrations
{
    public partial class Initiazcz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttestionTravails_AttestionTravails_AttestionTravailId1",
                table: "AttestionTravails");

            migrationBuilder.DropIndex(
                name: "IX_AttestionTravails_AttestionTravailId1",
                table: "AttestionTravails");

            migrationBuilder.DropColumn(
                name: "AttestionTravailId1",
                table: "AttestionTravails");

            migrationBuilder.RenameColumn(
                name: "PrenomParronmere",
                table: "dossiers",
                newName: "wilaia");

            migrationBuilder.RenameColumn(
                name: "PrenomParronPere",
                table: "dossiers",
                newName: "safha");

            migrationBuilder.RenameColumn(
                name: "NomeParronmere",
                table: "dossiers",
                newName: "pre");

            migrationBuilder.RenameColumn(
                name: "NomeParronPere",
                table: "dossiers",
                newName: "onwan");

            migrationBuilder.RenameColumn(
                name: "Périondes",
                table: "AttestionDeSalaires",
                newName: "PériondesD");

            migrationBuilder.AddColumn<string>(
                name: "Adressedenaissence",
                table: "dossiers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Lemployeursoussigné",
                table: "dossiers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NASASSURE",
                table: "dossiers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NSSEMPLOYEUR",
                table: "dossiers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ParronPere",
                table: "dossiers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Parronmere",
                table: "dossiers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Titredecivilite",
                table: "dossiers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "makan",
                table: "dossiers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "mihna",
                table: "dossiers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "nom",
                table: "dossiers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PériondesA",
                table: "AttestionDeSalaires",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adressedenaissence",
                table: "dossiers");

            migrationBuilder.DropColumn(
                name: "Lemployeursoussigné",
                table: "dossiers");

            migrationBuilder.DropColumn(
                name: "NASASSURE",
                table: "dossiers");

            migrationBuilder.DropColumn(
                name: "NSSEMPLOYEUR",
                table: "dossiers");

            migrationBuilder.DropColumn(
                name: "ParronPere",
                table: "dossiers");

            migrationBuilder.DropColumn(
                name: "Parronmere",
                table: "dossiers");

            migrationBuilder.DropColumn(
                name: "Titredecivilite",
                table: "dossiers");

            migrationBuilder.DropColumn(
                name: "makan",
                table: "dossiers");

            migrationBuilder.DropColumn(
                name: "mihna",
                table: "dossiers");

            migrationBuilder.DropColumn(
                name: "nom",
                table: "dossiers");

            migrationBuilder.DropColumn(
                name: "PériondesA",
                table: "AttestionDeSalaires");

            migrationBuilder.RenameColumn(
                name: "wilaia",
                table: "dossiers",
                newName: "PrenomParronmere");

            migrationBuilder.RenameColumn(
                name: "safha",
                table: "dossiers",
                newName: "PrenomParronPere");

            migrationBuilder.RenameColumn(
                name: "pre",
                table: "dossiers",
                newName: "NomeParronmere");

            migrationBuilder.RenameColumn(
                name: "onwan",
                table: "dossiers",
                newName: "NomeParronPere");

            migrationBuilder.RenameColumn(
                name: "PériondesD",
                table: "AttestionDeSalaires",
                newName: "Périondes");

            migrationBuilder.AddColumn<int>(
                name: "AttestionTravailId1",
                table: "AttestionTravails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AttestionTravails_AttestionTravailId1",
                table: "AttestionTravails",
                column: "AttestionTravailId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AttestionTravails_AttestionTravails_AttestionTravailId1",
                table: "AttestionTravails",
                column: "AttestionTravailId1",
                principalTable: "AttestionTravails",
                principalColumn: "AttestionTravailId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
