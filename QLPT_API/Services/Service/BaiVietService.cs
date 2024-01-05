using QLPT_API.Entities;
using QLPT_API.Handles.Converters;
using QLPT_API.Handles.DTOs;
using QLPT_API.Handles.Request.BaiVietRequest;
using QLPT_API.Handles.Response;
using QLPT_API.Services.IService;
using System;

namespace QLPT_API.Services.Service
{
    public class BaiVietService : IBaiVietService
    {
        private readonly AppDbContext _context;
        private readonly ResponseObject<BaiVietDTO> responseObject;
        private readonly BaiVietConverter baiVietConverter;

        public BaiVietService(ResponseObject<BaiVietDTO> responseObject, BaiVietConverter baiVietConverter)
        {
            _context = new AppDbContext();
            this.responseObject = responseObject;
            this.baiVietConverter = baiVietConverter;
        }

        public ResponseObject<BaiVietDTO> ThemBaiViet(int phatTuId, Request_ThemBaiViet request)
        {
            PhatTu phatTu = _context.PhatTu.FirstOrDefault(x => x.Id == phatTuId);
            if(phatTu == null)
            {
                responseObject.Data = null;
                responseObject.Message = "Tài khoản không tồn tại";
                responseObject.Status = StatusCodes.Status404NotFound;
                return responseObject;
            }
            BaiViet baiViet = new BaiViet()
            {
                LoaiBaiVietId = 1,
                TieuDe = request.TieuDe,
                MoTa = request.MoTa,
                NoiDung = request.NoiDung,
                PhatTuId = phatTu.Id,
                NguoiDuyetId = 1,
                SoLuotBinhLuan = 0,
                SoLuotThich = 0,
                ThoiGianDang = DateTime.Now,
                ThoiGianCapNhat = null,
                ThoiGianXoa = null,
                DaXoa = false,
                TrangThaiBaiVietId = 1
            };

            _context.BaiViet.Add(baiViet);
            _context.SaveChanges();

            responseObject.Status = StatusCodes.Status200OK;
            responseObject.Message = "Thêm mới bài viết thành công";
            responseObject.Data = baiVietConverter.EntityToDTO(baiViet);
            return responseObject;
        }

        public ResponseObject<BaiVietDTO> DuyetBaiViet(int phatTuId, Request_DuyetBaiViet request)
        {
            PhatTu nguoiDuyet = _context.PhatTu.FirstOrDefault(x => x.Id == phatTuId);
            if (nguoiDuyet == null)
            {
                responseObject.Data = null;
                responseObject.Message = "Tài khoản không tồn tại";
                responseObject.Status = StatusCodes.Status404NotFound;
                return responseObject;
            }
            QuyenHan quyenHan = _context.QuyenHan.FirstOrDefault(x => x.Id == nguoiDuyet.QuyenHanId);
            if (quyenHan.TenQuyenHan != "Admin" || quyenHan == null)
            {
                responseObject.Message = "Người dùng không có quyền duyệt đơn đăng ký";
                responseObject.Status = StatusCodes.Status400BadRequest;
                responseObject.Data = null;
                return responseObject;
            }
            BaiViet bv = _context.BaiViet.FirstOrDefault(x => x.Id == request.Id && x.DaXoa == false);
            if(bv == null)
            {
                responseObject.Message = "Bài viết không tồn tại";
                responseObject.Status = StatusCodes.Status404NotFound;
                responseObject.Data = null;
                return responseObject;
            }
            if(bv.TrangThaiBaiVietId == 2)
            {
                responseObject.Message = "Bài viết đã được duyệt";
                responseObject.Status = StatusCodes.Status400BadRequest;
                responseObject.Data = null;
                return responseObject;
            }
            bv.ThoiGianDang = DateTime.Now;
            bv.TrangThaiBaiVietId = 2;
            bv.NguoiDuyetId = nguoiDuyet.Id;
            _context.BaiViet.Update(bv);
            _context.SaveChanges();

            responseObject.Message = "Duyệt bài viết thành công";
            responseObject.Status = StatusCodes.Status200OK;
            responseObject.Data = baiVietConverter.EntityToDTO(bv);
            return responseObject;
        }

        public ResponseObject<BaiVietDTO> SuaBaiViet(int phatTuId, int baiVietId, Request_SuaBaiViet request)
        {
            PhatTu phatTu = _context.PhatTu.FirstOrDefault(x => x.Id == phatTuId);
            if (phatTu == null)
            {
                responseObject.Data = null;
                responseObject.Message = "Tài khoản không tồn tại";
                responseObject.Status = StatusCodes.Status404NotFound;
                return responseObject;
            }
            BaiViet bv = _context.BaiViet.FirstOrDefault(x => x.Id == baiVietId);
            if(bv == null)
            {
                responseObject.Message = "Bài viết không tồn tại";
                responseObject.Status = StatusCodes.Status404NotFound;
                responseObject.Data = null;
                return responseObject;
            }

            bv.MoTa = request.MoTa;
            bv.NoiDung = request.NoiDung;
            bv.TieuDe = request.TieuDe;
            bv.ThoiGianCapNhat = DateTime.Now;
            _context.BaiViet.Update(bv);
            _context.SaveChanges();

            responseObject.Message = "Sửa bài viết thành công";
            responseObject.Status = StatusCodes.Status200OK;
            responseObject.Data = baiVietConverter.EntityToDTO(bv);
            return responseObject;
        }


        public ResponseObject<BaiVietDTO> ThichBaiViet(int phatTuId, int baiVietId)
        {
            PhatTu phatTu = _context.PhatTu.FirstOrDefault(x => x.Id == phatTuId);
            if (phatTu == null)
            {
                responseObject.Data = null;
                responseObject.Message = "Tài khoản không tồn tại";
                responseObject.Status = StatusCodes.Status404NotFound;
                return responseObject;
            }
            BaiViet bv = _context.BaiViet.FirstOrDefault(x => x.Id == baiVietId);
            if (bv == null)
            {
                responseObject.Message = "Bài viết không tồn tại";
                responseObject.Status = StatusCodes.Status404NotFound;
                responseObject.Data = null;
                return responseObject;
            }

            NguoiDungThichBaiViet daThich = _context.NguoiDungThichBaiViet.FirstOrDefault(x => x.PhatTuId == phatTuId && x.BaiVietId == baiVietId);
            if (bv != null)
            {
                responseObject.Message = "Bạn đã thích bài viết này";
                responseObject.Status = StatusCodes.Status200OK;
                responseObject.Data = null;
                return responseObject;
            }

            NguoiDungThichBaiViet thichBaiViet = new NguoiDungThichBaiViet()
            {
                PhatTuId = phatTuId,
                BaiVietId = baiVietId,
                ThoiGianThich = DateTime.Now,
                DaXoa = false
            };

            _context.NguoiDungThichBaiViet.Add(thichBaiViet);
            _context.SaveChanges();

            bv.SoLuotThich = _context.NguoiDungThichBaiViet.Count(x => x.BaiVietId == bv.Id);
            _context.BaiViet.Update(bv);
            _context.SaveChanges();

            responseObject.Data = baiVietConverter.EntityToDTO(bv);
            responseObject.Message = "Thích bài viết thành công";
            responseObject.Status = StatusCodes.Status200OK;
            return responseObject;
        }


        public ResponseObject<BaiVietDTO> BoThichBaiViet(int phatTuId, int baiVietId)
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

            NguoiDungThichBaiViet daThich = _context.NguoiDungThichBaiViet.FirstOrDefault(x => x.PhatTuId == phatTuId && x.BaiVietId == baiVietId);
            if(daThich == null)
            {
                responseObject.Data = null;
                responseObject.Message = "Người dùng chưa thích bài viết";
                responseObject.Status = StatusCodes.Status400BadRequest;
                return responseObject;
            }
            daThich.DaXoa = true;
            _context.NguoiDungThichBaiViet.Update(daThich);
            _context.SaveChanges();

            bv.SoLuotThich = _context.NguoiDungThichBaiViet.Count(x => x.BaiVietId == bv.Id);
            _context.BaiViet.Update(bv);
            _context.SaveChanges();

            responseObject.Data = null;
            responseObject.Message = "Bỏ thích bình luận thành công";
            responseObject.Status = StatusCodes.Status200OK;
            return responseObject;
        }

        public ResponseObject<BaiVietDTO> XoaBaiViet(int baiVietId)
        {
            BaiViet bv = _context.BaiViet.FirstOrDefault(x => x.Id == baiVietId && x.DaXoa == false);   
            if(bv == null)
            {
                responseObject.Data = null;
                responseObject.Message = "Bài viết không tồn tại";
                responseObject.Status = StatusCodes.Status404NotFound;
                return responseObject;
            }

            bv.DaXoa = true;
            bv.ThoiGianXoa = DateTime.Now;
            _context.BaiViet.Update(bv);
            _context.SaveChanges();

            var nguoiDungThichBaiViet = _context.NguoiDungThichBaiViet.Where(x => x.BaiVietId == baiVietId && x.DaXoa == false);
            if(nguoiDungThichBaiViet.Count() > 0) 
            {
                nguoiDungThichBaiViet.ToList().ForEach(x => x.DaXoa = true);
                _context.NguoiDungThichBaiViet.UpdateRange(nguoiDungThichBaiViet);
                _context.SaveChanges();
            }

            responseObject.Data = null;
            responseObject.Message = "Xóa bài viết thành công";
            responseObject.Status = StatusCodes.Status200OK;
            return responseObject;
        }

        public IQueryable<BaiVietDTO> DanhSachBaiViet(int pageSize = 10, int pageNumber = 1)
        {
            return _context.BaiViet.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(x => baiVietConverter.EntityToDTO(x));
        }

    }
}
