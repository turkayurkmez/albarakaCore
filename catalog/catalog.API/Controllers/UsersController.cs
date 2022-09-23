using catalog.Business.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService userService;

        public UsersController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public IActionResult Login(UserLoginModel userLoginModel)
        {
            if (ModelState.IsValid)
            {
                var user = userService.ValidateUser(userLoginModel.UserName, userLoginModel.Password);
                if (user != null)
                {
                    //demek ki kayıtlı bir kullanıcı o zaman kimliği token ile döndür:
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Name,user.EmailAddress),
                        new Claim(ClaimTypes.Role, user.Role)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("cok gizli ve onemli bir cumle"));
                    var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        issuer: "albaraka.com",
                        audience: "albaraka.com",
                        claims: claims,
                        notBefore: DateTime.Now,
                        expires: DateTime.Now.AddHours(1),
                        signingCredentials: credential
                        );

                    return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });

                }

                return BadRequest(new { message = "Kullanıcı adı ya da şifre yanlış" });
            }
            return BadRequest(ModelState);


        }
    }
}
