namespace QLPT_API.Entities
{
    public class PhatTuDaoTrang
    {
        public int Id { get; set; }
        public bool DaThamGia { get; set; }
        public string? LyDoKhongThamGia { get; set; }
        public int DaoTrangId { get; set; }
        public DaoTrang DaoTrang { get; set; }
        public int PhatTuId { get; set; }
        public PhatTu PhatTu { get; set; }

    }
}
