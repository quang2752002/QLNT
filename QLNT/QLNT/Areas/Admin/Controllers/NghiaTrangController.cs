using GUIs.Helper;
using Microsoft.AspNetCore.Mvc;
using QLNT.Helper;
using QLNT.Models.DAO;
using QLNT.Models.EF;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace QLNT.Areas.Admin.Controllers
{
	[Area("Admin")]
    public class NghiaTrangController : Controller
    {
        private const string DIACHIID = "DIACHIID";
        private const string XA = "XA";
        private const string HUYEN = "HUYEN";
        private const string TINH = "TINH";
        diaChiDAO diaChiDAO = new diaChiDAO();
        nghiaTrangDAO nghiaTrangDAO = new nghiaTrangDAO();
        lietSyDAO LietSyDAO=new lietSyDAO();
        
        public IActionResult Index()
        {
            ViewBag.Pagesize = DataServices.Pagesize();
            ViewBag.Tinh = diaChiDAO.getList();
            return View();
        }

        public IActionResult ShowList(string name, int index, int size, string trangthai)
        {
            int total = 0;
            var query = nghiaTrangDAO.ShowList(out total, name, index, size, trangthai);
            string page = Support.InTrang(total, index, size);
            return Json(new { data = query, page = page });
        }
        [HttpGet]
        public JsonResult GetTinh()
        {
            var listTinh = diaChiDAO.getList();
            int tinh = HttpContext.Session.GetInt32(TINH) ?? 0;

            return Json(new { data = listTinh, tinh = tinh });
        }

        [HttpGet]
        public JsonResult GetHuyen(int id)
        {
            var listHuyen = diaChiDAO.getListChild(id);
            int huyen = HttpContext.Session.GetInt32(HUYEN) ?? 0;

            return Json(new { data = listHuyen, huyen = huyen });
        }

        [HttpGet]
        public JsonResult GetXa(int id)
        {
            var listXa = diaChiDAO.getListChild(id);
            int xa = HttpContext.Session.GetInt32(XA) ?? 0;
            return Json(new { data = listXa, xa = xa });
        }
        [HttpPost]
        public IActionResult InsertOrUpdate(int id,string  ten,string sdt,string email,double dientich,int diachiId,string mota)        
        {
            string mess = "Thêm mới nghĩa trang thành công";
            NghiaTrang item = new NghiaTrang();
            if (id != 0)
            {
                item = nghiaTrangDAO.getItem(id);
                mess = "Chỉnh sửa nghĩa trang thành công";
            }
            item.Ten = ten;
            item.Sdt = sdt;
            item.Email=email;
            item.Email = email;
            item.DienTich = dientich;
            item.DiaChiId = diachiId;
            item.MoTa = mota;
            item.TrangThai = "active";
            nghiaTrangDAO.InsertOrUpdate(item);
            return Json(new { mess = mess });
        }
        [HttpGet]
        public IActionResult getNghiaTrang(int id)
        {
            var item = nghiaTrangDAO.getItemView(id);
            int xa = item.DiaChiId;
            var diachi = diaChiDAO.getItemView(xa);
            int huyen = diachi.ParentId.Value;
            var diachiS = diaChiDAO.getItemView(huyen);
            int tinh = diachiS.ParentId.Value;
            HttpContext.Session.SetInt32(XA, xa);
            HttpContext.Session.SetInt32(HUYEN, huyen);
            HttpContext.Session.SetInt32(TINH, tinh);

            return Json(new { data =item,tinh=tinh});
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var item = nghiaTrangDAO.getItem(id);
            item.TrangThai = "inactive";
            nghiaTrangDAO.InsertOrUpdate(item);
            return Json(new { mess = "Xóa Thành Công" });
        }
        public IActionResult DanhSach(int id)
        {
            ViewBag.Pagesize = DataServices.Pagesize();
            HttpContext.Session.SetInt32(DIACHIID, id);
            return View();
        }
        [HttpPost]
        public JsonResult ListLietSy(string name ,int index , int size, string trangthai )
        {
            int id = HttpContext.Session.GetInt32(DIACHIID) ?? 0;
            var nghiaTrang = nghiaTrangDAO.getItemView(id);
            string tenNghiaTrang = nghiaTrang.Ten;
            int total = 0;
            var query = LietSyDAO.getList( out total,id, name, index, size, trangthai);
            string page = Support.InTrang(total, index, size);
            return Json(new { data = query, page = page ,tenNghiaTrang=tenNghiaTrang});
        }
    }

}
