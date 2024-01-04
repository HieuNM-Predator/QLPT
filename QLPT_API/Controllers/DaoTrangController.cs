using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLPT_API.Handles.Request.DaoTrangRequest;
using QLPT_API.Services.IService;

namespace QLPT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DaoTrangController : ControllerBase
    {
        private readonly IDaoTrangService _daoTrangService;
        public DaoTrangController(IDaoTrangService daoTrangService)
        {
            _daoTrangService = daoTrangService;
        }

        [HttpGet]
        [Route("/api/DaoTrang/danhSachDaoTrang")]
        public IActionResult LayDanhSachDaoTrang(int pageSize = 10, int pageNumber = 1)
        {
            return Ok(_daoTrangService.LayDanhSachDaoTrang(pageSize, pageNumber));
        }

        [HttpPost]
        [Route("/api/DaoTrang/themMoiDaoTrang")]
        public IActionResult ThemMoiDaoTrang(Request_ThemDaoTrang request)
        {
            return Ok(_daoTrangService.ThemDaoTrang(request));
        }
    }
}
