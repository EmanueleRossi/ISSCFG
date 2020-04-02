using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ISSCFG.Migrations
{
    public partial class MI00 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(nullable: true),
                    Producer = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInputs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Step01 = table.Column<string>(nullable: true),
                    Step02 = table.Column<string>(nullable: true),
                    Step03 = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInputs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Code", "Description", "ImagePath", "Producer", "Url" },
                values: new object[,]
                {
                    { -1, "QM55R", "Samsung Smart Signage Display", "~/img/Products/QM55R.jpeg", "SAMSUNG", "https://displaysolutions.samsung.com/digital-signage/detail/1431/QM55R" },
                    { -2, "WM65R", "Flip 2 - SMART Signage", "~/img/Products/FLIP2_65.jpeg", "SAMSUNG", "https://www.samsung.com/it/samsung-flip/" },
                    { -3, "STUDIO", "Premium USB Video Bar", "~/img/Products/STUDIO.jpeg", "POLY", "https://www.polycom.com/hd-video-conferencing/room-video-systems/polycom-studio.html" },
                    { -4, "STUDIO-X30", "Poly Studio X30", "~/img/Products/STUDIO-X30.jpeg", "POLY", "https://www.polycom.com/content/dam/polycom/common/documents/data-sheets/studio-x30-data-sheet-enus.pdf" },
                    { -5, "STUDIO-X50", "Poly Studio X50", "~/img/Products/STUDIO-X50.jpeg", "POLY", "https://www.polycom.com/content/dam/polycom/common/documents/data-sheets/studio-x50-data-sheet-enus.pdf" },
                    { -6, "CS_CX-20", "ClickShare CX-20", "~/img/Products/CX-20.png", "BARCO", "https://www.barco.com/en/clickshare/wireless-conferencing/cx-20" },
                    { -7, "VCEM", "VC Studio Expansion Microphone", "~/img/ACS.jpeg", "BARCO", "" },
                    { -8, "TC8", "Poly TC8 Tablet", "~/img/Products/TC8.jpeg", "POLY", "https://www.polycom.com/content/dam/polycom/common/documents/data-sheets/poly-tc8-data-sheet-enus.pdf" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "UserInputs");
        }
    }
}
