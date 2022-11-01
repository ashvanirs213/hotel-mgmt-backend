using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OnlineHotelManagementAPI.Models;
using OnlineHotelManagementAPI.Service;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace OnlineHotelManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public static Admin admin = new Admin();
        private readonly IConfiguration _configuration;
        private AdminService _adminService;
        private HotelContext _hotelContext;

        public TokenController(IConfiguration configuration, AdminService adminservice,
            HotelContext hotelContext)
        {
            _configuration = configuration;
            _adminService = adminservice;
            _hotelContext = hotelContext;
        }

        #region Register
        [HttpPost("Register")]
        public async Task<ActionResult<Admin>> Register(Login request)
        {
            

            admin.Username = request.Username;
            admin.Password = request.Password;
            
            admin.Role = request.Role;
            

            return Ok(_adminService.AddAdmin(admin));
        }
        #endregion

        #region Login
        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(Login request)
        {
            Admin? admin1 = _hotelContext.Admins.Find(request.Username);
            if (admin1 == null)
            {
                return Ok("User Not found");
            }
            else
            {
                if (admin1.Password != request.Password)
                {
                    return Ok("Wrong Password");
                }

                //admin1 = _hotelContext.Admins.Find(request.Role);
                if (admin1.Role != request.Role)
                {
                    return Ok("Role Forbidden");
                }

                string token = CreateToken(admin1);

                //return Ok(new { token, admin1 });
                return Ok(token);
            }
            //var refreshToken = GenerateRefreshToken();
            //SetRefreshToken(refreshToken);
        }

        #endregion

        #region Creating Token
        private string CreateToken(Admin admin)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, admin.Username),
                new Claim(ClaimTypes.Role, admin.Role)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
        #endregion








    }
}
