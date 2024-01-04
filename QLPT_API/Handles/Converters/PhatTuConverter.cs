using QLPT_API.Entities;
using QLPT_API.Handles.DTOs;

namespace QLPT_API.Handles.Converters
{
    public class PhatTuConverter
    {
        public PhatTuDTO EntityToDTO(PhatTu phatTu)
        {
            return new PhatTuDTO
            {
                TenTaiKhoan = phatTu.TenTaiKhoan,
                AnhChup = phatTu.AnhChup,
                DaHoanTuc = phatTu.DaHoanTuc,
                Email = phatTu.Email,
                GioiTinh = phatTu.GioiTinh,
                NgaySinh = phatTu.NgaySinh,
                NgayHoanTuc = phatTu.NgayHoanTuc,
                PhapDanh = phatTu.PhapDanh,
                SoDienThoai = phatTu.SoDienThoai,
            };
        }
    }
}
