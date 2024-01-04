using Azure;
using QLPT_API.Handles.DTOs;
using QLPT_API.Handles.Request.DonDangKyRequest;
using QLPT_API.Handles.Response;

namespace QLPT_API.Services.IService
{
    public interface IDonDangKyService
    {
        ResponseObject<DonDangKyDTO> DangKyThamGiaDaoTrang(int phatTuId, Request_DangKyThamGiaDaoTrang request);
        ResponseObject<DonDangKyDTO> DuyetDonDangKy(int phatTuId, Request_DuyetDonDangKy rquest);
        ResponseObject<DonDangKyDTO> SuaDonDangKy(int phatTuId, Request_SuaDonDangKy request);
        IQueryable<DonDangKyDTO> LayDanhSachDonDangKy(int pageSize = 10, int pageNumber = 1);
    }
}
