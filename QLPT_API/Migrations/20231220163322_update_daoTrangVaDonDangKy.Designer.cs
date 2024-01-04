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
    [Migration("20231220163322_update_daoTrangVaDonDangKy")]
    partial class update_daoTrangVaDonDangKy
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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
                        .IsRequired()
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
