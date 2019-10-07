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
    public class MakeController : ControllerBase
    {
        private readonly EFDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _env;
        [HttpPost]
        public IActionResult Create([FromBody]MakeAddVM model)
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

            Make m = new Make
            {
                Name = model.Name                            
            };
            _context.Makes.Add(m);
            _context.SaveChanges();
            return Ok(m.Id);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody]ProductDeleteVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var prod = _context.Products.SingleOrDefault(p => p.Id == model.Id);
            if (prod != null)
            {
                _context.Products.Remove(prod);
                _context.SaveChanges();
            }
            return BadRequest();
        }

    }
}