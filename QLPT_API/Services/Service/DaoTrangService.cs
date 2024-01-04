using QLPT_API.Entities;
using QLPT_API.Handles.Converters;
using QLPT_API.Handles.DTOs;
using QLPT_API.Handles.Request.DaoTrangRequest;
using QLPT_API.Handles.Response;
using QLPT_API.Helper;
using QLPT_API.Services.IService;

namespace QLPT_API.Services.Service
{
    public class DaoTrangService : IDaoTrangService
    {
        private readonly AppDbContext _context;
        private readonly DaoTrangConverter _converter;
        private readonly ResponseObject<DaoTrangDTO> _responseObject;

        public DaoTrangService(DaoTrangConverter daoTrangConverter, ResponseObject<DaoTrangDTO> responseObject)
        {
            _context = new AppDbContext();
            _converter = daoTrangConverter;
            _responseObject = responseObject;
        }

        // lấy danh sách
        public IQueryable<DaoTrangDTO> LayDanhSachDaoTrang(int pageSize = 10, int pageNumber = 1)
        {
            List<DaoTrangDTO> list = _context.DaoTrang
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(x => _converter.EntityToDTO(x)).ToList();
            return list.AsQueryable();
        }


        // Sửa
        public ResponseObject<DaoTrangDTO> SuaDaoTrang(int daoTrangId, Request_SuaDaoTrang request)
        {
            DaoTrang daoTrang = _context.DaoTrang.FirstOrDefault(x => x.Id == daoTrangId);
            if(daoTrang == null)
            {
                _responseObject.Status = StatusCodes.Status404NotFound;
                _responseObject.Data = null;
                _responseObject.Message = "Đạo tràng không tồn tại";
                return _responseObject;
            }

            PhatTu truTri = _context.PhatTu.FirstOrDefault(x => x.Id == request.NguoiTruTriId);
            if (truTri == null)
            {
                _responseObject.Message = "Trụ trì không tồn tại";
                _responseObject.Status = StatusCodes.Status404NotFound;
                _responseObject.Data = null;
                return _responseObject;
            }
            if (InputHelper.IsDateTime(request.ThoiGianBatDau.ToString()))
            {
                _responseObject.Message = "Định dạng thời gian không hợp lệ";
                _responseObject.Status = StatusCodes.Status400BadRequest;
                _responseObject.Data = null;
                return _responseObject;
            }
            if (request.ThoiGianBatDau < DateTime.Now)
            {
                _responseObject.Message = "Thời gian bắt đầu không hợp lệ";
                _responseObject.Status = StatusCodes.Status400BadRequest;
                _responseObject.Data = null;
                return _responseObject;
            }
            daoTrang.ThoiGianBatDau = request.ThoiGianBatDau;
            daoTrang.NguoiTruTriId = request.NguoiTruTriId;
            daoTrang.DaKetThuc = request.DaKetThuc;
            daoTrang.NoiDung = request.NoiDung;
            daoTrang.NoiToChuc = request.NoiToChuc;
            _context.Update(daoTrang);
            _context.SaveChanges();

            _responseObject.Message = "Sửa đổi thông tin đạo tràng thành công";
            _responseObject.Status = StatusCodes.Status200OK;
            _responseObject.Data = _converter.EntityToDTO(daoTrang);
            return _responseObject;

        }

        // Thêm đạo tràng
        public ResponseObject<DaoTrangDTO> ThemDaoTrang(Request_ThemDaoTrang request)
        {
            PhatTu truTri = _context.PhatTu.FirstOrDefault(x => x.Id == request.NguoiTruTriId);
            if(truTri == null)
            {
                _responseObject.Message = "Trụ trì không tồn tại";
                _responseObject.Status = StatusCodes.Status404NotFound;
                _responseObject.Data = null;
                return _responseObject;
            }
            if (InputHelper.IsDateTime(request.ThoiGianBatDau.ToString()))
            {
                _responseObject.Message = "Định dạng thời gian không hợp lệ";
                _responseObject.Status = StatusCodes.Status400BadRequest;
                _responseObject.Data = null;
                return _responseObject;
            }

            if(request.ThoiGianBatDau < DateTime.Now)
            {
                _responseObject.Message = "Thời gian bắt đầu không hợp lệ";
                _responseObject.Status = StatusCodes.Status400BadRequest;
                _responseObject.Data = null;
                return _responseObject;
            }

            DaoTrang daoTrang = new DaoTrang
            {
                DaKetThuc = false,
                NoiDung = request.NoiDung,
                NoiToChuc = request.NoiToChuc,
                ThoiGianBatDau = request.ThoiGianBatDau,
                NguoiTruTriId = truTri.Id,
                SoThanhVien = 0,
            };
            _context.Add(daoTrang);
            _context.SaveChanges();

            _responseObject.Message = "Thêm mới đạo tràng thành công";
            _responseObject.Status = StatusCodes.Status200OK;
            _responseObject.Data = _converter.EntityToDTO(daoTrang);
            return _responseObject;
        }

        // Xóa
        public ResponseObject<DaoTrangDTO> XoaDaoTrang(int daoTrangId)
        {
            DaoTrang daoTrang = _context.DaoTrang.FirstOrDefault(x => x.Id == daoTrangId);
            if(daoTrang == null) 
            {
                _responseObject.Data = null;
                _responseObject.Message = "Đạo tràng không tồn tại";
                _responseObject.Status = StatusCodes.Status404NotFound;
                return _responseObject;
            }

            _responseObject.Data = null;
            _responseObject.Message = "Đạo tràng không tồn tại";
            _responseObject.Status = StatusCodes.Status400BadRequest;
            return _responseObject;
        }
    }
}
