using Ecommerce.BL;
using Ecommerce.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly UserManager<User> userManager;

        public UserController(IConfiguration configuration ,UserManager<User> userManager)
        {
            this.configuration = configuration;
            this.userManager = userManager;
        }

        [HttpPost]
        [Route("RegiterAdmin")]
        [Authorize(Policy = "AdminsOnly")]
        public async Task<ActionResult> RegiterAdmin(RegisterDto registerDto)
        {
            #region Create a new user
            var user = new User
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,

            };
            var password = await userManager.CreateAsync(user, registerDto.Password);


            if (!password.Succeeded)   // if the creation of password is not success
            {
                return BadRequest(error: password.Errors);
            }
            #endregion

            #region Create Claims

            var claimlist = new List<Claim>
            {
                 new Claim(ClaimTypes.NameIdentifier ,user.Id),    //as student inhiert from IdentityUser
                new Claim(ClaimTypes.Name , user.UserName),
                new Claim(ClaimTypes.Role , "Admin"),
                new Claim(ClaimTypes.Email , user.Email),
            };

            await userManager.AddClaimsAsync(user, claims: claimlist);
            #endregion


            return Ok();
        }



        [HttpPost]
        [Route("RegiterUser")]
        public async Task<ActionResult> RegiterUser(RegisterDto registerDto)
        {
            #region Create a new user
            var user = new User
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,

            };
            var password = await userManager.CreateAsync(user, registerDto.Password);


            if (!password.Succeeded)   // if the creation of password is not success
            {
                return BadRequest(error: password.Errors);
            }
            #endregion

            #region Create Claims

            var claimlist = new List<Claim>
            {
                 new Claim(ClaimTypes.NameIdentifier ,user.Id),    //as student inhiert from IdentityUser
                new Claim(ClaimTypes.Name , user.UserName),
                new Claim(ClaimTypes.Role , "User"),
                new Claim(ClaimTypes.Email , user.Email),
            };

            await userManager.AddClaimsAsync(user, claims: claimlist);
            #endregion

            return Ok();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<TokenDto>> login(loginDto Credential)
        {
            var user = await userManager.FindByNameAsync(Credential.UserName);
          
            if (user == null)
            {
                return Unauthorized();
            }

            var password = await userManager.CheckPasswordAsync(user, Credential.Password);
            if (!password)
            {
                return Unauthorized();
            }


            var claimlist = await userManager.GetClaimsAsync(user);


            #region gettingSecretKEy
            var secretKeyString = configuration.GetValue<string>("SecretKey");
            var secretKeyInBytes = Encoding.ASCII.GetBytes(secretKeyString ?? "");
            SymmetricSecurityKey? secretKey = new SymmetricSecurityKey(secretKeyInBytes);
            #endregion

            #region SigningCredential
            var SigningCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            #endregion

            #region generate token
            var expireDate = DateTime.Now.AddDays(1);
            var token = new JwtSecurityToken(claims: claimlist,
                signingCredentials: SigningCredentials,
                expires: expireDate);
            #endregion

            #region convert Tokent to string
            var TokenHandler = new JwtSecurityTokenHandler();
            var TokenString = TokenHandler.WriteToken(token: token);
            #endregion

            return new TokenDto(TokenString, expireDate);


        }




    }
}
