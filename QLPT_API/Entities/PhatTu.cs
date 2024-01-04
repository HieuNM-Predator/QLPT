namespace QLPT_API.Entities
{
    public class PhatTu
    {
        public int Id { get; set; }
        public string TenTaiKhoan { get; set; }
        public string? AnhChup { get; set; }
        public bool DaHoanTuc { get; set; }
        public string Email { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgayCapNhat { get; set; } = DateTime.Now;
        public DateTime? NgayHoanTuc { get; set; }
        public DateTime NgaySinh { get; set; }
        public string MatKhau { get; set; }
        public string PhapDanh { get; set; }
        public string SoDienThoai { get; set; }
        public bool isActive { get; set; } = false;

        public int ChuaId { get; set; }
        public Chua Chua { get; set; }
        public int QuyenHanId { get; set; }
        public QuyenHan QuyenHan { get; set; }

        //public IEnumerable<DonDangKy> DonDangKys { get; set; }
        public IEnumerable<PhatTuDaoTrang> PhatTuDaoTrangs { get; set; }
        public IEnumerable<BaiViet> BaiViets { get; set; }
        public IEnumerable<NguoiDungThichBinhLuanBaiViet> NguoiDungThichBinhLuanBaiViets { get; set; }
        public IEnumerable<NguoiDungThichBaiViet> NguoiDungThichBaiViets { get; set; }

    }
}
