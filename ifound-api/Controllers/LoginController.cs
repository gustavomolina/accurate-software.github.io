using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ifound_api.Backoffice.Domain.Business;
using ifound_api.Backoffice.Domain.Entity;
using Core.AspNetIdentity;
using Core.Business;
using Core.Exception;
using Core.IOC;
using Core.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ifound_api.Backoffice.Domain.ViewModel;

namespace ifound_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        //private readonly IConfiguration _config;

        //public LoginController(IConfiguration config)
        //{
        //    _config = config;
        //}
        //public async Task<IActionResult> Login(Login loginDTO)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var userData = new UserLoginViewModel
        //        {
        //            UserName = loginDTO.UserName,
        //            Password = loginDTO.Password
        //        };
        //        IAuthBusiness authBusiness = DependencyResolution.Instance.GetInstance<IAuthBusiness>();

        //        if (authBusiness.ValidaUsuario(userData.UserName, userData.Password))
        //        {
                    
        //                    //keys
        //                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
        //                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        //                    //token description
        //                    ClaimsIdentity claimsIdentity = UserHelper<AuthServerIdentity>.Instance.CreateIdentity(userData.UserName, "jwt");
        //                    DateTime issuedAt = DateTime.UtcNow;
        //                    DateTime expires = DateTime.UtcNow.AddHours(Convert.ToDouble(_config["HoursToExpireToken"]));
        //                    var tokenDescriptor = new SecurityTokenDescriptor
        //                    {
        //                        Subject = claimsIdentity,
        //                        Expires = expires,
        //                        SigningCredentials = creds,
        //                        NotBefore = issuedAt
        //                    };

        //                    //create token
        //                    var tokenHandler = new JwtSecurityTokenHandler();
        //                    var token = tokenHandler.CreateToken(tokenDescriptor);

        //                    return Ok(new
        //                    {
        //                        access_token = tokenHandler.WriteToken(token)
        //                    });
                        
        //        }
        //        else
        //            return Unauthorized();
        //    }
        //    else
        //        throw new ApiValidationException(ModelState);
        //}

    }
}
