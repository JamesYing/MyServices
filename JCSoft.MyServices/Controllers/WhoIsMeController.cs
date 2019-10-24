using JCSoft.MyServices.WebCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace JCSoft.MyServices.Controllers
{
    [Route("/api/who")]
    public class WhoIsMeController : MyControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public WhoIsMeController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public ApiResponseBase Get()
        {
            return TryFunc(() =>
            {
                var ip = this.Request.Headers["X-Forwarded-For"].FirstOrDefault();
                if (string.IsNullOrEmpty(ip))
                {
                    ip = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
                }
                return ip;
            });
            
        }
    }
}
