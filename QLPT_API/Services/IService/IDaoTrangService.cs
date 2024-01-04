using Azure;
using QLPT_API.Handles.DTOs;
using QLPT_API.Handles.Request.DaoTrangRequest;
using QLPT_API.Handles.Response;

namespace QLPT_API.Services.IService
{
    public interface IDaoTrangService
    {
        public ResponseObject<DaoTrangDTO> ThemDaoTrang(Request_ThemDaoTrang request);
        public ResponseObject<DaoTrangDTO> SuaDaoTrang(int daoTrangId, Request_SuaDaoTrang request);
        public ResponseObject<DaoTrangDTO> XoaDaoTrang(int daoTrangId);
        public IQueryable<DaoTrangDTO> LayDanhSachDaoTrang(int pageSize = 10, int pageNumber = 1);
    }
}
