﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QLPT_API.Entities;

#nullable disable

namespace QLPT_API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231228165320_update_ThoiGian_BinhLuan")]
    partial class update_ThoiGian_BinhLuan
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("QLPT_API.Entities.BaiViet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("DaXoa")
                        .HasColumnType("bit");

                    b.Property<int>("LoaiBaiVietId")
                        .HasColumnType("int");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NguoiDuyetId")
                        .HasColumnType("int");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhatTuId")
                        .HasColumnType("int");

                    b.Property<int>("SoLuotBinhLuan")
                        .HasColumnType("int");

                    b.Property<int>("SoLuotThich")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ThoiGianCapNhat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ThoiGianDang")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ThoiGianXoa")
                        .HasColumnType("datetime2");

                    b.Property<string>("TieuDe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrangThaiBaiVietId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LoaiBaiVietId");

                    b.HasIndex("PhatTuId");

                    b.HasIndex("TrangThaiBaiVietId");

                    b.ToTable("BaiViet");
                });

            modelBuilder.Entity("QLPT_API.Entities.BinhLuanBaiViet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BaiVietId")
                        .HasColumnType("int");

                    b.Property<string>("BinhLuan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("DaXoa")
                        .HasColumnType("bit");

                    b.Property<int>("PhatTuId")
                        .HasColumnType("int");

                    b.Property<int>("SoLuotThich")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ThoiGianCapNhat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ThoiGianTao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ThoiGianXoa")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BaiVietId");

                    b.HasIndex("PhatTuId");

                    b.ToTable("BinhLuanBaiViet");
                });

            modelBuilder.Entity("QLPT_API.Entities.Chua", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayThanhLap")
                        .HasColumnType("datetime2");

                    b.Property<string>("NguoiTruTri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenChua")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Chua");
                });

            modelBuilder.Entity("QLPT_API.Entities.ConfirmEmail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("DaXacNhan")
                        .HasColumnType("bit");

                    b.Property<string>("MaXacNhan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhatTuId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ThoiGianHetHan")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PhatTuId");

                    b.ToTable("ConfirmEmail");
                });

            modelBuilder.Entity("QLPT_API.Entities.DaoTrang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("DaKetThuc")
                        .HasColumnType("bit");

                    b.Property<int>("NguoiTruTriId")
                        .HasColumnType("int");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoiToChuc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoThanhVien")
                        .HasColumnType("int");

                    b.Property<DateTime>("ThoiGianBatDau")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("NguoiTruTriId");

                    b.ToTable("DaoTrang");
                });

            modelBuilder.Entity("QLPT_API.Entities.DonDangKy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DaoTrangId")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayGuiDon")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayXuLy")
                        .HasColumnType("datetime2");

                    b.Property<int>("NguoiXuLyId")
                        .HasColumnType("int");

                    b.Property<int>("PhatTuId")
                        .HasColumnType("int");

                    b.Property<int>("TrangThaiDonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DaoTrangId");

                    b.HasIndex("NguoiXuLyId");

                    b.HasIndex("PhatTuId");

                    b.HasIndex("TrangThaiDonId");

                    b.ToTable("DonDangKy");
                });

            modelBuilder.Entity("QLPT_API.Entities.LoaiBaiViet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TenLoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LoaiBaiViet");
                });

            modelBuilder.Entity("QLPT_API.Entities.NguoiDungThichBaiViet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BaiVietId")
                        .HasColumnType("int");

                    b.Property<bool>("DaXoa")
                        .HasColumnType("bit");

                    b.Property<int>("PhatTuId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ThoiGianThich")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BaiVietId");

                    b.HasIndex("PhatTuId");

                    b.ToTable("NguoiDungThichBaiViet");
                });

            modelBuilder.Entity("QLPT_API.Entities.NguoiDungThichBinhLuanBaiViet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BinhLuanBaiVietId")
                        .HasColumnType("int");

                    b.Property<bool>("DaXoa")
                        .HasColumnType("bit");

                    b.Property<int>("PhatTuId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ThoiGianLike")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BinhLuanBaiVietId");

                    b.HasIndex("PhatTuId");

                    b.ToTable("NguoiDungThichBinhLuanBaiViet");
                });

            modelBuilder.Entity("QLPT_API.Entities.PhatTu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AnhChup")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ChuaId")
                        .HasColumnType("int");

                    b.Property<bool>("DaHoanTuc")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GioiTinh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayCapNhat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayHoanTuc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhapDanh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuyenHanId")
                        .HasColumnType("int");

                    b.Property<string>("SoDienThoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenTaiKhoan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ChuaId");

                    b.HasIndex("QuyenHanId");

                    b.ToTable("PhatTu");
                });

            modelBuilder.Entity("QLPT_API.Entities.PhatTuDaoTrang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("DaThamGia")
                        .HasColumnType("bit");

                    b.Property<int>("DaoTrangId")
                        .HasColumnType("int");

                    b.Property<string>("LyDoKhongThamGia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhatTuId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DaoTrangId");

                    b.HasIndex("PhatTuId");

                    b.ToTable("PhatTuDaoTrang");
                });

            modelBuilder.Entity("QLPT_API.Entities.QuyenHan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TenQuyenHan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("QuyenHan");
                });

            modelBuilder.Entity("QLPT_API.Entities.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PhatTuId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ThoiGianHetHan")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PhatTuId");

                    b.ToTable("RefreshToken");
                });

            modelBuilder.Entity("QLPT_API.Entities.TrangThaiBaiViet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TenTrangThai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TrangThaiBaiViet");
                });

            modelBuilder.Entity("QLPT_API.Entities.TrangThaiDon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TenTrangThai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TrangThaiDon");
                });

            modelBuilder.Entity("QLPT_API.Entities.BaiViet", b =>
                {
                    b.HasOne("QLPT_API.Entities.LoaiBaiViet", "LoaiBaiViet")
                        .WithMany()
                        .HasForeignKey("LoaiBaiVietId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLPT_API.Entities.PhatTu", "PhatTu")
                        .WithMany("BaiViets")
                        .HasForeignKey("PhatTuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLPT_API.Entities.TrangThaiBaiViet", "TrangThaiBaiViet")
                        .WithMany()
                        .HasForeignKey("TrangThaiBaiVietId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoaiBaiViet");

                    b.Navigation("PhatTu");

                    b.Navigation("TrangThaiBaiViet");
                });

            modelBuilder.Entity("QLPT_API.Entities.BinhLuanBaiViet", b =>
                {
                    b.HasOne("QLPT_API.Entities.BaiViet", "BaiViet")
                        .WithMany("BinhLuanBaiViets")
                        .HasForeignKey("BaiVietId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLPT_API.Entities.PhatTu", "PhatTu")
                        .WithMany()
                        .HasForeignKey("PhatTuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BaiViet");

                    b.Navigation("PhatTu");
                });

            modelBuilder.Entity("QLPT_API.Entities.ConfirmEmail", b =>
                {
                    b.HasOne("QLPT_API.Entities.PhatTu", "PhatTu")
                        .WithMany()
                        .HasForeignKey("PhatTuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PhatTu");
                });

            modelBuilder.Entity("QLPT_API.Entities.DaoTrang", b =>
                {
                    b.HasOne("QLPT_API.Entities.PhatTu", "NguoiTruTri")
                        .WithMany()
                        .HasForeignKey("NguoiTruTriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NguoiTruTri");
                });

            modelBuilder.Entity("QLPT_API.Entities.DonDangKy", b =>
                {
                    b.HasOne("QLPT_API.Entities.DaoTrang", "DaoTrang")
                        .WithMany()
                        .HasForeignKey("DaoTrangId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLPT_API.Entities.PhatTu", "NguoiXuLy")
                        .WithMany()
                        .HasForeignKey("NguoiXuLyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLPT_API.Entities.PhatTu", "PhatTu")
                        .WithMany()
                        .HasForeignKey("PhatTuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLPT_API.Entities.TrangThaiDon", "TrangThaiDon")
                        .WithMany()
                        .HasForeignKey("TrangThaiDonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DaoTrang");

                    b.Navigation("NguoiXuLy");

                    b.Navigation("PhatTu");

                    b.Navigation("TrangThaiDon");
                });

            modelBuilder.Entity("QLPT_API.Entities.NguoiDungThichBaiViet", b =>
                {
                    b.HasOne("QLPT_API.Entities.BaiViet", "BaiViet")
                        .WithMany("NguoiDungThichBaiViets")
                        .HasForeignKey("BaiVietId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLPT_API.Entities.PhatTu", "PhatTu")
                        .WithMany("NguoiDungThichBaiViets")
                        .HasForeignKey("PhatTuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BaiViet");

                    b.Navigation("PhatTu");
                });

            modelBuilder.Entity("QLPT_API.Entities.NguoiDungThichBinhLuanBaiViet", b =>
                {
                    b.HasOne("QLPT_API.Entities.BinhLuanBaiViet", "BinhLuanBaiViet")
                        .WithMany("NguoiDungThichBinhLuanBaiViets")
                        .HasForeignKey("BinhLuanBaiVietId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLPT_API.Entities.PhatTu", "PhatTu")
                        .WithMany("NguoiDungThichBinhLuanBaiViets")
                        .HasForeignKey("PhatTuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BinhLuanBaiViet");

                    b.Navigation("PhatTu");
                });

            modelBuilder.Entity("QLPT_API.Entities.PhatTu", b =>
                {
                    b.HasOne("QLPT_API.Entities.Chua", "Chua")
                        .WithMany("PhatTus")
                        .HasForeignKey("ChuaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLPT_API.Entities.QuyenHan", "QuyenHan")
                        .WithMany("PhatTus")
                        .HasForeignKey("QuyenHanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chua");

                    b.Navigation("QuyenHan");
                });

            modelBuilder.Entity("QLPT_API.Entities.PhatTuDaoTrang", b =>
                {
                    b.HasOne("QLPT_API.Entities.DaoTrang", "DaoTrang")
                        .WithMany("PhatTuDaoTrangs")
                        .HasForeignKey("DaoTrangId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLPT_API.Entities.PhatTu", "PhatTu")
                        .WithMany("PhatTuDaoTrangs")
                        .HasForeignKey("PhatTuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DaoTrang");

                    b.Navigation("PhatTu");
                });

            modelBuilder.Entity("QLPT_API.Entities.RefreshToken", b =>
                {
                    b.HasOne("QLPT_API.Entities.PhatTu", "PhatTu")
                        .WithMany()
                        .HasForeignKey("PhatTuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PhatTu");
                });

            modelBuilder.Entity("QLPT_API.Entities.BaiViet", b =>
                {
                    b.Navigation("BinhLuanBaiViets");

                    b.Navigation("NguoiDungThichBaiViets");
                });

            modelBuilder.Entity("QLPT_API.Entities.BinhLuanBaiViet", b =>
                {
                    b.Navigation("NguoiDungThichBinhLuanBaiViets");
                });

            modelBuilder.Entity("QLPT_API.Entities.Chua", b =>
                {
                    b.Navigation("PhatTus");
                });

            modelBuilder.Entity("QLPT_API.Entities.DaoTrang", b =>
                {
                    b.Navigation("PhatTuDaoTrangs");
                });

            modelBuilder.Entity("QLPT_API.Entities.PhatTu", b =>
                {
                    b.Navigation("BaiViets");

                    b.Navigation("NguoiDungThichBaiViets");

                    b.Navigation("NguoiDungThichBinhLuanBaiViets");

                    b.Navigation("PhatTuDaoTrangs");
                });

            modelBuilder.Entity("QLPT_API.Entities.QuyenHan", b =>
                {
                    b.Navigation("PhatTus");
                });
#pragma warning restore 612, 618
        }
    }
}