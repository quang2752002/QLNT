using GUIs.Helper;
using Microsoft.AspNetCore.Mvc;
using QLNT.Helper;
using QLNT.Models.DAO;

namespace QLNT.Controllers
{
    public class Login : Controller
    {
		adminDAO adminDAO=new adminDAO();
		public IActionResult Index()
		{

			return View();
		}
		public JsonResult DangNhap(string username, string password)
		{

			string matkhau = lopMd5.Encrypt(password,true);
			int x = adminDAO.Login(username, matkhau);
			string router = "";
			string mess = "Đăng nhập không thành công";
			bool status = false;
			if (x != -1)
			{
				HttpContext.Session.SetInt32(CustomeCommon.USER_ID, x);
				status = true;
				router = "Admin";
				HttpContext.Session.SetString(CustomeCommon.ROUTER, router);
			}
			
			return Json(new { mess = mess, status = status, router = router });
		}
		
	

	}
}
