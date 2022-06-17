using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projet_yassine.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategorieProduits",
                columns: table => new
                {
                    CategorieProduitID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategorieProduitName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieProduits", x => x.CategorieProduitID);
                });

            migrationBuilder.CreateTable(
                name: "Fournisseurs",
                columns: table => new
                {
                    FournisseurID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FournisseurName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FournisseurAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FournisseurTel = table.Column<int>(type: "int", nullable: false),
                    Fournisseurmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fournisseurs", x => x.FournisseurID);
                });

            migrationBuilder.CreateTable(
                name: "Produits",
                columns: table => new
                {
                    ProduitID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProduitName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProduitDesignation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProduitColeur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProduitPrix = table.Column<double>(type: "float", nullable: false),
                    ProduitQteStock = table.Column<int>(type: "int", nullable: false),
                    ProduitPoids = table.Column<double>(type: "float", nullable: false),
                    ProduitTaille = table.Column<double>(type: "float", nullable: false),
                    CategorieProduitID = table.Column<int>(type: "int", nullable: false),
                    FournisseurID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produits", x => x.ProduitID);
                    table.ForeignKey(
                        name: "FK_Produits_CategorieProduits_CategorieProduitID",
                        column: x => x.CategorieProduitID,
                        principalTable: "CategorieProduits",
                        principalColumn: "CategorieProduitID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produits_Fournisseurs_FournisseurID",
                        column: x => x.FournisseurID,
                        principalTable: "Fournisseurs",
                        principalColumn: "FournisseurID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produits_CategorieProduitID",
                table: "Produits",
                column: "CategorieProduitID");

            migrationBuilder.CreateIndex(
                name: "IX_Produits_FournisseurID",
                table: "Produits",
                column: "FournisseurID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produits");

            migrationBuilder.DropTable(
                name: "CategorieProduits");

            migrationBuilder.DropTable(
                name: "Fournisseurs");
        }
    }
}
