using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLPT_API.Migrations
{
    /// <inheritdoc />
    public partial class them_isActive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "PhatTu",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "PhatTu");
        }
    }
}
