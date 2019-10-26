using JCSoft.MyServices.Business;
using JCSoft.MyServices.Models.Requests;
using JCSoft.MyServices.WebCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace JCSoft.MyServices.Controllers
{
    [Route("/api/password")]
    public class PasswordController : MyControllerBase
    {
        private readonly IPasswordManager _passwordManager;
        public PasswordController(IPasswordManager passwordManager)
        {
            _passwordManager = passwordManager;
        }

        [HttpGet]
        [Route("md5")]
        public ApiResponseBase Get(PasswordRequest request)
        {
            return TryFunc(() => _passwordManager.Md5(request));
            
        }
    }
}
