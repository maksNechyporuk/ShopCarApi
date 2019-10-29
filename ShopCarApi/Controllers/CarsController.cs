using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShopCarApi.Entities;
using ShopCarApi.Helpers;
using ShopCarApi.ViewModels;
using WebElectra.Entities;

namespace ShopCarApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
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
        [HttpGet("CarsByFilter")]
        public IActionResult FilterData(int [] value)
        {
            var filters = GetListFilters(_context);
            var list = GetCarsByFilter(value, filters);

            var _filters = (from g in _context.Filters
                           select g).ToList();
            var valueFilters = (from g in _context.FilterValues
                                select g).ToList();
            var nameFilters = (from g in _context.FilterNames
                               select g).ToList();
            var cars = (from g in _context.Cars
                        select g).ToList();
            var resultCar = (from c in list
                             join g in _filters on c.Id equals g.CarId into ua
                             from aEmp in ua.DefaultIfEmpty()
                             group ua by
                             new CarGetVM
                             {
                                 Id = c.Id,
                                 Date = c.Date,
                                 Image = c.Image,
                                 Price = c.Price,
                                 filters = (from f in ua
                                            group f by new FNameGetViewModel
                                            {
                                                Id = f.FilterNameId,
                                                Name = f.FilterNameOf.Name,
                                                Children = f.FilterValueOf.Name
                                            } into b
                                            select b.Key)
                                                            .ToList()
                             } into b
                             select b.Key).ToList();
            var GetCars = resultCar.Distinct(new CarComparer());
            return Ok(GetCars);
        }
        private List<FNameViewModel> GetListFilters(EFDbContext context)
        {
            var queryName = from f in context.FilterNames.AsQueryable()
                            select f;
            var queryGroup = from g in context.FilterNameGroups.AsQueryable()
                             select g;

            //Отримуємо загальну множину значень
            var query = from u in queryName
                        join g in queryGroup on u.Id equals g.FilterNameId into ua
                        from aEmp in ua.DefaultIfEmpty()
                        select new
                        {
                            FNameId = u.Id,
                            FName = u.Name,
                            FValueId = aEmp != null ? aEmp.FilterValueId : 0,
                            FValue = aEmp != null ? aEmp.FilterValueOf.Name : null,
                        };

            //Групуємо по іменам і сортуємо по спаданю імен
            var groupNames = (from f in query
                              group f by new
                              {
                                  Id = f.FNameId,
                                  Name = f.FName
                              } into g
                              //orderby g.Key.Name
                              select g).OrderByDescending(g => g.Key.Name);

            //По групах отримуємо
            var result = from fName in groupNames
                         select
                         new FNameViewModel
                         {
                             Id = fName.Key.Id,
                             Name = fName.Key.Name,
                             Children = (from v in fName
                                         group v by new FValueViewModel
                                         {
                                             Id = v.FValueId,
                                             Name = v.FValue
                                         } into g
                                         select g.Key)
                                         .OrderBy(l => l.Name).ToList()
                         };

            return result.ToList();
        }

        private List<CarVM> GetCarsByFilter(int[] values, List<FNameViewModel> filtersList)
        {
            int[] filterValueSearchList = values;
            var query = _context
                .Cars
                .Include(f => f.Filtres)
                .AsQueryable();
            foreach (var fName in filtersList)
            {
                int count = 0; //Кількість співпадінь у даній групі фільрів
                var predicate = PredicateBuilder.False<Car>();
                foreach (var fValue in fName.Children)
                {
                    for (int i = 0; i < filterValueSearchList.Length; i++)
                    {
                        var idV = fValue.Id;
                        if (filterValueSearchList[i] == idV)
                        {
                            predicate = predicate
                                .Or(p => p.Filtres
                                    .Any(f => f.FilterValueId == idV));
                            count++;
                        }
                    }
                }
                if (count != 0)
                    query = query.Where(predicate);
            }
            var listProductSearch = query.Select(p => new CarVM
            {
                Id = p.Id,
                Price = p.Price
            }).ToList();
            return listProductSearch;

            //return null;
        }

        [HttpGet]
        public IActionResult MakeList()
        {
            var filters = (from g in _context.Filters
                           select g).ToList();
            var valueFilters = (from g in _context.FilterValues
                                select g).ToList();
            var nameFilters = (from g in _context.FilterNames
                               select g).ToList();
            var cars = (from g in _context.Cars
                        select g).ToList();
            var resultCar = (from c in cars
                             join g in filters on c.Id equals g.CarId into ua 
             from aEmp  in ua.DefaultIfEmpty()
             group ua by
             new  CarGetVM
                             {
                                 Id = c.Id,
                                 Date = c.Date,
                                 Image = c.Image,
                                 Price = c.Price,
                                 filters = (from f in ua
                                            group f by new FNameGetViewModel
                                            {
                                               Id = f.FilterNameId,
                                               Name = f.FilterNameOf.Name,
                                               Children =f.FilterValueOf.Name
                                            } into b
                                            select b.Key)
                                            .ToList()                                                                                                               
                             } into b
                               select b.Key).ToList();
         var GetCars = resultCar.Distinct(new CarComparer());           
         return Ok(GetCars);
        }
        [HttpPost]
        public IActionResult Create([FromBody]CarAddVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            //Car m = new Car
            //{
            //    Image=model.Image,
            //    Price=model.Price,
            //    ColorId=model.Color.Id,
            //    FuelTypeId=model.Fuel_type.Id,
            //    Date=model.Date,
            //    ModelId=model.Model.Id,
            //    TypeId=model.Type_car.Id             
            //};
            //_context.Cars.Add(m);
            //_context.SaveChanges();
            return Ok();
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
                //car=new Car
                //{
                //    Image = model.Image,
                //    Price = model.Price,
                //    ColorId = model.Color.Id,
                //    FuelTypeId = model.Fuel_type.Id,
                //    Date = model.Date,
                //    ModelId = model.Model.Id,
                //    TypeId = model.Type_car.Id
                //};
                _context.SaveChanges();
            }
            return Ok();
        }
    }
}