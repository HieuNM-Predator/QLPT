using QLPT_API.Handles.DTOs;
using QLPT_API.Handles.Request.BinhLuanRequest;
using QLPT_API.Handles.Response;

namespace QLPT_API.Services.IService
{
    public interface IBinhLuanService
    {
        public ResponseObject<BinhLuanBaiVietDTO> ThemBinhLuan(int phatTuId, int baiVietId, Request_ThemBinhLuan request);
        public ResponseObject<BinhLuanBaiVietDTO> SuaBinhLuan(int phatTuId, int baiVietId,  int binhLuanId, Request_SuaBinhLuan request);
        public ResponseObject<BinhLuanBaiVietDTO> ThichBinhLuan(int phatTuId, int baiVietId, int binhLuanId);
        public ResponseObject<BinhLuanBaiVietDTO> XoaBinhLuan(int binhLuanId);
        public ResponseObject<BinhLuanBaiVietDTO> BoThich(int phatTuId, int baiVietId, int binhLuanId);
    }
}
