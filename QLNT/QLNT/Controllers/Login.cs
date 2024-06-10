using Microsoft.AspNetCore.Mvc;

namespace QLNT.Controllers
{
    public class Login : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
