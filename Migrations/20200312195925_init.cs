using Microsoft.EntityFrameworkCore.Migrations;

namespace OregonHikes3.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Hike",
                table: "Hike");

            migrationBuilder.RenameTable(
                name: "Hike",
                newName: "Hikes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hikes",
                table: "Hikes",
                column: "HikeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Hikes",
                table: "Hikes");

            migrationBuilder.RenameTable(
                name: "Hikes",
                newName: "Hike");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hike",
                table: "Hike",
                column: "HikeID");
        }
    }
}
