using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace aaa.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "dossiers",
                columns: table => new
                {
                    DossierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EmployeePrenom = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DeteNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NaissanceWilaya = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Qualite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeParronPere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrenomParronPere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeParronmere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrenomParronmere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroAllocationFamilailes = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false),
                    NumeroAllocationAssure = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false),
                    NumeroSocialesFamilailes = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false),
                    NumeroSocialesAssure = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false),
                    DubutTravail = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinTravail = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Etat = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dossiers", x => x.DossierId);
                });

            migrationBuilder.CreateTable(
                name: "AttestionDeCesseison",
                schema: "dbo",
                columns: table => new
                {
                    AttestionDeCesseisonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DossierId = table.Column<int>(type: "int", nullable: false),
                    Nom_ET_Prenom = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    RaisonSociale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NDassurance = table.Column<decimal>(type: "numeric(12)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttestionDeCesseison", x => x.AttestionDeCesseisonId);
                    table.ForeignKey(
                        name: "FK_AttestionDeCesseison_dossiers_DossierId",
                        column: x => x.DossierId,
                        principalTable: "dossiers",
                        principalColumn: "DossierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttestionDeSalaires",
                columns: table => new
                {
                    AttestionDeSalaireId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DossierId = table.Column<int>(type: "int", nullable: false),
                    AttestionDeSalaireAnnee = table.Column<int>(type: "int", nullable: false),
                    Périondes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DuréeDuTravail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalaireSoumisRetenue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DésignationDeLemploi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DesiguationDeLaClasseDallocation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttestionDeSalaires", x => x.AttestionDeSalaireId);
                    table.ForeignKey(
                        name: "FK_AttestionDeSalaires_dossiers_DossierId",
                        column: x => x.DossierId,
                        principalTable: "dossiers",
                        principalColumn: "DossierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttestionTravails",
                columns: table => new
                {
                    AttestionTravailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DossierId = table.Column<int>(type: "int", nullable: false),
                    PeriodeReference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalaireSoumisCotisation = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttestionTravails", x => x.AttestionTravailId);
                    table.ForeignKey(
                        name: "FK_AttestionTravails_dossiers_DossierId",
                        column: x => x.DossierId,
                        principalTable: "dossiers",
                        principalColumn: "DossierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttestionDeCesseison_DossierId",
                schema: "dbo",
                table: "AttestionDeCesseison",
                column: "DossierId");

            migrationBuilder.CreateIndex(
                name: "IX_AttestionDeSalaires_DossierId",
                table: "AttestionDeSalaires",
                column: "DossierId");

            migrationBuilder.CreateIndex(
                name: "IX_AttestionTravails_DossierId",
                table: "AttestionTravails",
                column: "DossierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttestionDeCesseison",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AttestionDeSalaires");

            migrationBuilder.DropTable(
                name: "AttestionTravails");

            migrationBuilder.DropTable(
                name: "dossiers");
        }
    }
}
