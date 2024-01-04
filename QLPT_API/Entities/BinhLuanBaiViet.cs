namespace QLPT_API.Entities
{
    public class BinhLuanBaiViet
    {
        public int Id { get; set; }
        public string BinhLuan { get; set; }
        public int SoLuotThich { get; set; }
        public DateTime ThoiGianTao { get; set; }
        public DateTime? ThoiGianCapNhat { get; set; }
        public DateTime? ThoiGianXoa { get; set; }
        public bool DaXoa { get; set; }

        public int BaiVietId { get; set; }
        public BaiViet BaiViet { get; set; }
        public int PhatTuId { get; set; }
        public PhatTu PhatTu { get; set; }

        public IEnumerable<NguoiDungThichBinhLuanBaiViet> NguoiDungThichBinhLuanBaiViets { get; set; }
    }
}
