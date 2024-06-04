using GUIs.Models.DAO;
using GUIs.Models.EF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using GUIs.Models.VIEW;
namespace GUIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NghiaTrangController : ControllerBase
    {

        NghiaTrangDAO nghiaTrangDAO = new NghiaTrangDAO();
        private readonly ILogger<NghiaTrangController> _logger;
        [Route("ShowListNghiaTrang")]
        [HttpGet]
        public async Task<IActionResult> ShowListNghiaTrang()
        {
            try
            {
                var query = nghiaTrangDAO.ShowList();
                return Ok(query);

            }
            catch
            {
                return BadRequest();
            }
        }
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create(NghiaTrang nghiaTrang)
        {



            //NghiaTrang item = new NghiaTrang
            //{
            //    DiaChiId = diaChiId,
            //    Ten = ten,
            //    Sdt = sdt,
            //    Email = email,
            //    Soluong = soluong,
            //    DienTich = dientich,
            //    MoTa = mota
            //};
            nghiaTrang.TrangThai = "active";
            nghiaTrangDAO.InsertOrUpdate(nghiaTrang);
            return StatusCode(StatusCodes.Status200OK, "Success");

        }
        [HttpGet("getNghiaTrang/{id}")]
        public async Task<IActionResult> GetNghiaTrang(int id)
        {
            try
            {
                // Assuming GetItemViewAsync is the correct method name and it is async.
                var query = nghiaTrangDAO.getItemView(id);
                return Ok(query);
            }
            catch (Exception ex)
            {
                // You can also log the exception here for debugging purposes.
                return StatusCode(500, "Internal server error");
            }
        }

        [Route("Update")]
        [HttpPost]
        public async Task<IActionResult> Update(NghiaTrangVIEW item)
        {
            
                NghiaTrang nghia = nghiaTrangDAO.getItem(item.NghiaTrangId);
                nghia.DiaChiId = item.DiaChiId;
                nghia.Ten = item.Ten;
                nghia.Sdt = item.Sdt;
                nghia.Email = item.Email;
                nghia.Soluong = item.Soluong;
                nghia.DienTich = item.DienTich;
                nghia.MoTa = item.MoTa;
                nghia.TrangThai = "active";
                nghiaTrangDAO.InsertOrUpdate(nghia);
                return StatusCode(StatusCodes.Status200OK, "Success");
            
           

        }

        [Route("Delete/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var item = nghiaTrangDAO.getItem(id);
                item.TrangThai = "inactive";
                nghiaTrangDAO.InsertOrUpdate(item);
                return StatusCode(StatusCodes.Status200OK, "Success");
            }
            catch
            {
                return BadRequest();
            }

        }




        //[Route("Upload")]
        //[HttpPost]

        //public IActionResult Upload()
        //{
        //    try
        //    {
        //        var httpRequest = Request.Form;
        //        var postFile = httpRequest.Files[0];
        //        string filename = postFile.Name;
        //        var physicalPath = webHostEnvironment.ContentRootPath + "/Photos" + filename;

        //        using (var stream = new FileStream(physicalPath, FileMode.Create))
        //        {
        //            postFile.CopyTo(stream);
        //        }
        //        return StatusCode(StatusCodes.Status200OK, "Success");

        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest();
        //    }
        //}
    }
}