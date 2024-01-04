using Microsoft.EntityFrameworkCore;

namespace QLPT_API.Entities
{
    public class AppDbContext : DbContext
    {
        public DbSet<Chua> Chua { get; set; }
        public DbSet<QuyenHan> QuyenHan { get; set; }
        public DbSet<RefreshToken> RefreshToken { get; set; }
        public DbSet<ConfirmEmail> ConfirmEmail { get; set; }
        public DbSet<PhatTu> PhatTu { get; set; }
        public DbSet<DonDangKy> DonDangKy { get; set; }
        public DbSet<DaoTrang> DaoTrang { get; set; }
        public DbSet<PhatTuDaoTrang> PhatTuDaoTrang { get; set; }
        public DbSet<TrangThaiDon> TrangThaiDon { get; set; }

        public DbSet<BaiViet> BaiViet { get; set; }
        public DbSet<BinhLuanBaiViet> BinhLuanBaiViet { get; set; }
        public DbSet<NguoiDungThichBaiViet> NguoiDungThichBaiViet { get; set; }
        public DbSet<NguoiDungThichBinhLuanBaiViet> NguoiDungThichBinhLuanBaiViet { get; set; }
        public DbSet<LoaiBaiViet> LoaiBaiViet { get; set; }
        public DbSet<TrangThaiBaiViet> TrangThaiBaiViet { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = LAPTOP-KGK61HSN; Database = QLPhatTu; Trusted_Connection = True; TrustServerCertificate = True;");
        }
    }
}
