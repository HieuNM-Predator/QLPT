namespace QLPT_API.Entities
{
    public class ConfirmEmail
    {
        public int Id { get; set; }
        public DateTime ThoiGianHetHan { get; set; }
        public string MaXacNhan { get; set; }
        public bool DaXacNhan { get; set; }

        public int PhatTuId { get; set; }
        public PhatTu PhatTu { get; set; }
    }
}
