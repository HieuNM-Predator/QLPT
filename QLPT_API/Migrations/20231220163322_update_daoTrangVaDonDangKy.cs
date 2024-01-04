using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLPT_API.Migrations
{
    /// <inheritdoc />
    public partial class update_daoTrangVaDonDangKy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NguoiXuLy",
                table: "DonDangKy",
                newName: "NguoiXuLyId");

            migrationBuilder.RenameColumn(
                name: "NguoiTruTri",
                table: "DaoTrang",
                newName: "NguoiTruTriId");

            migrationBuilder.CreateIndex(
                name: "IX_DonDangKy_NguoiXuLyId",
                table: "DonDangKy",
                column: "NguoiXuLyId");

            migrationBuilder.CreateIndex(
                name: "IX_DaoTrang_NguoiTruTriId",
                table: "DaoTrang",
                column: "NguoiTruTriId");

            migrationBuilder.AddForeignKey(
                name: "FK_DaoTrang_PhatTu_NguoiTruTriId",
                table: "DaoTrang",
                column: "NguoiTruTriId",
                principalTable: "PhatTu",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DonDangKy_PhatTu_NguoiXuLyId",
                table: "DonDangKy",
                column: "NguoiXuLyId",
                principalTable: "PhatTu",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DaoTrang_PhatTu_NguoiTruTriId",
                table: "DaoTrang");

            migrationBuilder.DropForeignKey(
                name: "FK_DonDangKy_PhatTu_NguoiXuLyId",
                table: "DonDangKy");

            migrationBuilder.DropIndex(
                name: "IX_DonDangKy_NguoiXuLyId",
                table: "DonDangKy");

            migrationBuilder.DropIndex(
                name: "IX_DaoTrang_NguoiTruTriId",
                table: "DaoTrang");

            migrationBuilder.RenameColumn(
                name: "NguoiXuLyId",
                table: "DonDangKy",
                newName: "NguoiXuLy");

            migrationBuilder.RenameColumn(
                name: "NguoiTruTriId",
                table: "DaoTrang",
                newName: "NguoiTruTri");
        }
    }
}
