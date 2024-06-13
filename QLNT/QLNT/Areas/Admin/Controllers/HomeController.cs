using GUIs.Areas.Admin.Controllers;
using Microsoft.AspNetCore.Mvc;
using QLNT.Helper;
using QLNT.Models.DAO;

namespace QLNT.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
		
	}
}
