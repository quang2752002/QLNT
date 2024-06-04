using GUIs.Models.DAO;
using GUIs.Models.EF;
using GUIs.Models.VIEW;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace GUIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiaChiController : ControllerBase
    {
        DiaChiDAO diachiDAO = new DiaChiDAO();
        [Route("ShowListDiaChi")]
        [HttpGet]
        public async Task<IActionResult> ShowListDiaChi()
        {
            try
            {
                var query = diachiDAO.ShowList();
                return Ok(query);

            }
            catch
            {
                return BadRequest();
            }
        }
        [Route("Create")]
        [HttpPost]
      
        public async Task<IActionResult> Create(DiaChi item)
        {
            try
            {              
                item.TrangThai = "active";     
                diachiDAO.InsertOrUpdate(item);
                return StatusCode(StatusCodes.Status200OK, "Success");
            }
            catch
            {
                return BadRequest();
            }

        }
        [Route("Update")]
        [HttpPost]
        public async Task<IActionResult> Update(DiaChiVIEW diachi)
        {
                DiaChi item = diachiDAO.getItem(diachi.DiaChiId);
                
                item.Ten = diachi.Ten;
                item.ParentId = diachi.ParentId == 0 ? (int?)null : diachi.ParentId;

            item.TrangThai = "active";
                diachiDAO.InsertOrUpdate(item);
                return StatusCode(StatusCodes.Status200OK, "Success");
        }
        [Route("UpdateChild")]
        [HttpPost]
        public async Task<IActionResult> UpdateChild(DiaChiVIEW diachi)
        {
            DiaChi item = diachiDAO.getItem(diachi.DiaChiId);

            item.Ten = diachi.Ten;
       

            item.TrangThai = "active";
            diachiDAO.InsertOrUpdate(item);
            return StatusCode(StatusCodes.Status200OK, "Success");
        }
        [Route("Delete/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var item = diachiDAO.getItem(id);
                item.TrangThai = "inactive";
                diachiDAO.InsertOrUpdate(item);
                return StatusCode(StatusCodes.Status200OK, "Success");
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpGet("getDiaChi/{id}")]
        public IActionResult getDiaChi(int id)
        {
            try
            {
                var query = diachiDAO.getItemView(id);

                return Ok(query);
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpGet("getDiaChiChild/{id}")]
        public IActionResult getDiaChiChild(int id)
        {
            try
            {
                var query = diachiDAO.getDiaChiChild(id);

                return Ok(query);
            }
            catch
            {
                return BadRequest();
            }

        }
    }
}
