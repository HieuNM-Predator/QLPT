namespace QLPT_API.Handles.Request.AuthRequest
{
    public class Request_Register
    {
        public string TenTaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string Email { get; set; }
        public string GioiTinh { get; set; }
        public string SoDienThoai { get; set; }
        public string PhapDanh { get; set; }
        public DateTime NgaySinh { get; set; }
        public IFormFile AnhChup { get; set; }
        public bool DaHoanTuc { get; set; }
        public DateTime? NgayHoanTuc { get; set; }
        public int ChuaId { get; set; }
    }
}
