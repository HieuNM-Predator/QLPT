using QLPT_API.Entities;
using QLPT_API.Handles.DTOs;

namespace QLPT_API.Handles.Converters
{
    public class TrangThaiDonConverter
    {
        public TrangThaiDonDTO EntityToDTO(TrangThaiDon trangThaiDon)
        {
            return new TrangThaiDonDTO()
            {
                TenTrangThai = trangThaiDon.TenTrangThai,
            };
        }
    }
}
