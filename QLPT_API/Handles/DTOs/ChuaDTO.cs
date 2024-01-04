using QLPT_API.Entities;

namespace QLPT_API.Handles.DTOs
{
    public class ChuaDTO
    {
        public string TenChua { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgayThanhLap { get; set; }
        public string NguoiTruTri { get; set; }
        public IQueryable<PhatTuDTO> PhatTuDTOs { get; set; }
    }
}
