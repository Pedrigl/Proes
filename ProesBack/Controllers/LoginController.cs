using Microsoft.AspNetCore.Mvc;

namespace ProesBack.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
