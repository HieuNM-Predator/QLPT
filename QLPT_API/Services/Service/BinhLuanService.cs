using Microsoft.EntityFrameworkCore;
using QLPT_API.Entities;
using QLPT_API.Handles.Converters;
using QLPT_API.Handles.DTOs;
using QLPT_API.Handles.Request.BinhLuanRequest;
using QLPT_API.Handles.Response;
using QLPT_API.Services.IService;

namespace QLPT_API.Services.Service
{
    public class BinhLuanService : IBinhLuanService
    {
        private readonly AppDbContext _context;
        private readonly ResponseObject<BinhLuanBaiVietDTO> responseObject;
        private readonly BinhLuanBaiVietConverter converter;

        public BinhLuanService(ResponseObject<BinhLuanBaiVietDTO> responseObject, BinhLuanBaiVietConverter converter)
        {
            _context = new AppDbContext();
            this.responseObject = responseObject;
            this.converter = converter;
        }
        public ResponseObject<BinhLuanBaiVietDTO> ThemBinhLuan(int phatTuId, int baiVietId, Request_ThemBinhLuan request)
        {
            PhatTu phatTu = _context.PhatTu.FirstOrDefault(x => x.Id == phatTuId);
            if (phatTu == null)
            {
                responseObject.Data = null;
                responseObject.Message = "Tài khoản không tồn tại";
                responseObject.Status = StatusCodes.Status404NotFound;
                return responseObject;
            }
            BaiViet baiViet = _context.BaiViet.FirstOrDefault(x => x.Id == baiVietId && x.DaXoa == false);
            if (baiViet == null)
            {
                responseObject.Data = null;
                responseObject.Message = "Bài viết không tồn tại";
                responseObject.Status = StatusCodes.Status404NotFound;
                return responseObject;
            }

            BinhLuanBaiViet bl = new BinhLuanBaiViet()
            {
                BaiVietId = baiViet.Id,
                PhatTuId = phatTu.Id,
                BinhLuan = request.BinhLuan,
                SoLuotThich = 0,
                ThoiGianTao = DateTime.Now,
                ThoiGianCapNhat = null,
                ThoiGianXoa = null,
                DaXoa = false,
            };

            _context.BinhLuanBaiViet.Add(bl);
            _context.SaveChanges();

            baiViet.SoLuotBinhLuan = _context.BinhLuanBaiViet.Count(x => x.BaiVietId == baiViet.Id);
            _context.BaiViet.Update(baiViet);
            _context.SaveChanges();

            responseObject.Data = converter.EntityToDTO(bl);
            responseObject.Message = "Thêm bình luận thành công";
            responseObject.Status = StatusCodes.Status200OK;
            return responseObject;
        }

        public ResponseObject<BinhLuanBaiVietDTO> SuaBinhLuan(int phatTuId, int baiVietId, int binhLuanId, Request_SuaBinhLuan request)
        {
            PhatTu phatTu = _context.PhatTu.FirstOrDefault(x => x.Id == phatTuId);
            if (phatTu == null)
            {
                responseObject.Data = null;
                responseObject.Message = "Tài khoản không tồn tại";
                responseObject.Status = StatusCodes.Status404NotFound;
                return responseObject;
            }
            BaiViet baiViet = _context.BaiViet.FirstOrDefault(x => x.Id == baiVietId && x.DaXoa == false);
            if (baiViet == null)
            {
                responseObject.Data = null;
                responseObject.Message = "Bài viết không tồn tại";
                responseObject.Status = StatusCodes.Status404NotFound;
                return responseObject;
            }
            BinhLuanBaiViet bl = _context.BinhLuanBaiViet.FirstOrDefault(x => x.Id == binhLuanId && x.BaiVietId == baiVietId && x.DaXoa == false);
            if (bl == null)
            {
                responseObject.Data = null;
                responseObject.Message = "Bình luận không tồn tại";
                responseObject.Status = StatusCodes.Status404NotFound;
                return responseObject;
            }

            bl.BinhLuan = request.BinhLuan;
            bl.ThoiGianCapNhat = DateTime.Now;
            _context.BinhLuanBaiViet.Update(bl);
            _context.SaveChanges();

            responseObject.Data = converter.EntityToDTO(bl);
            responseObject.Message = "Sửa bình luận thành công";
            responseObject.Status = StatusCodes.Status200OK;
            return responseObject;

        }

        public ResponseObject<BinhLuanBaiVietDTO> ThichBinhLuan(int phatTuId, int baiVietId, int binhLuanId)
        {
            PhatTu pt = _context.PhatTu.FirstOrDefault(x => x.Id == phatTuId);
            if (pt == null)
            {
                responseObject.Data = null;
                responseObject.Message = "Người dùng không tồn tại";
                responseObject.Status = StatusCodes.Status404NotFound;
                return responseObject;
            }

            BaiViet bv = _context.BaiViet.FirstOrDefault(x => x.Id == baiVietId && x.DaXoa == false);
            if(bv == null)
            {
                responseObject.Data = null;
                responseObject.Message = "Bài viết không tồn tại";
                responseObject.Status = StatusCodes.Status404NotFound;
                return responseObject;
            }

            BinhLuanBaiViet bl = _context.BinhLuanBaiViet.FirstOrDefault(x => x.Id == binhLuanId && x.DaXoa == false);
            if(bl == null)
            {
                responseObject.Data = null;
                responseObject.Message = "Bình luận không tồn tại";
                responseObject.Status = StatusCodes.Status404NotFound;
                return responseObject;
            }

            NguoiDungThichBinhLuanBaiViet nguoiDungThichBinhLuan = new NguoiDungThichBinhLuanBaiViet()
            {
                PhatTuId = pt.Id,
                BinhLuanBaiVietId = bl.Id,
                ThoiGianLike = DateTime.Now,
                DaXoa = false,
            };
            _context.NguoiDungThichBinhLuanBaiViet.Add(nguoiDungThichBinhLuan);
            _context.SaveChanges();

            bl.SoLuotThich = _context.NguoiDungThichBinhLuanBaiViet.Count(x => x.BinhLuanBaiVietId == bl.Id && x.DaXoa == false);
            _context.BinhLuanBaiViet.Update(bl);
            _context.SaveChanges();

            responseObject.Data = converter.EntityToDTO(bl);
            responseObject.Message = "Thích bình luận thành công";
            responseObject.Status = StatusCodes.Status200OK;
            return responseObject;
        }

        public ResponseObject<BinhLuanBaiVietDTO> XoaBinhLuan(int binhLuanId)
        {
            BinhLuanBaiViet bl = _context.BinhLuanBaiViet.FirstOrDefault(x => x.Id == binhLuanId && x.DaXoa == false);
            if(bl == null)
            {
                responseObject.Data = null;
                responseObject.Message = "Bình luận không tồn tại";
                responseObject.Status = StatusCodes.Status404NotFound;
                return responseObject;
            }

            bl.DaXoa = true;
            bl.ThoiGianXoa = DateTime.Now;
            _context.BinhLuanBaiViet.Update(bl);
            _context.SaveChanges();

            var thichBinhLuanBaiViets = _context.NguoiDungThichBinhLuanBaiViet.Where(x => x.BinhLuanBaiVietId == binhLuanId && x.DaXoa == false);
            if(thichBinhLuanBaiViets.Count() > 0)
            {
                thichBinhLuanBaiViets.ToList().ForEach(x => x.DaXoa = true);
                _context.NguoiDungThichBinhLuanBaiViet.UpdateRange(thichBinhLuanBaiViets);
                _context.SaveChanges();
            }

            responseObject.Data = null;
            responseObject.Message = "Xóa bình luận thành công";
            responseObject.Status = StatusCodes.Status200OK;
            return responseObject;
        }

        public ResponseObject<BinhLuanBaiVietDTO> BoThich(int phatTuId, int baiVietId, int binhLuanId)
        {
            PhatTu pt = _context.PhatTu.FirstOrDefault(x => x.Id == phatTuId);
            if(pt == null)
            {
                responseObject.Data = null;
                responseObject.Message = "Tài khoản không tồn tại";
                responseObject.Status = StatusCodes.Status404NotFound;
                return responseObject;
            }

            BaiViet bv = _context.BaiViet.FirstOrDefault(x => x.Id == baiVietId);
            if(bv == null)
            {
                responseObject.Data = null;
                responseObject.Message = "Bài viết không tồn tại";
                responseObject.Status = StatusCodes.Status404NotFound;
                return responseObject;
            }

            BinhLuanBaiViet bl = _context.BinhLuanBaiViet.FirstOrDefault(x => x.PhatTuId == phatTuId && x.BaiVietId == bv.Id && x.Id == binhLuanId);
            if(bl == null)
            {
                responseObject.Data = null;
                responseObject.Message = "Bình luận không tồn tại";
                responseObject.Status= StatusCodes.Status404NotFound;
                return responseObject;
            }

            NguoiDungThichBinhLuanBaiViet daThichBinhLuan = _context.NguoiDungThichBinhLuanBaiViet.FirstOrDefault(x => x.BinhLuanBaiVietId == binhLuanId && x.PhatTuId == pt.Id);
            if(daThichBinhLuan == null)
            {
                responseObject.Data = null;
                responseObject.Status = StatusCodes.Status404NotFound;
                responseObject.Message = "Người dùng chưa thích bình luận này";
                return responseObject;
            }

            daThichBinhLuan.DaXoa = true;
            _context.NguoiDungThichBinhLuanBaiViet.Update(daThichBinhLuan);
            _context.SaveChanges();

            bl.SoLuotThich = _context.NguoiDungThichBinhLuanBaiViet.Count(x => x.BinhLuanBaiVietId == bl.Id);
            _context.BinhLuanBaiViet.Update(bl);
            _context.SaveChanges();

            responseObject.Data = converter.EntityToDTO(bl);
            responseObject.Message = "Bỏ thích bình luận thành công";
            responseObject.Status = StatusCodes.Status200OK;
            return responseObject;
        }
    }
}
