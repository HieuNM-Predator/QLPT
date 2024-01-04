using QLPT_API.Handles.DTOs;
using QLPT_API.Handles.Response;

namespace QLPT_API.Services.IService
{
    public interface IPhatTuService
    {
        IQueryable<PhatTuDTO> LayDanhSachPhatTu(int pageSize = 10, int pageNumber = 1);
        IQueryable<PhatTuDTO> GetByPhapDanh(string phapDanh, int pageSize = 10, int pageNumber = 1);
        IQueryable<PhatTuDTO> GetByGioiTinh(string gioiTinh, int pageSize = 10, int pageNumber = 1);
    }
}
