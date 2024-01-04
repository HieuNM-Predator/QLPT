using QLPT_API.Entities;

namespace QLPT_API.Handles.DTOs
{
    public class DonDangKyDTO
    {
        public DateTime NgayGuiDon { get; set; }
        public DateTime NgayXuLy { get; set; }
        public string TenNguoiXuly { get; set; }
        //public PhatTuDTO NguoiXuLy { get; set; }
        public TrangThaiDonDTO TrangThaiDon { get; set; }
        //public DaoTrangDTO DaoTrang { get; set; }
        public int DaoTrangId { get; set; }
        //public PhatTuDTO PhatTu { get; set; }
        public string TenPhatTu { get; set; }
    }
}
