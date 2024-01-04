using QLPT_API.Entities;
using QLPT_API.Handles.DTOs;

namespace QLPT_API.Handles.Converters
{
    public class PhatTuDaoTrangConverter
    {
        private readonly AppDbContext _context;
        private readonly PhatTuConverter _phatTuConverter;

        public PhatTuDaoTrangConverter(PhatTuConverter phatTuConverter)
        {
            _context = new AppDbContext();
            _phatTuConverter = phatTuConverter;
        }
        public PhatTuDaoTrangDTO EntityToDTO(PhatTuDaoTrang phatTuDaoTrang)
        {
            PhatTu phatTu = _context.PhatTu.FirstOrDefault(x => x.Id == phatTuDaoTrang.PhatTuId);
            return new PhatTuDaoTrangDTO()
            {
                DaThamGia = phatTuDaoTrang.DaThamGia,
                LyDoKhongThamGia = phatTuDaoTrang.LyDoKhongThamGia,
                PhatTuDTO = _phatTuConverter.EntityToDTO(phatTu),
            };
        }
    }
}
