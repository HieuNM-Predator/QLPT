using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLPT_API.Services.IService;

namespace QLPT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhatTuController : ControllerBase
    {
        private readonly IPhatTuService phatTuService;

        public PhatTuController(IPhatTuService phatTuService)
        {
            this.phatTuService = phatTuService;
        }

        [HttpGet]
        [Route("/api/phatTu/danhSachPhatTu")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult LayDanhSachPhatTu(int pageSize = 10, int pageNumber  = 1)
        {
            return Ok(phatTuService.LayDanhSachPhatTu(pageSize, pageNumber));
        }

        [HttpGet]
        [Route("/api/phatTu/getByPhapDanh")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GetbyPhapDanh(string phapDanh, int pageSize = 10, int pageNumber = 1)
        {
            return Ok(phatTuService.GetByPhapDanh(phapDanh, pageSize, pageNumber));
        }

        [HttpGet]
        [Route("/api/phatTu/getByGioiTinh")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GetByGioiTinh(string gioiTinh, int pageSize = 10, int pageNumber = 1)
        {
            return Ok(phatTuService.GetByGioiTinh(gioiTinh, pageSize, pageNumber));
        }
    }
}
