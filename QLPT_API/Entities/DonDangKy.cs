namespace QLPT_API.Entities
{
    public class DonDangKy
    {
        public int Id { get; set; }
        public DateTime NgayGuiDon { get; set; }
        public DateTime NgayXuLy { get; set; }
        public int NguoiXuLyId{ get; set; }
        public PhatTu NguoiXuLy { get; set; }
        public int TrangThaiDonId { get; set; }
        public TrangThaiDon TrangThaiDon { get; set; }
        public int DaoTrangId { get; set; }
        public DaoTrang DaoTrang { get; set; }
        public int PhatTuId { get; set; }
        public PhatTu PhatTu { get; set; }
    }
}
