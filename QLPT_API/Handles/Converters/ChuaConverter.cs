using QLPT_API.Entities;
using QLPT_API.Handles.DTOs;

namespace QLPT_API.Handles.Converters
{
    public class ChuaConverter
    {
        public ChuaDTO EntityToDTO(Chua chua)
        {
            return new ChuaDTO
            {
                TenChua = chua.TenChua,
                DiaChi = chua.DiaChi,
                NgayThanhLap = chua.NgayThanhLap,
                NguoiTruTri = chua.NguoiTruTri,
            };
        }
    }
}
