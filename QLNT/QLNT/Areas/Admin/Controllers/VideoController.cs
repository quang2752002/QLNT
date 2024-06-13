using Microsoft.AspNetCore.Mvc;
using QLNT.Helper;
using QLNT.Models.DAO;
using QLNT.Models.EF;

namespace QLNT.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VideoController : Controller
    {
		VideoDAO videoDAO=new VideoDAO();
        public IActionResult Index()
        {
            return View();
        }
		public IActionResult ShowList()
		{
			int total = 0;
			var query = videoDAO.getList();
			string page = " ";
			return Json(new { data = query,page=page });
		}
		[HttpPost]
		public JsonResult InsertOrUpdate(int id, string url)
		{

			string mess = "";
			Video item = new Video();
			if (id != 0)
			{
				item = videoDAO.getItem(id);
				 mess = "Chỉnh sửa video thành công";
			}

			item.Url = url;
			

			videoDAO.InsertOrUpdate(item);
			return Json(new { mess = mess });
		}
		[HttpGet]
		public JsonResult getVideo(int id)
		{			
			var query = videoDAO.getItemView(id);
			return Json(new { data = query });
		}
	}
}
