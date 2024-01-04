namespace QLPT_API.Handles.DTOs
{
    public class DaoTrangDTO
    {
        public bool DaKetThuc { get; set; }
        public string NoiDung { get; set; }
        public string NoiToChuc { get; set; }
        public int SoThanhVien { get; set; }
        public DateTime ThoiGianBatDau { get; set; }
        //public PhatTuDTO NguoiTruTri { get; set; }
        public string TenTruTri { get; set; }
        public IEnumerable<PhatTuDaoTrangDTO> PhatTuDaoTrangDTOs { get; set; }
    }
}
