using Azure.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLPT_API.Handles.Request.BinhLuanRequest;
using QLPT_API.Services.IService;
using QLPT_API.Services.Service;

namespace QLPT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BinhLuanBaiVietController : ControllerBase
    {
        private readonly IBinhLuanService binhLuanService;

        public BinhLuanBaiVietController(IBinhLuanService binhLuanService)
        {
            this.binhLuanService = binhLuanService;
        }

        [HttpPost]
        [Route("/api/BinhLuanBaiViet/themBinhLuan")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult ThemBinhLuan(int baiVietId, Request_ThemBinhLuan request)
        {
            if (!int.TryParse(HttpContext.User.FindFirst("Id")?.Value, out int id))
            {
                return BadRequest("Id người dùng không hợp lệ");
            }
            var result = binhLuanService.ThemBinhLuan(id, baiVietId, request);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut]
        [Route("/api/BinhLuanBaiViet/suaBinhLuan")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult SuaBinhLuan(int baiVietId, int binhLuanId, Request_SuaBinhLuan request)
        {
            if (!int.TryParse(HttpContext.User.FindFirst("Id")?.Value, out int id))
            {
                return BadRequest("Id người dùng không hợp lệ");
            }
            var result = binhLuanService.SuaBinhLuan(id, baiVietId, binhLuanId, request);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("/api/BinhLuanBaiViet/thichBinhLuan")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult ThichBinhLuan([FromBody] int baiVietId, int binhLuanId)
        {
            if (!int.TryParse(HttpContext.User.FindFirst("Id")?.Value, out int id))
            {
                return BadRequest("Id người dùng không hợp lệ");
            }
            var result = binhLuanService.ThichBinhLuan(id, baiVietId, binhLuanId);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
