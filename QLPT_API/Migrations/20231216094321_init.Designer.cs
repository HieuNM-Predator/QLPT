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
    [Migration("20231216094321_init")]
    partial class init
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

                    b.HasKey("Id");

                    b.HasIndex("ChuaId");

                    b.HasIndex("QuyenHanId");

                    b.ToTable("PhatTu");
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

            modelBuilder.Entity("QLPT_API.Entities.ConfirmEmail", b =>
                {
                    b.HasOne("QLPT_API.Entities.PhatTu", "PhatTu")
                        .WithMany()
                        .HasForeignKey("PhatTuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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

            modelBuilder.Entity("QLPT_API.Entities.QuyenHan", b =>
                {
                    b.Navigation("PhatTus");
                });
#pragma warning restore 612, 618
        }
    }
}
