using GUIs.Helper;
using GUIs.Models.DAO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GUIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        QuanLyDAO quanLyDAO=new QuanLyDAO();
        Token token = new Token();
        [HttpPost("Login")]
        public IActionResult Login(string username,string password)
        {
            int id= quanLyDAO.Login(username,password);
            if(id==-1)
            {
                return Ok(new
                {
                    Success=false,
                    Mess="Invalid"
                });
            }
            return Ok(new
            {
                Success = true,
                Mess = "Auth",
                Data =token.GenerateToken(username,password)
            });
        }
      
    }
}
