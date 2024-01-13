using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proiectMP.Migrations
{
    /// <inheritdoc />
    public partial class ProductIngredient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calories = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Unsaturated_Fats = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Saturated_Fats = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Sugars = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Fibers = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Proteins = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Minerals = table.Column<decimal>(type: "decimal(8,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProductIngredient",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    IngredientID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductIngredient", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductIngredient_Ingredient_IngredientID",
                        column: x => x.IngredientID,
                        principalTable: "Ingredient",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductIngredient_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductIngredient_IngredientID",
                table: "ProductIngredient",
                column: "IngredientID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductIngredient_ProductID",
                table: "ProductIngredient",
                column: "ProductID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductIngredient");

            migrationBuilder.DropTable(
                name: "Ingredient");
        }
    }
}
