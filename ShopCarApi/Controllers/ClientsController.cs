using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ShopCarApi.Entities;
using ShopCarApi.ViewModels;
using WebElectra.Entities;

namespace ShopCarApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly EFDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _env;



        public ClientsController(IHostingEnvironment env,
            IConfiguration configuration,
            EFDbContext context)
        {
            _configuration = configuration;
            _env = env;
            _context = context;
        }

        [HttpGet]
        public IActionResult ClientList()
        {
            var client = _context.Clients.Select(
                p => new ClientVM
                {
                    Id = p.Id,
                    Name = p.Name,
                    Phone = p.Phone,
                    Image = p.Image,
                    Email = p.Email                 
                }).ToList();
            return Ok(client);
        }
        [HttpGet("search")]
        public IActionResult ClientList(ClientVM client)
        {
            var queryUsers = _context.Clients.AsQueryable();

            var query = _context.Clients.AsQueryable();
            if (!String.IsNullOrEmpty(client.Email))
            {
                query = query.Where(e => e.Email.Contains(client.Email));
            }
            if (!String.IsNullOrEmpty(client.Name))
            {
                query = query.Where(e => e.Name.Contains(client.Name));
            }
            if (!String.IsNullOrEmpty(client.Phone))
            {
                query = query.Where(e => e.Phone.Contains(client.Phone));
            }
            //var queryResult = (from user in query
            //                   where user.UserName.Contains(employee.Name)
            //                   where user.Email.Contains(employee.Email)
            //                   select new UserVM { Name = user.UserName, Email = user.Email }).ToList();
            var clients = query.Select(p => new ClientVM
            {
                Id = p.Id,
                Name = p.Name,
                Email = p.Email,
                Phone = p.Phone

            }).ToList();
            return Ok(clients);
        }

        [HttpPost]
        public IActionResult Create([FromBody]ClientAddVM client)
        {
            if (!ModelState.IsValid)
            {
                var errors = CustomValidator.GetErrorsByModel(ModelState);
                return BadRequest(errors);
            }
            var str = client.Phone;
            var regex = @"\+38\d{1}\(\d{2}\)\d{3}\-\d{2}\-\d{2}";
            var str2 = client.Name;
            var regex2 = @"^[A-Za-z-а-яА-Я]+$";
            var str3 = client.Email;
            var regex3 = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            var match = Regex.Match(str, regex);
            var match2 = Regex.Match(str2, regex2);
            var match3 = Regex.Match(str3, regex3);
            if (!match.Success)
            {
               return BadRequest(new { Phone = "issue" });
            }
            if (!match2.Success)
            {
                return BadRequest(new { Name = "issue" });
            }
            if (!match3.Success)
            {
                return BadRequest(new { Email = "issue" });
            }

            var cl = _context.Clients.FirstOrDefault(p => p.Email == client.Email);           
            if (cl != null)
            {                        
                return BadRequest(new { Email = "Такий email вже існує!" });
            }
            var cli = _context.Clients.FirstOrDefault(p => p.Phone == client.Phone);
            if (cli != null)
            {
                return BadRequest(new { Phone = "Такий номер вже існує!" });
            }
            //var fileDestDir = _env.ContentRootPath;
            //string dirName = _configuration.GetValue<string>("ImagesPath");
            ////Папка де зберігаються фотки
            //string dirPathSave = Path.Combine(fileDestDir, dirName);
            //if (!Directory.Exists(dirPathSave))
            //{
            //    Directory.CreateDirectory(dirPathSave);
            //}
            //var bmp = model.Image.FromBase64StringToImage();
            //var imageName = Path.GetRandomFileName() + ".jpg";
            //string fileSave = Path.Combine(dirPathSave, $"{imageName}");

            //bmp.Save(fileSave, ImageFormat.Jpeg);

            Client c = new Client
            {
                Name = client.Name,
                Phone = client.Phone,
                Image = client.Image,
                Email = client.Email
            };
            _context.Clients.Add(c);
            _context.SaveChanges();
            return Ok(c.Id);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody]ClientDeleteVM client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var clients = _context.Clients.SingleOrDefault(p => p.Id == client.Id);
            if (clients != null)
            {
                _context.Clients.Remove(clients);
                _context.SaveChanges();
            }
            return Ok();
        }
        [HttpPut]
        public IActionResult Update([FromBody]ClientVM client)
        {
            if (!ModelState.IsValid)
            {
                var errors = CustomValidator.GetErrorsByModel(ModelState);
                return BadRequest(errors);
            }
            var str = client.Phone;
            var regex = @"\+38\d{1}\(\d{2}\)\d{3}\-\d{2}\-\d{2}";
            var str2 = client.Name;
            var regex2 = @"^[A-Za-z-а-яА-Я]+$";
            var str3 = client.Email;
            var regex3 = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            var match = Regex.Match(str, regex);
            var match2 = Regex.Match(str2, regex2);
            var match3 = Regex.Match(str3, regex3);
            if (!match.Success)
            {
                return BadRequest(new { Phone = "issue" });
            }
            if (!match2.Success)
            {
                return BadRequest(new { Name = "issue" });
            }
            if (!match3.Success)
            {
                return BadRequest(new { Email = "issue" });
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var cl = _context.Clients.FirstOrDefault(p => p.Email == client.Email);
            if (cl != null)
            {
                return BadRequest(new { Email = "Такий email вже існує!" });
            }
            var cli = _context.Clients.FirstOrDefault(p => p.Phone == client.Phone);
            if (cli != null)
            {
                return BadRequest(new { Phone = "Такий номер вже існує!" });
            }
            var prod = _context.Clients.SingleOrDefault(p => p.Id == client.Id);
            if (prod != null)
            {
                prod.Name = client.Name;
                prod.Email = client.Email;
                prod.Phone = client.Phone;
                _context.SaveChanges();
            }
            return Ok();
        }
    }
}