namespace QLPT_API.Handles.Request.DaoTrangRequest
{
    public class Request_SuaDaoTrang
    {
        public string NoiDung { get; set; }
        public string NoiToChuc { get; set; }
        public DateTime ThoiGianBatDau { get; set; }
        public bool DaKetThuc { get; set; }
        public int NguoiTruTriId { get; set; }
        //public int SoThanhVienThamGia { get; set; }
    }
}
