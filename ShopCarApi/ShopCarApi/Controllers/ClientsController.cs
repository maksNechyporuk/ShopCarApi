using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpGet]
        public IActionResult ClientList()
        {
            var client = _context.Clients.Select(
                p => new ClientVM
                {
                    Id = p.Id,
                    Name = p.Name,
                    Phone = p.Phone,
                    Image = p.Image
                }).ToList();
            return Ok(client);
        }


        [HttpPost]
        public IActionResult Create([FromBody]ClientAddVM client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
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
                Image = client.Image
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
                return BadRequest();
            }
            var prod = _context.Clients.SingleOrDefault(p => p.Id == client.Id);
            if (prod != null)
            {
                prod.Name = client.Name;
                _context.SaveChanges();
            }
            return Ok();
        }
    }
}