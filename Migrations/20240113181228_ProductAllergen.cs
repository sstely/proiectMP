using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proiectMP.Migrations
{
    /// <inheritdoc />
    public partial class ProductAllergen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allergen",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllergenName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergen", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProductAllergen",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    AllergenID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAllergen", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductAllergen_Allergen_AllergenID",
                        column: x => x.AllergenID,
                        principalTable: "Allergen",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductAllergen_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductAllergen_AllergenID",
                table: "ProductAllergen",
                column: "AllergenID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAllergen_ProductID",
                table: "ProductAllergen",
                column: "ProductID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductAllergen");

            migrationBuilder.DropTable(
                name: "Allergen");
        }
    }
}
