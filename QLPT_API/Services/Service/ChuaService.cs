using QLPT_API.Entities;
using QLPT_API.Handles.Converters;
using QLPT_API.Handles.DTOs;
using QLPT_API.Handles.Response;
using QLPT_API.Services.IService;

namespace QLPT_API.Services.Service
{
    public class ChuaService : IChuaService
    {
        private readonly AppDbContext context;
        private readonly ResponseObject<ChuaDTO> responseObject;
        private readonly ChuaConverter converter;

        public ChuaService(ResponseObject<ChuaDTO> responseObject, ChuaConverter converter)
        {
            this.context = new AppDbContext();
            this.responseObject = responseObject;
            this.converter = converter;
        }
        public IQueryable<ChuaDTO> GetAll(int pageSize, int pageNumber)
        {
            var lst = context.Chua.Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(x => converter.EntityToDTO(x));
            return lst;
        }

        public ResponseObject<ChuaDTO> GetById(int id)
        {
            var chua = context.Chua.FirstOrDefault(x => x.Id == id);
            if(chua == null)
            {
                responseObject.Data = null;
                responseObject.Status = StatusCodes.Status404NotFound;
                responseObject.Message = "Không tìm thấy";
                return responseObject;
            }
            responseObject.Data = converter.EntityToDTO(chua);
            responseObject.Status = StatusCodes.Status200OK;
            responseObject.Message = "Thành công";
            return responseObject;
        }
    }
}
