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
    public class ColorController : ControllerBase
    {
        private readonly EFDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _env;

 

        public ColorController(IHostingEnvironment env,
            IConfiguration configuration,
            EFDbContext context)
        {
            _configuration = configuration;
            _env = env;
            _context = context;
        }


        [HttpGet]
        public IActionResult MakeList()
        {
            var model = _context.Colors.Select(
                p => new ColorVM
                {
                    Id = p.Id,
                    Name = p.Name
                }).ToList();
            return Ok(model);
        }
        [HttpPost]
        public IActionResult Create([FromBody]ColorAddVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            Colors m = new Colors
            {
                Name = model.Name
            };
            _context.Colors.Add(m);
            _context.SaveChanges();
            return Ok(m.Id);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody]ColorDeleteVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var color = _context.Colors.SingleOrDefault(p => p.Id == model.Id);
            if (color != null)
            {
                _context.Colors.Remove(color);
                _context.SaveChanges();
            }
            return Ok();
        }
        [HttpPut]
        public IActionResult Update([FromBody]ColorVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var prod = _context.Colors.SingleOrDefault(p => p.Id == model.Id);
            if (prod != null)
            {
                prod.Name = model.Name;
                _context.SaveChanges();
            }
            return Ok();
        }

    }
}