﻿using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ISSCFG.Migrations
{
    public partial class InitialCreate : Migration
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

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Code", "Description", "ImagePath", "Producer", "Url" },
                values: new object[,]
                {
                    { -1, "QM55R", "Samsung Smart Signage Display", "img/Items/QM55R.jpg", "SAMSUNG", "https://displaysolutions.samsung.com/digital-signage/detail/1431/QM55R" },
                    { -2, "WM65R", "Flip 2 - SMART Signage", "img/Items/FLIP2_65.jpg", "SAMSUNG", "https://www.samsung.com/it/samsung-flip/" },
                    { -3, "STUDIO", "Premium USB Video Bar", "img/Items/STUDIO.jpg", "POLY", "https://www.polycom.com/hd-video-conferencing/room-video-systems/polycom-studio.html" },
                    { -4, "STUDIO-X30", "Poly Studio X30", "img/Items/STUDIO-X30.jpg", "POLY", "https://www.polycom.com/content/dam/polycom/common/documents/data-sheets/studio-x30-data-sheet-enus.pdf" },
                    { -5, "STUDIO-X50", "Poly Studio X50", "img/Items/STUDIO-X50.jpg", "POLY", "https://www.polycom.com/content/dam/polycom/common/documents/data-sheets/studio-x50-data-sheet-enus.pdf" },
                    { -6, "CS_CX-20", "ClickShare CX-20", "img/Items/CX-20.png", "BARCO", "https://www.barco.com/en/clickshare/wireless-conferencing/cx-20" },
                    { -7, "VCEM", "VC Studio Expansion Microphone", "", "BARCO", "" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
