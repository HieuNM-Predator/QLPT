namespace QLPT_API.Entities
{
    public class Chua
    {
        public int Id { get; set; }
        public string TenChua { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgayThanhLap { get; set; }
        public string  NguoiTruTri { get; set; }
        public IEnumerable<PhatTu> PhatTus { get; set; }
    }
}
