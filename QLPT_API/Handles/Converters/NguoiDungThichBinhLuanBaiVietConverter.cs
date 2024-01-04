using QLPT_API.Entities;
using QLPT_API.Handles.DTOs;

namespace QLPT_API.Handles.Converters
{
    public class NguoiDungThichBinhLuanBaiVietConverter
    {
        private readonly AppDbContext _context;

        public NguoiDungThichBinhLuanBaiVietConverter()
        {
            _context = new AppDbContext();
        }
        public NguoiDungThichBinhLuanBaiVietDTO EntityToDTO(NguoiDungThichBinhLuanBaiViet entity)
        {
            PhatTu pt = _context.PhatTu.FirstOrDefault(x => x.Id == entity.PhatTuId);
            return new NguoiDungThichBinhLuanBaiVietDTO
            {
                TenPhatTu = pt.PhapDanh,
                ThoiGianLike = entity.ThoiGianLike,
                BinhLuanBaiVietId = entity.BinhLuanBaiVietId
            };
        }
    }
}
