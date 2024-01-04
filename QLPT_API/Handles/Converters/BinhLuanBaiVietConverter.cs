using QLPT_API.Entities;
using QLPT_API.Handles.DTOs;

namespace QLPT_API.Handles.Converters
{
    public class BinhLuanBaiVietConverter
    {
        private readonly AppDbContext _context;
        private readonly NguoiDungThichBinhLuanBaiVietConverter ndtblConverter;

        public BinhLuanBaiVietConverter(NguoiDungThichBinhLuanBaiVietConverter ndtblConverter)
        {
            _context = new AppDbContext();
            this.ndtblConverter = ndtblConverter;
        }
        public BinhLuanBaiVietDTO EntityToDTO(BinhLuanBaiViet binhLuan)
        {
            PhatTu pt = _context.PhatTu.FirstOrDefault(x => x.Id == binhLuan.PhatTuId);
            var nguoiDungThichBinhLuanBaiViets = _context.NguoiDungThichBinhLuanBaiViet
                                                    .Where(x => x.BinhLuanBaiVietId == binhLuan.Id && x.DaXoa == false)
                                                    .Select(x => ndtblConverter.EntityToDTO(x));
            return new BinhLuanBaiVietDTO
            {
                BinhLuan = binhLuan.BinhLuan,
                SoLuotThich = binhLuan.SoLuotThich,
                ThoiGianTao = binhLuan.ThoiGianTao,
                ThoiGianCapNhat = binhLuan.ThoiGianCapNhat,
                BaiVietId = binhLuan.BaiVietId,
                TenPhatTu = pt.PhapDanh,
                NguoiDungThichBinhLuanBaiViets = nguoiDungThichBinhLuanBaiViets,
            };
        }
    }
}
