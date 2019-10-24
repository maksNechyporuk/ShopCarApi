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
    public class CarsController : ControllerBase
    {

        private readonly EFDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _env;



        public CarsController(IHostingEnvironment env,
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
            var model = _context.Cars.Select(
                p => new CarVM
                {
                    Id = p.Id,
                    Color=new ColorVM {Name=p.Color.Name,A=p.Color.A,B=p.Color.B,G=p.Color.G,R=p.Color.R },
                    Date=p.Date,
                    Fuel_type=new FuelTypeVM {Type=p.Type.Name },
                    Model=new ModelVM {Name=p.Model.Name },
                    Type_car=new TypeVM {Name=p.Type.Name },
                    Price=p.Price,
                    Image=p.Image               
                }).ToList();
            return Ok(model);
        }
        [HttpPost]
        public IActionResult Create([FromBody]CarAddVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Car m = new Car
            {
                Image=model.Image,
                Price=model.Price,
                ColorId=model.Color.Id,
                FuelTypeId=model.Fuel_type.Id,
                Date=model.Date,
                ModelId=model.Model.Id,
                TypeId=model.Type_car.Id             
            };
            _context.Cars.Add(m);
            _context.SaveChanges();
            return Ok(m.Id);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody]CarDeleteVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var make = _context.Cars.SingleOrDefault(p => p.Id == model.Id);
            if (make != null)
            {
                _context.Cars.Remove(make);
                _context.SaveChanges();
            }
            return Ok();
        }
        [HttpPut]
        public IActionResult Update([FromBody]CarVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var car = _context.Cars.SingleOrDefault(p => p.Id == model.Id);
            if (car != null)
            {
                car=new Car
                {
                    Image = model.Image,
                    Price = model.Price,
                    ColorId = model.Color.Id,
                    FuelTypeId = model.Fuel_type.Id,
                    Date = model.Date,
                    ModelId = model.Model.Id,
                    TypeId = model.Type_car.Id
                };
                _context.SaveChanges();
            }
            return Ok();
        }
    }
}