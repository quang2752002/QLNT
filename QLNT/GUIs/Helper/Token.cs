using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GUIs.Helper
{
    public class Token
    {
        public string GenerateToken(string username,string password)
        {
            var jwt=new  JwtSecurityTokenHandler();
            var key =  Encoding.UTF8.GetBytes("YourSecretKeyNeedsToBeLongEnoughForHmacSha256");
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim("username", username),
                    new Claim("password", password),
                    new Claim("TokenId", Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(4),
                SigningCredentials=new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256)
            };
            var token=jwt.CreateToken(tokenDescription);
            return jwt.WriteToken(token);
        }
    }
}
