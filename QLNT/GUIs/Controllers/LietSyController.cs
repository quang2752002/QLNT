using GUIs.Models.DAO;
using GUIs.Models.EF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GUIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LietSyController : ControllerBase
    {
        LietSyDAO lietsyDAO = new LietSyDAO();
        [Route("ShowListLietSy")]
        [HttpGet]
        public async Task<IActionResult> ShowListLietSy()
        {
            try
            {
                var query = lietsyDAO.ShowList();
                return Ok(query);

            }
            catch
            {
                return BadRequest();
            }
        }
        [Route("Create")]
        [HttpPost]
      
        public async Task<IActionResult> Create(int DiaChiId, string HoTen, string Sdt, DateTime NgaySinh, DateTime NgayMat, string DonVi, string CapBac, int ViTriHang, int ViTriCot, string MoTa, string TinhTrang)
        {
            try
            {
                LietSy item = new LietSy();

                item.DiaChiId = DiaChiId;
                item.HoTen = HoTen;
                item.Sdt = Sdt;
                item.NgaySinh = NgaySinh;
                item.NgayMat = NgayMat;
                item.DonVi = DonVi;
                item.CapBac = CapBac;
                item.ViTriHang = ViTriHang;
                item.ViTriCot = ViTriCot;
                item.MoTa = MoTa;
                item.TinhTrang = TinhTrang;
                item.TrangThai = "active";

                lietsyDAO.InsertOrUpdate(item);
                return StatusCode(StatusCodes.Status200OK, "Success");
            }
            catch
            {
                return BadRequest();
            }
        }

        [Route("Update")]
        [HttpPost]
       
        public async Task<IActionResult> Update(int LietSyId,int DiaChiId, string HoTen, string Sdt, DateTime NgaySinh, DateTime NgayMat, string DonVi, string CapBac, int ViTriHang, int ViTriCot, string MoTa, string TinhTrang)
        {
            try
            {
                var item = lietsyDAO.getItem(LietSyId);

                item.DiaChiId = DiaChiId;
                item.HoTen = HoTen;
                item.Sdt = Sdt;
                item.NgaySinh = NgaySinh;
                item.NgayMat = NgayMat;
                item.DonVi = DonVi;
                item.CapBac = CapBac;
                item.ViTriHang = ViTriHang;
                item.ViTriCot = ViTriCot;
                item.MoTa = MoTa;
                item.TinhTrang = TinhTrang;
                lietsyDAO.InsertOrUpdate(item);
                return StatusCode(StatusCodes.Status200OK, "Success");
            }
            catch
            {
                return BadRequest();
            }

        }

        [Route("Delete/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var item = lietsyDAO.getItem(id);
                item.TrangThai = "inactive";
                lietsyDAO.InsertOrUpdate(item);
                return StatusCode(StatusCodes.Status200OK, "Success");
            }
            catch
            {
                return BadRequest();
            }

        }
        [Route("Search")]
        [HttpGet]
        public async Task<IActionResult> Search(string name, int namSinh, int namHySinh, int thanhpho, int quan, int phuong, int nghiaTrangThanhpho, int nghiaTrangQuan, int nghiaTrangPhuong, int nghiaTrangId)
        {
            
                var query = lietsyDAO.Search(name, namSinh, namHySinh, thanhpho, quan, phuong, nghiaTrangThanhpho, nghiaTrangQuan, nghiaTrangPhuong, nghiaTrangId);
                return Ok(query);
            
           
        }

    }
}
