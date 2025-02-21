using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace e_commerce.Migrations
{
    /// <inheritdoc />
    public partial class addmigrationproduct_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(125)", maxLength: 125, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    quatity = table.Column<int>(type: "int", nullable: false),
                    imgsource = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_products_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Clothing & Apparel" },
                    { 3, "Home & Living" },
                    { 4, "Beauty & Personal Care" },
                    { 5, "Books & Stationery" },
                    { 6, "Toys & Games" },
                    { 7, "Sports & Outdoors" },
                    { 8, "Automotive Parts & Accessories" },
                    { 9, "Groceries & Gourmet Foods" },
                    { 10, "Health & Wellness" },
                    { 11, "Jewelry & Watches" },
                    { 12, "Pet Supplies" },
                    { 13, "Office Supplies" },
                    { 14, "Baby & Kids" },
                    { 15, "Furniture" },
                    { 16, "Art & Crafts" },
                    { 17, "Musical Instruments" },
                    { 18, "Travel & Luggage" },
                    { 19, "Garden & Outdoor" },
                    { 20, "Fitness & Exercise" },
                    { 21, "Watches & Accessories" },
                    { 22, "Party Supplies" },
                    { 23, "Industrial & Scientific" },
                    { 24, "Shoes & Footwear" },
                    { 25, "Seasonal & Holiday Decor" }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "Description", "Name", "Price", "category_id", "imgsource", "quatity" },
                values: new object[,]
                {
                    { 1, "Wireless Bluetooth 5.0 headphones with 30-hour battery, noise cancellation, and ergonomic design.", "Wireless Bluetooth Headphones", 100, 1, "/images/wireless-bluetooth.jpg", 1002 },
                    { 2, "4K Ultra HD Smart TV with HDR10+, Android OS, Netflix/Prime Video, HDMI 2.1.", "4K Smart TV", 8000, 1, "/images/4k-smart-tv.jpg", 200 },
                    { 3, "Premium cotton crew-neck T-shirt for men. Available in multiple colors.", "Men's Cotton T-Shirt", 20, 2, "/images/mens-tshirt.jpg", 500 },
                    { 4, "Modern ceramic lamp with fabric shade. Perfect for living rooms.", "Ceramic Table Lamp", 45, 3, "/images/table-lamp.jpg", 150 },
                    { 5, "Vitamin C serum for glowing skin. Suitable for all skin types.", "Hydrating Facial Serum", 35, 4, "/images/facial-serum.jpg", 300 },
                    { 6, "Handcrafted leather-bound notebook with lined pages.", "Leather Journal Notebook", 19, 5, "/images/leather-journal.jpg", 200 },
                    { 7, "500-piece plastic building blocks for creative play.", "Building Blocks Set", 30, 6, "/images/building-blocks.jpg", 400 },
                    { 8, "Weather-resistant tent with easy setup. Includes carry bag.", "Camping Tent (4-Person)", 150, 7, "/images/camping-tent.jpg", 100 },
                    { 9, "Adjustable dashboard phone holder with strong suction.", "Car Phone Mount", 16, 8, "/images/car-mount.jpg", 600 },
                    { 10, "Arabica coffee beans, medium roast. Sustainably sourced.", "Organic Coffee Beans (1kg)", 20, 9, "/images/coffee-beans.jpg", 250 },
                    { 11, "Eco-friendly non-slip mat. Includes carrying strap.", "Yoga Mat", 25, 10, "/images/yoga-mat.jpg", 350 },
                    { 12, "925 sterling silver pendant necklace with chain.", "Silver Pendant Necklace", 90, 11, "/images/silver-necklace.jpg", 120 },
                    { 13, "Durable rubber chew toy for medium/large dogs.", "Dog Chew Toy", 10, 12, "/images/dog-toy.jpg", 800 },
                    { 14, "12-pack of smooth-writing black ink pens.", "Ballpoint Pen Set", 10, 13, "/images/pen-set.jpg", 1000 },
                    { 15, "Lightweight stroller with reclining seat and sunshade.", "Baby Stroller", 120, 14, "/images/baby-stroller.jpg", 80 },
                    { 16, "Solid oak table. Seats 6. Modern farmhouse design.", "Wooden Dining Table", 300, 15, "/images/dining-table.jpg", 50 },
                    { 17, "24-color set with brushes. Non-toxic and washable.", "Acrylic Paint Set", 25, 16, "/images/paint-set.jpg", 200 },
                    { 18, "Full-size guitar with spruce top. Includes gig bag.", "Acoustic Guitar", 200, 17, "/images/acoustic-guitar.jpg", 30 },
                    { 19, "Hard-shell spinner luggage. FAA-approved size.", "Carry-On Suitcase", 80, 18, "/images/suitcase.jpg", 150 },
                    { 20, "9-foot UV-resistant umbrella with tilt function.", "Patio Umbrella", 60, 19, "/images/patio-umbrella.jpg", 90 },
                    { 21, "5–25 kg adjustable set with ergonomic grips.", "Adjustable Dumbbells", 100, 20, "/images/dumbbells.jpg", 70 },
                    { 22, "Water-resistant chronograph watch with date display.", "Stainless Steel Watch", 200, 21, "/images/stainless-watch.jpg", 40 },
                    { 23, "50-piece kit with pump, strings, and assorted balloons.", "Balloon Decoration Kit", 15, 22, "/images/balloon-kit.jpg", 300 },
                    { 24, "Precision measuring tool with LCD screen. 0–150mm range.", "Digital Caliper", 35, 23, "/images/digital-caliper.jpg", 120 },
                    { 25, "Lightweight breathable shoes with cushioned sole.", "Running Sneakers", 80, 24, "/images/running-shoes.jpg", 250 },
                    { 26, "10-meter string lights with 8 lighting modes.", "LED Christmas Lights", 25, 25, "/images/christmas-lights.jpg", 500 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_products_category_id",
                table: "products",
                column: "category_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
