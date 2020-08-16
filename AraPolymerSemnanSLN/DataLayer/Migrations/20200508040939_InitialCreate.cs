using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pagescontents",
                columns: table => new
                {
                    Serial = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageName = table.Column<string>(nullable: false),
                    PageCaption = table.Column<string>(nullable: true),
                    Contents = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagescontents", x => x.Serial);
                });

            migrationBuilder.CreateTable(
                name: "Producttypes",
                columns: table => new
                {
                    Serial = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producttypes", x => x.Serial);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Serial = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    ProductTypeID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    Diameter = table.Column<string>(nullable: true),
                    weight = table.Column<string>(nullable: true),
                    Length = table.Column<string>(nullable: true),
                    Thickness = table.Column<string>(nullable: true),
                    StandardCode = table.Column<string>(nullable: true),
                    hotproduct = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Serial);
                    table.ForeignKey(
                        name: "FK_Products_Producttypes_ProductTypeID",
                        column: x => x.ProductTypeID,
                        principalTable: "Producttypes",
                        principalColumn: "Serial",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pagescontents",
                columns: new[] { "Serial", "Contents", "PageCaption", "PageName" },
                values: new object[,]
                {
                    { 1, null, "تماس با ما", "ContactUs" },
                    { 2, null, "درباره ما", "AboutUs" }
                });

            migrationBuilder.InsertData(
                table: "Producttypes",
                columns: new[] { "Serial", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "1", "نوع محصول یک" },
                    { 2, "2", "نوع محصول دو" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeID",
                table: "Products",
                column: "ProductTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pagescontents");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Producttypes");
        }
    }
}
