namespace QLPT_API.Entities
{
    public class QuyenHan
    {
        public int Id { get; set; }
        public string TenQuyenHan { get; set; }
        public IEnumerable<PhatTu> PhatTus { get; set; }
    }
}
