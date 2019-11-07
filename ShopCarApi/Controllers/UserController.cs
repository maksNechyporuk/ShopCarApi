using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShopCarApi.Entities;
using ShopCarApi.ViewModels;
using WebElectra.Entities;

namespace ShopCarApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly EFDbContext _context;
        private readonly UserManager<DbUser> _userManager;
        private readonly SignInManager<DbUser> _signInManager;
        private readonly RoleManager<DbRole> _roleManager;

        public UserController(EFDbContext context,
          UserManager<DbUser> userManager,
          SignInManager<DbUser> signInManager, RoleManager<DbRole> roleManager)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult UserList(string Name)
        {
            if (Name == null)
            {
                var user = _context.Users.Select(
                    p => new UserVM
                    {
                        Name = p.UserName,
                        Email = p.Email
                        
                    }).ToList();
                return Ok(user);
            }
            else
            {
                var query = _context.Users.AsQueryable();
                var queryResult = (from user in query
                                   where user.UserName.Contains(Name)
                                   select new UserVM { Name = user.UserName, Email = user.Email }).ToList();
                //var makes = query
                //    .Where(m => m.Name.Contains(Name))
                //    .Select(
                //    p => new MakeVM
                //    {
                //        Id = p.Id,
                //        Name = p.Name
                //    }).ToList();
                return Ok(queryResult);
            }
        }

        public IActionResult Delete([FromBody] UserDeleteVM duser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var user = _context.Users.SingleOrDefault(p => p.Id == duser.Id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            return Ok();
        }

        public IActionResult Update([FromBody] UserUpdateVM user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var prod = _context.Users.SingleOrDefault(p => p.Id == user.Id);
            if (prod != null)
            {
                prod.UserName = user.Name;
                prod.Email = user.Email;
                _context.SaveChanges();
            }
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]UserLoginVM model)
        {
            if (!ModelState.IsValid)
            {
                var errors = CustomValidator.GetErrorsByModel(ModelState);
                return BadRequest(errors);
            }
            var result = await _signInManager
                .PasswordSignInAsync(model.Name, model.Password,
                false, false);

            if (!result.Succeeded)
            {
                return BadRequest(new { Password = "Не правильно введені дані!" });
            }

            var user = await _userManager.FindByNameAsync(model.Name);
            await _signInManager.SignInAsync(user, isPersistent: false);

            return Ok(
            new
            {
                token = CreateTokenJwt(user)
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserRegisterVM model)
        {
            if (!ModelState.IsValid)
            {
                var errors = CustomValidator.GetErrorsByModel(ModelState);
                return BadRequest(errors);
            }
            string roleName = "Employee";
            var role = _roleManager.FindByNameAsync(roleName).Result;
            var userEmail = model.Email;
            //var user = _userManager.FindByEmailAsync(userEmail).Result;
            if (_userManager.FindByEmailAsync(userEmail).Result != null)
            {
                return BadRequest(new { invalid = "Email is exist!" });
            }
            var user = new DbUser
            { 
                Email = userEmail,
                UserName = model.Name
            };
            var result = _userManager.CreateAsync(user, model.Password).Result;
            if (result.Succeeded)
            {
                result = _userManager.AddToRoleAsync(user, roleName).Result;
            }

            return Ok(
            new
            {
                token = CreateTokenJwt(user)
            });
        }

      
        private string CreateTokenJwt(DbUser user)
        {
            var roles = _userManager.GetRolesAsync(user).Result;
            var claims = new List<Claim>()
            {
                //new Claim(JwtRegisteredClaimNames.Sub, user.Id)
                new Claim("id", user.Id.ToString()),
                new Claim("name", user.UserName)
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim("roles", role));
            }

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("11-sdfasdf-22233222222"));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            var jwt = new JwtSecurityToken(
                signingCredentials: signingCredentials,
                claims: claims,
                expires: DateTime.Now.AddHours(1));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

    }
}