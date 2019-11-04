using System;
using System.Collections.Generic;
using System.Linq;
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
    public class ModelController : ControllerBase
    {
        
            private readonly EFDbContext _context;
            private readonly IConfiguration _configuration;
            private readonly IHostingEnvironment _env;

            public ModelController(IHostingEnvironment env,
                IConfiguration configuration,
                EFDbContext context)
            {
                _configuration = configuration;
                _env = env;
                _context = context;
            }
            [HttpGet]
            public IActionResult ModelList()
            {
            //var query = _context.Makes;
            //var queryModels = _context.Models;
            //var queryResult =(( from u in query
            //                  join a in queryModels on u.Id equals a.MakeId into ua
            //                  from aEmp in ua.DefaultIfEmpty() where u.Id== aEmp.MakeId 
            //                  select new ModelVM
            //                  {
            //                   Id = aEmp.Id,
            //                   Name = aEmp.Name,
            //                   Make = new MakeVM { Id = aEmp.Make.Id, Name = aEmp.Make.Name }                           
            //                  }).OrderBy(r=>r.Id)).ToList();
            return Ok();
            }
            [HttpPost]
            public IActionResult Create([FromBody]ModelAddVM model)
            {
            if (!ModelState.IsValid)
            {
                var errors = CustomValidator.GetErrorsByModel(ModelState);
                return BadRequest(errors);
            }
            var make = _context.Makes.SingleOrDefault(p => p.Id == model.Make.Id);
            if(make!=null)
            {
                var modelCar = _context.Models.SingleOrDefault(p => p.Name == model.Name);
                if (modelCar == null)
                {
                    Model m = new Model
                    {
                        Name = model.Name,
                        //MakeId = model.Make.Id
                    };
                    _context.Models.Add(m);
                    _context.SaveChanges();
                    return Ok("Дані добалено");
                }
            }
            return BadRequest(new { name = "Дана модель вже добалена" });
            }
            [HttpDelete]
            public IActionResult Delete([FromBody]ModelDeleteVM model)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var carModel = _context.Models.SingleOrDefault(p => p.Id == model.Id);
                if (carModel != null)
                {
                    _context.Models.Remove(carModel);
                    _context.SaveChanges();
                }
            return Ok("Дані видалено");
        }
        [HttpPut]
            public IActionResult Update([FromBody]ModelVM model)
            {
            //    if (!ModelState.IsValid)
            //    {
            //        return BadRequest();
            //    }
            //    var carModel = _context.Models.SingleOrDefault(p => p.Id == model.Id);
            //    if (carModel != null)
            //    {
            //        carModel.Name = model.Name;
            //        carModel.MakeId = model.Make.Id;
            //        _context.SaveChanges();
            //    }
            return Ok();
        }
    }
}
