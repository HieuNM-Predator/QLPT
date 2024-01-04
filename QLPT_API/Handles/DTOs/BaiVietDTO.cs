using QLPT_API.Entities;

namespace QLPT_API.Handles.DTOs
{
    public class BaiVietDTO
    {
        public string TieuDe { get; set; }
        public string MoTa { get; set; }
        public string NoiDung { get; set; }
        public int SoLuotThich { get; set; }
        public int SoLuotBinhLuan { get; set; }
        public DateTime ThoiGianDang { get; set; }
        public DateTime? ThoiGianCapNhat { get; set; }
        //public DateTime? ThoiGianXoa { get; set; }
        //public bool DaXoa { get; set; }

        //public LoaiBaiVietDTO LoaiBaiViet { get; set; }
        public string TenLoaiBaiViet { get; set; }
        //public PhatTuDTO PhatTu { get; set; }
        public string NguoiViet { get; set; }
        public string NguoiDuyet { get; set; }
        public TrangThaiBaiVietDTO TrangThaiBaiViet { get; set; }
        public IEnumerable<NguoiDungThichBaiVietDTO> NguoiDungThichBaiViets { get; set; }
        public IEnumerable<BinhLuanBaiVietDTO> BinhLuanBaiViets { get; set; }
    }
}
