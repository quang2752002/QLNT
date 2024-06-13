using GUIs.Areas.Admin.Controllers;
using GUIs.Helper;
using Microsoft.AspNetCore.Mvc;
using QLNT.Helper;
using QLNT.Models.DAO;
using QLNT.Models.EF;

namespace QLNT.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class LietSyController : Controller
	{
		lietSyDAO lietSyDAO = new lietSyDAO();
		nghiaTrangDAO nghiaTrangDAO=new nghiaTrangDAO();
		diaChiDAO diaChiDAO= new diaChiDAO();
		private const string XA = "XA";
		private const string HUYEN = "HUYEN";
		private const string TINH = "TINH";
		public IActionResult Index()
		{
			ViewBag.Pagesize = DataServices.Pagesize();
			ViewBag.listNghiaTrang = nghiaTrangDAO.getList();
			ViewBag.Tinh = diaChiDAO.getList();
			return View();
		}
		[HttpGet]
		public JsonResult GetHuyen(int tinhId)
		{
			var listHuyen = diaChiDAO.getListChild(tinhId);
			int huyen=HttpContext.Session.GetInt32(HUYEN)??0;

			return Json(new {data=listHuyen,huyen=huyen});
		}

		[HttpGet]
		public JsonResult GetXa(int huyenId)
		{
			var listXa = diaChiDAO.getListChild(huyenId);
            int xa = HttpContext.Session.GetInt32(XA) ?? 0;
            return Json(new { data = listXa, xa = xa });
        }
		public IActionResult ShowList(string name, int index, int size, string trangthai)
		{
			int total = 0;
			var query = lietSyDAO.ShowList(out total, name, index, size, trangthai);
			string page = Support.InTrang(total, index, size);
			return Json(new { data = query, page = page });
		}
		[HttpPost]
		public IActionResult InsertOrUpdate(int id, string ten, int iddiachi, int idnghiatrang,
			string sdt, DateTime ngaysinh, DateTime ngaymat, string donvi, string capbac, int vitrihang,
			int vitricot, string tinhtrang, string mota)
		{
			string mess = "Thêm mới liệt sỹ thành công";
			LietSy item = new LietSy();
			if (id != 0)
			{
				item=lietSyDAO.getItem(id);
				mess = "Chỉnh sửa liệt sỹ thành công";
			}
			item.HoTen= ten;
			item.Sdt = sdt;
			if (iddiachi != 0)
			{
				item.DiaChiId = iddiachi;
			}
			
			item.NghiaTrangId = idnghiatrang;
		
			
			if(ngaysinh!=new  DateTime(0001, 1, 1))
			{
				item.NgaySinh = ngaysinh;
			}
			if (ngaymat != new DateTime(0001, 1, 1))
			{
				item.NgayMat = ngaymat;
			}
			item.DonVi = donvi;
			item.CapBac = capbac;
			item.ViTriCot=vitricot;
			item.ViTriHang = vitrihang;
			item.MoTa = mota;
			item.TinhTrang = tinhtrang;
			item.TrangThai = "active";
			lietSyDAO.InsertOrUpdate(item);
			return Json(new { mess = mess });
		}
		[HttpDelete]
		public JsonResult Delete(int id)
		{
			var item = lietSyDAO.getItem(id);
			item.TrangThai = "inactive";
			lietSyDAO.InsertOrUpdate(item);
			return Json(new { mess = "Xóa liệt sỹ thành công" });
		}
		[HttpGet]
		public JsonResult getLietSy(int id)
		{
			var query = lietSyDAO.getItemView(id);
			int tinh=0;
			if (query.DiaChiId !=0 )
			{
				int xa = query.DiaChiId;
				var diachi = diaChiDAO.getItemView(xa);
				int huyen = diachi.ParentId.Value;
				var diachiS = diaChiDAO.getItemView(huyen);
				tinh = diachiS.ParentId.Value;
				HttpContext.Session.SetInt32(XA, xa);
				HttpContext.Session.SetInt32(HUYEN, huyen);
				HttpContext.Session.SetInt32(TINH, tinh);
			}
            return Json(new {data=query ,tinh=tinh});
		}
	}
}
