namespace QLPT_API.Entities
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime ThoiGianHetHan { get; set; }

        public int PhatTuId { get; set; }
        public PhatTu PhatTu { get; set; }
    }
}
