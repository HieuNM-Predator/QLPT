using Azure.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLPT_API.Handles.Request.BaiVietRequest;
using QLPT_API.Services.IService;
using QLPT_API.Services.Service;

namespace QLPT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaiVietController : ControllerBase
    {
        private readonly IBaiVietService _baiVietService;

        public BaiVietController(IBaiVietService _baiVietService)
        {
            this._baiVietService = _baiVietService;
        }

        [HttpPost]
        [Route("/api/BaiViet/themBaiViet")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult ThemMoibaiViet(Request_ThemBaiViet request)
        {
            if (!int.TryParse(HttpContext.User.FindFirst("Id")?.Value, out int id))
            {
                return BadRequest("Id người dùng không hợp lệ");
            }
            var result = _baiVietService.ThemBaiViet(id, request);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("/api/BaiViet/duyetBaiViet")]
        [Authorize(Roles = "Admin")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult DuyetBaiViet(Request_DuyetBaiViet request)
        {
            if (!int.TryParse(HttpContext.User.FindFirst("Id")?.Value, out int id))
            {
                return BadRequest("Id người dùng không hợp lệ");
            }
            var result = _baiVietService.DuyetBaiViet(id, request);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("/api/BaiViet/thichBaiViet")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult ThichBaiViet([FromBody] int baiVietId)
        {
            if (!int.TryParse(HttpContext.User.FindFirst("Id")?.Value, out int id))
            {
                return BadRequest("Id người dùng không hợp lệ");
            }
            var result = _baiVietService.ThichBaiViet(id, baiVietId);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete]
        [Route("/api/BaiViet/boThichBaiViet")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult BoThichBaiViet(int baiVietId)
        {
            if(!int.TryParse(HttpContext.User.FindFirst("Id")?.Value, out int id))
            {
                return BadRequest("Người dùng không hợp lệ");
            }
            var result = _baiVietService.BoThichBaiViet(id, baiVietId);
            if(result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);  
        }
    }
}
