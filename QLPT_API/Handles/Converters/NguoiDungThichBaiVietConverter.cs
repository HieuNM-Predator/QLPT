using QLPT_API.Entities;
using QLPT_API.Handles.DTOs;

namespace QLPT_API.Handles.Converters
{
    public class NguoiDungThichBaiVietConverter
    {
        private readonly AppDbContext _context;

        public NguoiDungThichBaiVietConverter()
        {
            _context = new AppDbContext();
        }
        public NguoiDungThichBaiVietDTO EntityToDTO(NguoiDungThichBaiViet entity)
        {
            PhatTu pt = _context.PhatTu.FirstOrDefault(x => x.Id == entity.PhatTuId);
            return new NguoiDungThichBaiVietDTO
            {
                TenPhatTu = pt.PhapDanh,
                ThoiGianThich = entity.ThoiGianThich,
            };
        }
    }
}
