using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IronMaidenRegistry.Migrations
{
    /// <inheritdoc />
    public partial class FullNameMaxLenght : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Members",
                type: "VARCHAR(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Members",
                type: "VARCHAR",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldMaxLength: 50);
        }
    }
}
