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
            public IActionResult MakeList()
            {
            var query = _context.Makes.AsQueryable();
            var queryModels = _context.Models.AsQueryable();
            var queryResult =( from u in query
                              join a in queryModels on u.Id equals a.MakeId into ua
                              from aEmp in ua.DefaultIfEmpty()
                              select new ModelVM
                              {
                                  Id = aEmp.Id,
                                  Name = aEmp.Name,                                 
                               Make=new MakeVM {Id=u.Id,Name=u.Name }
                              }).OrderBy(r=>r.Id);
            var model = queryResult.ToList();       
                return Ok(model);
            }


            [HttpPost]
            public IActionResult Create([FromBody]ModelAddVM model)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

            var make = _context.Makes.SingleOrDefault(p => p.Id == model.Make.Id);
            if(make!=null)
            {
            Model m = new Model
                {
                    Name = model.Name,
                    MakeId =model.Make.Id
                };
                _context.Models.Add(m);
                _context.SaveChanges();

            }
                return Ok();
            }

            [HttpDelete]
            public IActionResult Delete([FromBody]ModelDeleteVM model)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var make = _context.Models.SingleOrDefault(p => p.Id == model.Id);
                if (make != null)
                {
                    _context.Models.Remove(make);
                    _context.SaveChanges();
                }
                return Ok();
            }
            [HttpPut]
            public IActionResult Update([FromBody]ModelVM model)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var prod = _context.Models.SingleOrDefault(p => p.Id == model.Id);
                if (prod != null)
                {
                    prod.Name = model.Name;
                    _context.SaveChanges();
                }
                return Ok();
            }
        }
    }
