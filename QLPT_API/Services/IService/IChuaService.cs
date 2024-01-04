using QLPT_API.Handles.DTOs;
using QLPT_API.Handles.Response;

namespace QLPT_API.Services.IService
{
    public interface IChuaService
    {
        IQueryable<ChuaDTO> GetAll(int pageSize, int pageNumber);
        ResponseObject<ChuaDTO> GetById(int id);
    }
}
