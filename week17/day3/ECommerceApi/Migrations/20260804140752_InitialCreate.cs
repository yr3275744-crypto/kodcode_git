using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerceApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_products_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ReviewerName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reviews_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Books" },
                    { 3, "Clothing" }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "CategoryId", "Name", "Price", "StockQuantity" },
                values: new object[,]
                {
                    { 1, 1, "Product 1", 15m, 99 },
                    { 2, 2, "Product 2", 20m, 98 },
                    { 3, 3, "Product 3", 25m, 97 },
                    { 4, 1, "Product 4", 30m, 96 },
                    { 5, 2, "Product 5", 35m, 95 },
                    { 6, 3, "Product 6", 40m, 94 },
                    { 7, 1, "Product 7", 45m, 93 },
                    { 8, 2, "Product 8", 50m, 92 },
                    { 9, 3, "Product 9", 55m, 91 },
                    { 10, 1, "Product 10", 60m, 90 },
                    { 11, 2, "Product 11", 65m, 89 },
                    { 12, 3, "Product 12", 70m, 88 },
                    { 13, 1, "Product 13", 75m, 87 },
                    { 14, 2, "Product 14", 80m, 86 },
                    { 15, 3, "Product 15", 85m, 85 },
                    { 16, 1, "Product 16", 90m, 84 },
                    { 17, 2, "Product 17", 95m, 83 },
                    { 18, 3, "Product 18", 100m, 82 },
                    { 19, 1, "Product 19", 105m, 81 },
                    { 20, 2, "Product 20", 110m, 80 },
                    { 21, 3, "Product 21", 115m, 79 },
                    { 22, 1, "Product 22", 120m, 78 },
                    { 23, 2, "Product 23", 125m, 77 },
                    { 24, 3, "Product 24", 130m, 76 },
                    { 25, 1, "Product 25", 135m, 75 },
                    { 26, 2, "Product 26", 140m, 74 },
                    { 27, 3, "Product 27", 145m, 73 },
                    { 28, 1, "Product 28", 150m, 72 },
                    { 29, 2, "Product 29", 155m, 71 },
                    { 30, 3, "Product 30", 160m, 70 }
                });

            migrationBuilder.InsertData(
                table: "reviews",
                columns: new[] { "Id", "ProductId", "Rating", "ReviewerName" },
                values: new object[,]
                {
                    { 1, 1, 2, "User1" },
                    { 2, 2, 3, "User2" },
                    { 3, 3, 4, "User3" },
                    { 4, 4, 5, "User4" },
                    { 5, 5, 1, "User5" },
                    { 6, 6, 2, "User6" },
                    { 7, 7, 3, "User7" },
                    { 8, 8, 4, "User8" },
                    { 9, 9, 5, "User9" },
                    { 10, 10, 1, "User10" },
                    { 11, 11, 2, "User11" },
                    { 12, 12, 3, "User12" },
                    { 13, 13, 4, "User13" },
                    { 14, 14, 5, "User14" },
                    { 15, 15, 1, "User15" },
                    { 16, 16, 2, "User16" },
                    { 17, 17, 3, "User17" },
                    { 18, 18, 4, "User18" },
                    { 19, 19, 5, "User19" },
                    { 20, 20, 1, "User20" },
                    { 21, 21, 2, "User21" },
                    { 22, 22, 3, "User22" },
                    { 23, 23, 4, "User23" },
                    { 24, 24, 5, "User24" },
                    { 25, 25, 1, "User25" },
                    { 26, 26, 2, "User26" },
                    { 27, 27, 3, "User27" },
                    { 28, 28, 4, "User28" },
                    { 29, 29, 5, "User29" },
                    { 30, 30, 1, "User30" },
                    { 31, 1, 2, "User31" },
                    { 32, 2, 3, "User32" },
                    { 33, 3, 4, "User33" },
                    { 34, 4, 5, "User34" },
                    { 35, 5, 1, "User35" },
                    { 36, 6, 2, "User36" },
                    { 37, 7, 3, "User37" },
                    { 38, 8, 4, "User38" },
                    { 39, 9, 5, "User39" },
                    { 40, 10, 1, "User40" },
                    { 41, 11, 2, "User41" },
                    { 42, 12, 3, "User42" },
                    { 43, 13, 4, "User43" },
                    { 44, 14, 5, "User44" },
                    { 45, 15, 1, "User45" },
                    { 46, 16, 2, "User46" },
                    { 47, 17, 3, "User47" },
                    { 48, 18, 4, "User48" },
                    { 49, 19, 5, "User49" },
                    { 50, 20, 1, "User50" },
                    { 51, 21, 2, "User51" },
                    { 52, 22, 3, "User52" },
                    { 53, 23, 4, "User53" },
                    { 54, 24, 5, "User54" },
                    { 55, 25, 1, "User55" },
                    { 56, 26, 2, "User56" },
                    { 57, 27, 3, "User57" },
                    { 58, 28, 4, "User58" },
                    { 59, 29, 5, "User59" },
                    { 60, 30, 1, "User60" },
                    { 61, 1, 2, "User61" },
                    { 62, 2, 3, "User62" },
                    { 63, 3, 4, "User63" },
                    { 64, 4, 5, "User64" },
                    { 65, 5, 1, "User65" },
                    { 66, 6, 2, "User66" },
                    { 67, 7, 3, "User67" },
                    { 68, 8, 4, "User68" },
                    { 69, 9, 5, "User69" },
                    { 70, 10, 1, "User70" },
                    { 71, 11, 2, "User71" },
                    { 72, 12, 3, "User72" },
                    { 73, 13, 4, "User73" },
                    { 74, 14, 5, "User74" },
                    { 75, 15, 1, "User75" },
                    { 76, 16, 2, "User76" },
                    { 77, 17, 3, "User77" },
                    { 78, 18, 4, "User78" },
                    { 79, 19, 5, "User79" },
                    { 80, 20, 1, "User80" },
                    { 81, 21, 2, "User81" },
                    { 82, 22, 3, "User82" },
                    { 83, 23, 4, "User83" },
                    { 84, 24, 5, "User84" },
                    { 85, 25, 1, "User85" },
                    { 86, 26, 2, "User86" },
                    { 87, 27, 3, "User87" },
                    { 88, 28, 4, "User88" },
                    { 89, 29, 5, "User89" },
                    { 90, 30, 1, "User90" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_CategoryId",
                table: "products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_ProductId",
                table: "reviews",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reviews");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
