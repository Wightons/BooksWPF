using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BooksWPF.Migrations
{
    public partial class PropChanges1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Vendors",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desc",
                table: "Vendors");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Vendors",
                newName: "FullName");
        }
    }
}
