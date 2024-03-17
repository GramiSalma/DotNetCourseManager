using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Creatiodestables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "db");

            migrationBuilder.CreateTable(
                name: "Categorie",
                schema: "db",
                columns: table => new
                {
                    Idcategorie = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titrecategorie = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.Idcategorie);
                });

            migrationBuilder.CreateTable(
                name: "Cours",
                schema: "db",
                columns: table => new
                {
                    Idcours = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "varchar(200)", nullable: false),
                    Etapes = table.Column<string>(type: "varchar(250)", nullable: true),
                    Date = table.Column<string>(type: "varchar(250)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Idcategorie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cours", x => x.Idcours);
                    table.ForeignKey(
                        name: "FK_Cours_Categorie_Idcategorie",
                        column: x => x.Idcategorie,
                        principalSchema: "db",
                        principalTable: "Categorie",
                        principalColumn: "Idcategorie",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Commentaire",
                schema: "db",
                columns: table => new
                {
                    Idcommentaire = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(500)", nullable: false),
                    Nomuser = table.Column<string>(type: "varchar(500)", nullable: false),
                    Date = table.Column<string>(type: "varchar(250)", nullable: false),
                    Idcours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commentaire", x => x.Idcommentaire);
                    table.ForeignKey(
                        name: "FK_Commentaire_Cours_Idcours",
                        column: x => x.Idcours,
                        principalSchema: "db",
                        principalTable: "Cours",
                        principalColumn: "Idcours",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commentaire_Idcours",
                schema: "db",
                table: "Commentaire",
                column: "Idcours");

            migrationBuilder.CreateIndex(
                name: "IX_Cours_Idcategorie",
                schema: "db",
                table: "Cours",
                column: "Idcategorie");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commentaire",
                schema: "db");

            migrationBuilder.DropTable(
                name: "Cours",
                schema: "db");

            migrationBuilder.DropTable(
                name: "Categorie",
                schema: "db");
        }
    }
}
