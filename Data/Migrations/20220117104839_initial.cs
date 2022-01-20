using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_1_KYH.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Consultants",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hired = table.Column<bool>(type: "bit", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phoneNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultants", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyID = table.Column<int>(type: "int", nullable: true),
                    budget = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    details = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.id);
                    table.ForeignKey(
                        name: "FK_Projects_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ConsultantProject",
                columns: table => new
                {
                    Consultantsid = table.Column<int>(type: "int", nullable: false),
                    Projectsid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultantProject", x => new { x.Consultantsid, x.Projectsid });
                    table.ForeignKey(
                        name: "FK_ConsultantProject_Consultants_Consultantsid",
                        column: x => x.Consultantsid,
                        principalTable: "Consultants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsultantProject_Projects_Projectsid",
                        column: x => x.Projectsid,
                        principalTable: "Projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    skillName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Consultantid = table.Column<int>(type: "int", nullable: true),
                    Projectid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.id);
                    table.ForeignKey(
                        name: "FK_Skills_Consultants_Consultantid",
                        column: x => x.Consultantid,
                        principalTable: "Consultants",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Skills_Projects_Projectid",
                        column: x => x.Projectid,
                        principalTable: "Projects",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsultantProject_Projectsid",
                table: "ConsultantProject",
                column: "Projectsid");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CompanyID",
                table: "Projects",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_Consultantid",
                table: "Skills",
                column: "Consultantid");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_Projectid",
                table: "Skills",
                column: "Projectid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsultantProject");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Consultants");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
