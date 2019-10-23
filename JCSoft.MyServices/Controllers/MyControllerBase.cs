using Microsoft.AspNetCore.Mvc;

namespace JCSoft.MyServices.Controllers
{
    public class MyControllerBase : ControllerBase
    {
    }

    [ApiController]
    public abstract class MyApiControllerBase : MyControllerBase
    {

    }
}
