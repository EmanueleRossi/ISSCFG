using Microsoft.EntityFrameworkCore.Migrations;

namespace ISSCFG.Migrations
{
    public partial class MI01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AcceptedLanguages",
                table: "UserInputs",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: -11,
                column: "ImagePath",
                value: "~/img/Products/MS-TRL.jpeg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcceptedLanguages",
                table: "UserInputs");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: -11,
                column: "ImagePath",
                value: "~/img/MS-TRL.jpeg");
        }
    }
}
