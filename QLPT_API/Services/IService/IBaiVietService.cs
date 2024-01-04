using Azure;
using QLPT_API.Handles.DTOs;
using QLPT_API.Handles.Request.BaiVietRequest;
using QLPT_API.Handles.Response;

namespace QLPT_API.Services.IService
{
    public interface IBaiVietService
    {
        ResponseObject<BaiVietDTO> ThemBaiViet(int phatTuId, Request_ThemBaiViet request);
        ResponseObject<BaiVietDTO> SuaBaiViet(int phatTuId, int baiVietId, Request_SuaBaiViet request);
        ResponseObject<BaiVietDTO> DuyetBaiViet(int phatTuId, Request_DuyetBaiViet request);
        ResponseObject<BaiVietDTO> XoaBaiViet(int baiVietId);
        ResponseObject<BaiVietDTO> ThichBaiViet(int phatTuId, int baiVietId);
        ResponseObject<BaiVietDTO> BoThichBaiViet(int phatTuId, int baiVietId);
        IQueryable<BaiVietDTO> DanhSachBaiViet(int pageSize = 10, int pageNumber = 1);

    }
}
