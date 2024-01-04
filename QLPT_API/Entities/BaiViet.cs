using System.ComponentModel.DataAnnotations.Schema;

namespace QLPT_API.Entities
{
    public class BaiViet
    {
        public int Id { get; set; }
        public string TieuDe { get; set; }
        public string MoTa { get; set; }
        public string NoiDung { get; set; }
        public int SoLuotThich { get; set; }
        public int SoLuotBinhLuan { get; set; }
        public DateTime ThoiGianDang { get; set; }
        public DateTime? ThoiGianCapNhat { get; set; }
        public DateTime? ThoiGianXoa { get; set; }
        public bool DaXoa { get; set; }

        public int LoaiBaiVietId { get; set; }
        public LoaiBaiViet LoaiBaiViet { get; set; }
        public int PhatTuId { get; set; }
        public PhatTu PhatTu { get; set; }
        public int TrangThaiBaiVietId { get; set; }
        public TrangThaiBaiViet TrangThaiBaiViet { get; set; }
        public IEnumerable<NguoiDungThichBaiViet> NguoiDungThichBaiViets { get; set; }
        public IEnumerable<BinhLuanBaiViet> BinhLuanBaiViets { get; set; }

        public int NguoiDuyetId { get; set; }
        //[ForeignKey("NguoiDuyetId")]
        //public PhatTu NguoiDuyet { get; set; }

    }
}
