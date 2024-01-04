using Microsoft.EntityFrameworkCore;
using QLPT_API.Entities;
using QLPT_API.Handles.DTOs;

namespace QLPT_API.Handles.Converters
{
    public class DaoTrangConverter
    {
        private readonly AppDbContext _context;
        private readonly PhatTuConverter _phatTuConverter;
        private readonly PhatTuDaoTrangConverter _phatTuDaoTrangConverter;

        public DaoTrangConverter(PhatTuConverter phatTuConverter, PhatTuDaoTrangConverter phatTuDaoTrangConverter)
        {
            _context = new AppDbContext();
            _phatTuConverter = phatTuConverter;
            _phatTuDaoTrangConverter = phatTuDaoTrangConverter;
        }
        public DaoTrangDTO EntityToDTO(DaoTrang daoTrang)
        {
            PhatTu truTri = _context.PhatTu.FirstOrDefault(x => x.Id == daoTrang.NguoiTruTriId);
            List<PhatTuDaoTrang> list = _context.PhatTuDaoTrang.Include(x => x.PhatTu).Include(x => x.DaoTrang).Where(x => x.DaoTrangId == daoTrang.Id).ToList();
            List<PhatTuDaoTrangDTO> phatTuDaoTrangDTOs = new List<PhatTuDaoTrangDTO>();
            foreach (var phatTuDaoTrang in list)
            {
                phatTuDaoTrangDTOs.Add(_phatTuDaoTrangConverter.EntityToDTO(phatTuDaoTrang));
            }
            return new DaoTrangDTO()
            {
                NoiDung = daoTrang.NoiDung,
                DaKetThuc = daoTrang.DaKetThuc,
                NoiToChuc = daoTrang.NoiToChuc,
                SoThanhVien = daoTrang.SoThanhVien,
                ThoiGianBatDau = daoTrang.ThoiGianBatDau,
                //NguoiTruTri = _phatTuConverter.EntityToDTO(truTri),
                TenTruTri = truTri.PhapDanh,
                PhatTuDaoTrangDTOs = phatTuDaoTrangDTOs.AsQueryable(),
            };
        }
    }
}
