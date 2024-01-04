namespace QLPT_API.Entities
{
    public class DaoTrang
    {
        public int Id { get; set; }
        public bool DaKetThuc { get; set; }
        public string NoiDung { get; set; }
        public string NoiToChuc { get; set; }
        public int SoThanhVien { get; set; }
        public DateTime ThoiGianBatDau { get; set; }
        public int NguoiTruTriId { get; set; }
        public PhatTu NguoiTruTri { get; set; }
        public IEnumerable<PhatTuDaoTrang> PhatTuDaoTrangs { get; set; }
    }
}
