using Microsoft.EntityFrameworkCore;
using QLPT_API.Entities;
using QLPT_API.Handles.DTOs;

namespace QLPT_API.Handles.Converters
{
    public class DonDangKyConverter
    {
        private readonly AppDbContext _context;
        private readonly DaoTrangConverter daoTrangConverter;
        private readonly PhatTuConverter phatTuConverter;
        private readonly TrangThaiDonConverter trangThaiDonConverter;

        public DonDangKyConverter(DaoTrangConverter daoTrangConverter, PhatTuConverter phatTuConverter, TrangThaiDonConverter trangThaiDonConverter)
        {
            _context = new AppDbContext();
            this.daoTrangConverter = daoTrangConverter;
            this.phatTuConverter = phatTuConverter;
            this.trangThaiDonConverter = trangThaiDonConverter;
        }
        public DonDangKyDTO EntityToDTO(DonDangKy donDangKy) 
        {
            DonDangKy donDangKyFull = _context.DonDangKy.Include(x => x.DaoTrang).Include(x => x.PhatTu).FirstOrDefault(x => x.Id == donDangKy.Id);

            DaoTrang daoTrang = _context.DaoTrang.FirstOrDefault(x => x.Id == donDangKy.DaoTrangId);
            PhatTu phatTu = _context.PhatTu.FirstOrDefault(x => x.Id == donDangKy.PhatTuId);
            PhatTu nguoiXuLy = _context.PhatTu.FirstOrDefault(x => x.Id == donDangKy.NguoiXuLyId);
            TrangThaiDon trangThaiDon = _context.TrangThaiDon.FirstOrDefault(x => x.Id == donDangKy.TrangThaiDonId);
            return new DonDangKyDTO()
            {
                NgayGuiDon = donDangKy.NgayGuiDon,
                NgayXuLy = donDangKy.NgayXuLy,
                TenNguoiXuly = nguoiXuLy.PhapDanh,
                //NguoiXuLy = phatTuConverter.EntityToDTO(nguoiXuLy),
                //DaoTrang = daoTrangConverter.EntityToDTO(donDangKyFull.DaoTrang),
                //PhatTu = phatTuConverter.EntityToDTO(donDangKyFull.PhatTu),
                DaoTrangId = daoTrang.Id,
                TenPhatTu = phatTu.PhapDanh,
                TrangThaiDon = trangThaiDonConverter.EntityToDTO(donDangKyFull.TrangThaiDon),
            };
        }
    }
}
