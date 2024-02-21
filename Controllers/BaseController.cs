using Microsoft.AspNetCore.Mvc;

namespace TS.Controllers
{
    public abstract class BaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
