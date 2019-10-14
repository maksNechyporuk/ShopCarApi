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
    [Route("api/[controller]")]
    [ApiController]
    public class FuelTypesController : ControllerBase
    {
        private readonly EFDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _env;

        public FuelTypesController(IHostingEnvironment env,
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
            var model = _context.FuelTypes.Select(
                p => new FuelTypeVM
                {
                    Id = p.Id,
                    Type = p.Type
                }).ToList();
            return Ok(model);
        }


        [HttpPost]
        public IActionResult Create([FromBody]FuelTypeAddVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            FuelType m = new FuelType
            {
                Type = model.Type
            };
            _context.FuelTypes.Add(m);
            _context.SaveChanges();
            return Ok(m.Id);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody]FuelTypeDeleteVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var type = _context.FuelTypes.SingleOrDefault(p => p.Id == model.Id);
            if (type != null)
            {
                _context.FuelTypes.Remove(type);
                _context.SaveChanges();
            }
            return Ok();
        }
        [HttpPut]
        public IActionResult Update([FromBody]FuelTypeVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var prod = _context.FuelTypes.SingleOrDefault(p => p.Id == model.Id);
            if (prod != null)
            {
                prod.Type = model.Type;
                _context.SaveChanges();
            }
            return Ok();
        }
    }
}