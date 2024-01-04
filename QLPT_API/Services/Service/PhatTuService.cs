using QLPT_API.Entities;
using QLPT_API.Handles.Converters;
using QLPT_API.Handles.DTOs;
using QLPT_API.Services.IService;

namespace QLPT_API.Services.Service
{
    public class PhatTuService : IPhatTuService
    {
        private readonly AppDbContext _context;
        private readonly PhatTuConverter _converter;

        public PhatTuService(PhatTuConverter converter)
        {
            _context = new AppDbContext();
            _converter = converter;
        }
        public IQueryable<PhatTuDTO> GetByGioiTinh(string gioiTinh, int pageSize = 10, int pageNumber = 1)
        {
            List<PhatTuDTO> list = _context.PhatTu
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Where(x => x.isActive == true && x.QuyenHanId != 2 && x.GioiTinh == gioiTinh)
                .Select(x => _converter.EntityToDTO(x)).ToList();
            return list.AsQueryable();
        }

        public IQueryable<PhatTuDTO> GetByPhapDanh(string phapDanh, int pageSize = 10, int pageNumber = 1)
        {
            return _context.PhatTu
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Where(x => x.isActive == true && x.QuyenHanId != 2 && x.PhapDanh.ToLower().Contains(phapDanh.ToLower()))
                .Select(x => _converter.EntityToDTO(x));
        }

        public IQueryable<PhatTuDTO> LayDanhSachPhatTu(int pageSize = 10, int pageNumber = 1)
        {
            return _context.PhatTu
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Where(x => x.isActive == true && x.QuyenHanId != 2)
                .Select(x => _converter.EntityToDTO(x));
           
        }
    }
}
