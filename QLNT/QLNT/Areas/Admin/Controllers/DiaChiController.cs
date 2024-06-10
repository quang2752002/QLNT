using GUIs.Areas.Admin.Controllers;
using GUIs.Helper;
using Microsoft.AspNetCore.Mvc;
using QLNT.Helper;
using QLNT.Models.DAO;
using QLNT.Models.EF;

namespace QLNT.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DiaChiController : Controller
    {
		private const string THANHPHO = "THANHPHO";
		private const string QUAN = "QUAN";
		diaChiDAO diaChiDAO = new diaChiDAO();
        public IActionResult Index()
        {
            ViewBag.Pagesize = DataServices.Pagesize();
            ViewBag.Year = DataServices.Year();
            ViewBag.Month = DataServices.Months();
            return View();
        }
        public IActionResult ShowList(string name, int index, int size, string trangthai)
        {
            int total = 0;
            var query = diaChiDAO.ShowList(out total, name, index, size, trangthai);
            string page = Support.InTrang(total, index, size);
            return Json(new { data = query, page = page });
        }
        [HttpPost]
        public JsonResult InsertOrUpdate(int id, string name)
        {

            string mess = "Thêm mới địa chỉ thành công";
            DiaChi item = new DiaChi();
            if (id != 0)
            {
                item = diaChiDAO.getItem(id);
                mess = "Chỉnh sửa địa chỉ thành công";
            }

            item.Ten = name;
            item.TrangThai = "active";

            diaChiDAO.InsertOrUpdate(item);
            return Json(new { mess = mess });
        }
		[HttpPost]
		public JsonResult InsertChild(string name)
        {
            string mess = "Thêm mới địa chỉ thành công";
            DiaChi item = new DiaChi();

			int id = HttpContext.Session.GetInt32(THANHPHO) ?? 0;

			item.Ten = name;
            item.TrangThai = "active";
            item.ParentId = id;
            diaChiDAO.InsertOrUpdate(item);
            return Json(new { mess = mess });
        }

		[HttpPost]
		public JsonResult UpdateChild(int id, string name)
        {
            var item = diaChiDAO.getItem(id);
            string mess = "Chỉnh sửa địa chỉ thành công";
            item.Ten = name;                    
            diaChiDAO.InsertOrUpdate(item);
            return Json(new { mess = mess });
        }
        [HttpGet]
        public IActionResult getDiaChi(int id)
        {
            var query=diaChiDAO.getItemView(id);
            return Json(new { data=query });
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var query = diaChiDAO.getItem(id);
            query.TrangThai = "inactive";
            diaChiDAO.InsertOrUpdate(query);
            return Json(new { mess = "Xóa Thành công" });
        }
		public IActionResult Quan(int id)
		{
			ViewBag.Pagesize = DataServices.Pagesize();
			ViewBag.Year = DataServices.Year();
			ViewBag.Month = DataServices.Months();
			HttpContext.Session.SetInt32(THANHPHO, id);
			return View();
		}
		public IActionResult ShowListQuan(string name, int index, int size, string trangthai)
		{
			int id = HttpContext.Session.GetInt32(THANHPHO) ?? 0;
			int total = 0;
			var query = diaChiDAO.getDiaChiChild(out total,id, name, index, size, trangthai);
			string page = Support.InTrang(total, index, size);
			return Json(new { data = query, page = page });
		}
		public IActionResult Phuong(int id)
		{
			ViewBag.Pagesize = DataServices.Pagesize();
			ViewBag.Year = DataServices.Year();
			ViewBag.Month = DataServices.Months();
			HttpContext.Session.SetInt32(QUAN, id);
			return View();
		}
		public IActionResult ShowListPhuong(string name, int index, int size, string trangthai)
		{
			int total = 0;
			int id = HttpContext.Session.GetInt32(QUAN) ?? 0;
			var query = diaChiDAO.getDiaChiChild(out total,id, name, index, size, trangthai);
			string page = Support.InTrang(total, index, size);
			return Json(new { data = query, page = page });
		}
        [HttpPost]
		public JsonResult InsertPhuong(string name)
		{
			string mess = "Thêm mới địa chỉ thành công";
			DiaChi item = new DiaChi();

			int id = HttpContext.Session.GetInt32(QUAN) ?? 0;

			item.Ten = name;
			item.TrangThai = "active";
			item.ParentId = id;
			diaChiDAO.InsertOrUpdate(item);
			return Json(new { mess = mess });
		}
	}
}
