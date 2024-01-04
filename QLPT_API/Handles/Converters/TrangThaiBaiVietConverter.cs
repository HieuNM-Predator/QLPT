using QLPT_API.Entities;
using QLPT_API.Handles.DTOs;

namespace QLPT_API.Handles.Converters
{
    public class TrangThaiBaiVietConverter
    {
        public TrangThaiBaiVietDTO EntityToDTO(TrangThaiBaiViet trangThai)
        {
            return new TrangThaiBaiVietDTO
            {
                TenTrangThai = trangThai.TenTrangThai,
            };
        }
    }
}
