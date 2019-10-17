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

        public MakeController(IHostingEnvironment env,
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
            var model = _context.Makes.Select(
                p => new MakeVM
                {
                    Id = p.Id,
                    Name = p.Name         
                }).ToList();
            return Ok(model);
        }


        [HttpPost]
        public IActionResult Create([FromBody]MakeAddVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var make = _context.Makes.SingleOrDefault(p => p.Name == model.Name);
            if (make == null)
            {
                Make m = new Make
                {
                    Name = model.Name
                };
                _context.Makes.Add(m);
                _context.SaveChanges();
                return Ok(m.Id);
            }
            return BadRequest();         
            }

        [HttpDelete]
        public IActionResult Delete([FromBody]MakeDeleteVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var make = _context.Makes.SingleOrDefault(p => p.Id == model.Id);
            if (make != null)
            {
                _context.Makes.Remove(make);
                _context.SaveChanges();
            }
            return Ok();
        }
        [HttpPut]
        public IActionResult Update([FromBody]MakeVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var prod = _context.Makes.SingleOrDefault(p => p.Id == model.Id);
            if (prod != null)
            {
                prod.Name = model.Name;
                _context.SaveChanges();
            }
            return Ok();
        }
    }
}