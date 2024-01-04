using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLPT_API.Handles.Request.DonDangKyRequest;
using QLPT_API.Services.IService;

namespace QLPT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonDangKyController : ControllerBase
    {
        private readonly IDonDangKyService dangKyService;

        public DonDangKyController(IDonDangKyService dangKyService)
        {
            this.dangKyService = dangKyService;
        }

        // Gửi đơn đăng ký 
        [HttpPost]
        [Route("/api/DonDangKy/dangKyDaotrang")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult DangKyThamGiaDaoTrang(Request_DangKyThamGiaDaoTrang request)
        {
            int id = int.Parse(HttpContext.User.FindFirst("Id").Value);
            var result = dangKyService.DangKyThamGiaDaoTrang(id, request);
            if(result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


        // Duyệt đơn đăng ký
        [HttpPost]
        [Route("/api/DonDangKy/duyetDonDangKy")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Admin")]
        public IActionResult DuyetDonDangKy(Request_DuyetDonDangKy request)
        {
            int id = int.Parse(HttpContext.User.FindFirst("Id").Value);
            var result = dangKyService.DuyetDonDangKy(id, request);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // Sửa đơn đăng ký tham gia
        [HttpPut]
        [Route("/api/DonDangKy/SuaDonDangKy")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult SuaDonDangKy(Request_SuaDonDangKy request)
        {
            int id = int.Parse(HttpContext.User.FindFirst("Id").Value);
            var result = dangKyService.SuaDonDangKy(id, request);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // Lấy danh sách đơn đăng ký
        [HttpGet]
        [Route("/api/DonDangKy/danhSachDonDangKy")]
        [Authorize]
        public IActionResult LayDanhSachDonDangKy(int pageSize = 10, int pageNumber = 1)
        {
            return Ok(dangKyService.LayDanhSachDonDangKy(pageSize, pageNumber));    
        }
    }
}
