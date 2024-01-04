namespace QLPT_API.Entities
{
    public class NguoiDungThichBinhLuanBaiViet
    {
        public int Id { get; set; }
        public DateTime ThoiGianLike { get; set; }
        public bool DaXoa { get; set; }
        public int PhatTuId { get; set; }
        public PhatTu PhatTu { get; set; }
        public int BinhLuanBaiVietId { get; set; }
        public BinhLuanBaiViet BinhLuanBaiViet { get; set; }
    }
}
