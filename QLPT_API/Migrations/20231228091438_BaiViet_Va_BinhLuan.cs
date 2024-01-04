using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLPT_API.Migrations
{
    /// <inheritdoc />
    public partial class BaiViet_Va_BinhLuan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoaiBaiViet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiBaiViet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrangThaiBaiViet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrangThaiBaiViet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaiViet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TieuDe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoLuotThich = table.Column<int>(type: "int", nullable: false),
                    SoLuotBinhLuan = table.Column<int>(type: "int", nullable: false),
                    ThoiGianDang = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ThoiGianXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: false),
                    LoaiBaiVietId = table.Column<int>(type: "int", nullable: false),
                    PhatTuId = table.Column<int>(type: "int", nullable: false),
                    TrangThaiBaiVietId = table.Column<int>(type: "int", nullable: false),
                    NguoiDuyetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaiViet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaiViet_LoaiBaiViet_LoaiBaiVietId",
                        column: x => x.LoaiBaiVietId,
                        principalTable: "LoaiBaiViet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaiViet_PhatTu_PhatTuId",
                        column: x => x.PhatTuId,
                        principalTable: "PhatTu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaiViet_TrangThaiBaiViet_TrangThaiBaiVietId",
                        column: x => x.TrangThaiBaiVietId,
                        principalTable: "TrangThaiBaiViet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BinhLuanBaiViet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BinhLuan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoLuotThich = table.Column<int>(type: "int", nullable: false),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianCapNhat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianXoa = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DaXoa = table.Column<bool>(type: "bit", nullable: false),
                    BaiVietId = table.Column<int>(type: "int", nullable: false),
                    PhatTuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BinhLuanBaiViet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BinhLuanBaiViet_BaiViet_BaiVietId",
                        column: x => x.BaiVietId,
                        principalTable: "BaiViet",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BinhLuanBaiViet_PhatTu_PhatTuId",
                        column: x => x.PhatTuId,
                        principalTable: "PhatTu",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NguoiDungThichBaiViet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThoiGianThich = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DaXoa = table.Column<bool>(type: "bit", nullable: false),
                    PhatTuId = table.Column<int>(type: "int", nullable: false),
                    BaiVietId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDungThichBaiViet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NguoiDungThichBaiViet_BaiViet_BaiVietId",
                        column: x => x.BaiVietId,
                        principalTable: "BaiViet",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NguoiDungThichBaiViet_PhatTu_PhatTuId",
                        column: x => x.PhatTuId,
                        principalTable: "PhatTu",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NguoiDungThichBinhLuanBaiViet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThoiGianLike = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DaXoa = table.Column<bool>(type: "bit", nullable: false),
                    PhatTuId = table.Column<int>(type: "int", nullable: false),
                    BinhLuanBaiVietId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDungThichBinhLuanBaiViet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NguoiDungThichBinhLuanBaiViet_BinhLuanBaiViet_BinhLuanBaiVietId",
                        column: x => x.BinhLuanBaiVietId,
                        principalTable: "BinhLuanBaiViet",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NguoiDungThichBinhLuanBaiViet_PhatTu_PhatTuId",
                        column: x => x.PhatTuId,
                        principalTable: "PhatTu",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaiViet_LoaiBaiVietId",
                table: "BaiViet",
                column: "LoaiBaiVietId");

            migrationBuilder.CreateIndex(
                name: "IX_BaiViet_PhatTuId",
                table: "BaiViet",
                column: "PhatTuId");

            migrationBuilder.CreateIndex(
                name: "IX_BaiViet_TrangThaiBaiVietId",
                table: "BaiViet",
                column: "TrangThaiBaiVietId");

            migrationBuilder.CreateIndex(
                name: "IX_BinhLuanBaiViet_BaiVietId",
                table: "BinhLuanBaiViet",
                column: "BaiVietId");

            migrationBuilder.CreateIndex(
                name: "IX_BinhLuanBaiViet_PhatTuId",
                table: "BinhLuanBaiViet",
                column: "PhatTuId");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDungThichBaiViet_BaiVietId",
                table: "NguoiDungThichBaiViet",
                column: "BaiVietId");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDungThichBaiViet_PhatTuId",
                table: "NguoiDungThichBaiViet",
                column: "PhatTuId");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDungThichBinhLuanBaiViet_BinhLuanBaiVietId",
                table: "NguoiDungThichBinhLuanBaiViet",
                column: "BinhLuanBaiVietId");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDungThichBinhLuanBaiViet_PhatTuId",
                table: "NguoiDungThichBinhLuanBaiViet",
                column: "PhatTuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NguoiDungThichBaiViet");

            migrationBuilder.DropTable(
                name: "NguoiDungThichBinhLuanBaiViet");

            migrationBuilder.DropTable(
                name: "BinhLuanBaiViet");

            migrationBuilder.DropTable(
                name: "BaiViet");

            migrationBuilder.DropTable(
                name: "LoaiBaiViet");

            migrationBuilder.DropTable(
                name: "TrangThaiBaiViet");
        }
    }
}
