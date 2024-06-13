using GUIs.Helper;
using Microsoft.AspNetCore.Mvc;
using QLNT.Helper;
using QLNT.Models.DAO;
using QLNT.Models.EF;

namespace QLNT.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class TinTucController : Controller
	{
		tinTucDAO tinTucDAO = new tinTucDAO();
		private const string IDTINTUC = "IDTINTUC";
		public IActionResult Index()
		{
			ViewBag.Pagesize = DataServices.Pagesize();
			return View();
		}
		public IActionResult ShowList(string name, int index, int size, string trangthai)
		{
			int total = 0;
			var query = tinTucDAO.ShowList(out total, name, index, size, trangthai);
			string page = Support.InTrang(total, index, size);
			return Json(new { data = query, page = page });
		}
		[HttpDelete]
		public JsonResult Delete(int id)
		{
			var query = tinTucDAO.getItem(id);
			query.TrangThai = "inactive";
			tinTucDAO.InsertOrUpdate(query);
			return Json(new { mess = "Xóa Thành công" });
		}
		[HttpPost]
		public JsonResult Active(int id)
		{
			var query = tinTucDAO.getItem(id);
			query.TrangThai = "active";
			tinTucDAO.InsertOrUpdate(query);
			return Json(new { mess = "Đăng bài thành công" });
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public JsonResult InsertOrUpdate(int id, string anh, string tieude, string noidung)
		{
			string mess = "Thêm mới tin tức thành công";
			TinTuc item = new TinTuc();

			if (id != 0)
			{
				item = tinTucDAO.getItem(id);
				mess = "Chỉnh sửa tin tức thành công";
			}
			else
			{
				item.TrangThai = "inactive";
			}
			item.Anh = anh;
			item.Tieude = tieude;
			item.Noidung = noidung;


			tinTucDAO.InsertOrUpdate(item);
			return Json(new { mess = mess });
		}
		public IActionResult Edit(int id)
		{
			HttpContext.Session.SetInt32(IDTINTUC, id);
			return View();
		}
		[HttpGet]
		public IActionResult getTinTuc()
		{
			int id = HttpContext.Session.GetInt32(IDTINTUC).Value;
			var query = tinTucDAO.getItemView(id);
			return Json(new { data = query });
		}


	}
}
