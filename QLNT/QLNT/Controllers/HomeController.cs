using Microsoft.AspNetCore.Mvc;
using QLNT.Helper;
using QLNT.Models;
using QLNT.Models.DAO;
using System.Diagnostics;
using System.Drawing;

namespace QLNT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private VideoDAO videoDAO = new VideoDAO();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
		public IActionResult ShowList()
		{
            tinTucDAO tinTucDAO = new tinTucDAO();
			
			var query = tinTucDAO.getList();
			
			return Json(new { data = query });
		}
		[HttpGet]
		public JsonResult getVideo()
		{
			var query = videoDAO.getItemView(1);
			return Json(new { data = query });
		}
	}
}
