using Microsoft.AspNetCore.Mvc;
using QLPT_API.Entities;
using QLPT_API.Handles.Converters;
using QLPT_API.Handles.DTOs;
using QLPT_API.Handles.Request.DonDangKyRequest;
using QLPT_API.Handles.Response;
using QLPT_API.Services.IService;

namespace QLPT_API.Services.Service
{
    public class DonDangKyService : IDonDangKyService
    {
        private readonly AppDbContext context;
        private readonly ResponseObject<DonDangKyDTO> responseObject;
        private readonly DonDangKyConverter converter;

        public DonDangKyService(ResponseObject<DonDangKyDTO> responseObject, DonDangKyConverter converter)
        {
            this.context = new AppDbContext();
            this.responseObject = responseObject;
            this.converter = converter;
        }

        //Đăng ký
        public ResponseObject<DonDangKyDTO> DangKyThamGiaDaoTrang(int phatTuId, Request_DangKyThamGiaDaoTrang request)
        {
            PhatTu phatTu = context.PhatTu.FirstOrDefault(x => x.Id == phatTuId);
            if(phatTu == null)
            {
                responseObject.Status = StatusCodes.Status404NotFound;
                responseObject.Data = null;
                responseObject.Message = "Người dùng không tồn tại";
                return responseObject;
            }
            DaoTrang daoTrang = context.DaoTrang.FirstOrDefault(x => x.Id == request.DaoTrangId);
            if(daoTrang == null)
            {
                responseObject.Status = StatusCodes.Status404NotFound;
                responseObject.Data = null;
                responseObject.Message = "Đạo tràng không tồn tại";
                return responseObject;
            }
            DonDangKy checkDonDangKy = context.DonDangKy.FirstOrDefault(x => x.DaoTrangId == daoTrang.Id && x.PhatTuId == phatTu.Id);
            if(checkDonDangKy != null)
            {
                responseObject.Status = StatusCodes.Status400BadRequest;
                responseObject.Data = null;
                responseObject.Message = "Bạn đã đăng ký tham gia đạo tràng này!";
                return responseObject;
            }

            DonDangKy donDangKyMoi = new DonDangKy()
            {
                NgayGuiDon = DateTime.Now,
                NgayXuLy = DateTime.Now,
                // Trạng thái đơn chưa duyệt
                TrangThaiDonId = 1,
                DaoTrangId = daoTrang.Id,
                PhatTuId = phatTu.Id,
                // Chưa xử lý
                NguoiXuLyId = 1,
            };
            context.DonDangKy.Add(donDangKyMoi);
            context.SaveChanges();

            responseObject.Status = StatusCodes.Status200OK;
            responseObject.Message = "Đã đăng ký tham gia đạo tràng";
            responseObject.Data = converter.EntityToDTO(donDangKyMoi);
            return responseObject;
        }

        // Duyệt
        public ResponseObject<DonDangKyDTO> DuyetDonDangKy(int phatTuId, Request_DuyetDonDangKy request)
        {
            PhatTu nguoiXuLy = context.PhatTu.FirstOrDefault(x => x.Id == phatTuId);
            if(nguoiXuLy == null)
            {
                responseObject.Message = "Người dùng không tồn tại";
                responseObject.Status = StatusCodes.Status404NotFound;
                responseObject.Data = null;
                return responseObject;
            }
            QuyenHan quyenHan = context.QuyenHan.FirstOrDefault(x => x.Id == nguoiXuLy.QuyenHanId);
            if(quyenHan.TenQuyenHan != "Admin")
            {
                responseObject.Message = "Người dùng không có quyền duyệt đơn đăng ký";
                responseObject.Status = StatusCodes.Status400BadRequest;
                responseObject.Data = null;
                return responseObject;
            }

            DonDangKy donDangKy = context.DonDangKy.FirstOrDefault(x => x.Id == request.Id);
            if (donDangKy == null)
            {
                responseObject.Message = "Đơn đăng ký không tồn tại";
                responseObject.Status = StatusCodes.Status404NotFound;
                responseObject.Data = null;
                return responseObject;
            }

            donDangKy.TrangThaiDonId = 2;
            donDangKy.NgayXuLy = DateTime.Now;
            donDangKy.NguoiXuLyId = nguoiXuLy.Id;
            context.Update(donDangKy);
            context.SaveChanges();

            DaoTrang daoTrang = context.DaoTrang.FirstOrDefault(x => x.Id == donDangKy.DaoTrangId);
            if(daoTrang == null)
            {
                responseObject.Status = StatusCodes.Status404NotFound;
                responseObject.Data = null;
                responseObject.Message = "Đạo tràng không tồn tại";
                return responseObject;
            }

            PhatTuDaoTrang ptdt = context.PhatTuDaoTrang.FirstOrDefault(x => x.DaoTrangId == daoTrang.Id && x.PhatTuId == donDangKy.PhatTuId);
            if(ptdt != null)
            {
                responseObject.Status = StatusCodes.Status400BadRequest;
                responseObject.Data = null;
                responseObject.Message = "Đơn đang ký đã duyệt";
                return responseObject;
            }
            PhatTuDaoTrang phatTuDaoTrang = new PhatTuDaoTrang()
            {
                PhatTuId = donDangKy.PhatTuId,
                DaThamGia = true,
                LyDoKhongThamGia = null,
                DaoTrangId = daoTrang.Id,
            };

            context.Add(phatTuDaoTrang);
            context.SaveChanges();

            // Đếm số thành viên tham gia
            daoTrang.SoThanhVien = context.PhatTuDaoTrang.Count(x => x.DaoTrangId == daoTrang.Id);
            context.Update(daoTrang);
            context.SaveChanges();

            responseObject.Message = "Đã duyệt đơn đăng ký thành công";
            responseObject.Status = StatusCodes.Status200OK;
            responseObject.Data = converter.EntityToDTO(donDangKy);
            return responseObject;
          
        }

        // Sửa
        public ResponseObject<DonDangKyDTO> SuaDonDangKy(int phatTuId, Request_SuaDonDangKy request)
        {
            PhatTu phatTu = context.PhatTu.FirstOrDefault(x => x.Id == phatTuId);
            if (phatTu == null)
            {
                responseObject.Status = StatusCodes.Status404NotFound;
                responseObject.Data = null;
                responseObject.Message = "Người dùng không tồn tại";
                return responseObject;
            }
            DaoTrang daoTrang = context.DaoTrang.FirstOrDefault(x => x.Id == request.daoTrangId);
            if (daoTrang == null)
            {
                responseObject.Status = StatusCodes.Status404NotFound;
                responseObject.Data = null;
                responseObject.Message = "Đạo tràng không tồn tại";
                return responseObject;
            }

            DonDangKy donDangKy = context.DonDangKy.FirstOrDefault(x => x.Id == request.donDangKyId);
            if (donDangKy == null)
            {
                responseObject.Status = StatusCodes.Status404NotFound;
                responseObject.Data = null;
                responseObject.Message = "Đơn đăng ký không tồn tại";
                return responseObject;
            }

            donDangKy.DaoTrangId = request.daoTrangId;
            context.Update(donDangKy);
            context.SaveChanges();

            responseObject.Status = StatusCodes.Status200OK;
            responseObject.Data = converter.EntityToDTO(donDangKy);
            responseObject.Message = "Sửa thông tin đơn đăng ký thành công";
            return responseObject;
        }

        //Lấy danh sách
        public IQueryable<DonDangKyDTO> LayDanhSachDonDangKy(int pageSize = 10, int pageNumber = 1)
        {
            return context.DonDangKy.Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(x => converter.EntityToDTO(x));
        }
    }
}
