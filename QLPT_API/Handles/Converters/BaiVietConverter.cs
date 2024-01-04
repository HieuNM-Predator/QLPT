using QLPT_API.Entities;
using QLPT_API.Handles.DTOs;

namespace QLPT_API.Handles.Converters
{
    public class BaiVietConverter
    {
        private readonly AppDbContext _context;
        private readonly TrangThaiBaiVietConverter trangThaiBaiVietConverter;
        private readonly NguoiDungThichBaiVietConverter nguoiDungThichBaiVietConverter;
        private readonly BinhLuanBaiVietConverter binhLuanBaiVietConverter;

        public BaiVietConverter(TrangThaiBaiVietConverter trangThaiBaiVietConverter, NguoiDungThichBaiVietConverter nguoiDungThichBaiVietConverter, BinhLuanBaiVietConverter binhLuanBaiVietConverter)
        {
            _context = new AppDbContext();
            this.trangThaiBaiVietConverter = trangThaiBaiVietConverter;
            this.nguoiDungThichBaiVietConverter = nguoiDungThichBaiVietConverter;
            this.binhLuanBaiVietConverter = binhLuanBaiVietConverter;
        }
        public BaiVietDTO EntityToDTO(BaiViet baiViet)
        {
            PhatTu nguoiViet = _context.PhatTu.FirstOrDefault(x => x.Id == baiViet.PhatTuId);
            PhatTu nguoiDuyet = _context.PhatTu.FirstOrDefault(x => x.Id == baiViet.NguoiDuyetId);
            TrangThaiBaiViet trangThai = _context.TrangThaiBaiViet.FirstOrDefault(x => x.Id == baiViet.TrangThaiBaiVietId);
            LoaiBaiViet loai = _context.LoaiBaiViet.FirstOrDefault(x => x.Id == baiViet.LoaiBaiVietId);
            var nguoiDungThichbaiViets = _context.NguoiDungThichBaiViet
                .Where(x => x.BaiVietId == baiViet.Id && x.DaXoa == false)
                .Select(x => nguoiDungThichBaiVietConverter.EntityToDTO(x));
            var binhLuans = _context.BinhLuanBaiViet
                .Where(x => x.BaiVietId == baiViet.Id && x.DaXoa == false)
                .Select(x => binhLuanBaiVietConverter.EntityToDTO(x));
            BaiVietDTO dto = new BaiVietDTO()
            {
                TieuDe = baiViet.TieuDe,
                MoTa = baiViet.MoTa,
                NoiDung = baiViet.NoiDung,
                SoLuotBinhLuan = baiViet.SoLuotBinhLuan,
                SoLuotThich = baiViet.SoLuotThich,
                ThoiGianDang = baiViet.ThoiGianDang,
                ThoiGianCapNhat = baiViet.ThoiGianCapNhat,
                TrangThaiBaiViet = trangThaiBaiVietConverter.EntityToDTO(trangThai),
                NguoiDungThichBaiViets = nguoiDungThichbaiViets,
                NguoiViet = nguoiViet.PhapDanh,
                NguoiDuyet = nguoiDuyet.PhapDanh,
                TenLoaiBaiViet = loai.TenLoai,
                BinhLuanBaiViets = binhLuans,
            };
            return dto;
        }
    }
}
