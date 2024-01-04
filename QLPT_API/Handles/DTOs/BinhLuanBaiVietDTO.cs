using QLPT_API.Entities;

namespace QLPT_API.Handles.DTOs
{
    public class BinhLuanBaiVietDTO
    {
        public string BinhLuan { get; set; }
        public int SoLuotThich { get; set; }
        public DateTime ThoiGianTao { get; set; }
        public DateTime? ThoiGianCapNhat { get; set; }
        //public DateTime ThoiGianXoa { get; set; }
        //public bool DaXoa { get; set; }

        public int BaiVietId { get; set; }
        //public BaiViet BaiViet { get; set; }
        //public int PhatTuId { get; set; }
        //public PhatTu PhatTu { get; set; }
        public string TenPhatTu { get; set; }

        public IEnumerable<NguoiDungThichBinhLuanBaiVietDTO> NguoiDungThichBinhLuanBaiViets { get; set; }
    }
}
