using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLPT_API.Services.IService;
using QLPT_API.Services.Service;

namespace QLPT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ChuaController : ControllerBase
    {
        private readonly IChuaService chuaService;

        public ChuaController(IChuaService chuaService)
        {
            this.chuaService = chuaService;
        }

        [HttpGet]
        [Route("/api/Chua/GetAll")]
        public IActionResult GetAll(int pageSize, int pageNumber)
        {
            return Ok(chuaService.GetAll(pageSize, pageNumber));
        }
    }
}
