using Microsoft.AspNetCore.Mvc;
using QLNT.Helper;
using QLNT.Models.DAO;
using QLNT.Models.EF;
using System.Drawing;
using System.Security.Policy;

namespace QLNT.Controllers
{
    public class TimKiemController : Controller
    {
        nghiaTrangDAO nghiaTrangDAO=new nghiaTrangDAO();
        lietSyDAO lietSyDAO=new lietSyDAO();    
        public IActionResult Index()
        {
            return View();
        }
       
        public JsonResult getListNghiaTrang(int id)
        {
			
			var query=nghiaTrangDAO.getNghiaTrangByIdXa(id);
            
			;
			return Json(new { data = query});
        }
		[HttpPost]
		public JsonResult ShowList(string name, int namsinh, int nammat, int tinhDropdown, int huyenDropdown, int xaDropdown, int thanhpho, int huyen, int xa, int idnghiatrang, int index = 1)
		{
			// Initialize variables
			var query = Enumerable.Empty<object>();
			string page = "";
			int total = 0;

			try
			{
				if (!string.IsNullOrEmpty(name))
				{
					// Perform search operation
					query = lietSyDAO.Search(out total, name, namsinh, nammat, tinhDropdown, huyenDropdown, xaDropdown, thanhpho, huyen, xa, idnghiatrang, index);
					// Generate pagination
					page = Support.InTrang(total, index, 10);
				}
			}
			catch (Exception ex)
			{
				// Handle exception (logging, rethrowing, or return an error message)
				return Json(new { success = false, message = ex.Message });
			}

			// Return the result as JSON
			return Json(new { data = query, page = page });
		}

	}
}
