using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JCSoft.MyServices.Controllers
{
    [Route("/api/who")]
    public class WhoIsMeController : MyApiControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public WhoIsMeController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Content(_httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString());
        }
    }
}
