using QLPT_API.Entities;

namespace QLPT_API.Handles.DTOs
{
    public class PhatTuDTO
    {
        public string TenTaiKhoan { get; set; }
        public string? AnhChup { get; set; }
        public bool DaHoanTuc { get; set; }
        public string Email { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public DateTime? NgayHoanTuc { get; set; }
        public string PhapDanh { get; set; }
        public string SoDienThoai { get; set; }
        public ChuaDTO ChuaDTO { get; set; }
    }
}
