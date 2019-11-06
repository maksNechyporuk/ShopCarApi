using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebElectra.Entities;

namespace ShopCarApi.Entities
{
    public class SeederDB
    {
        private static void SeedFilters(EFDbContext context, IHostingEnvironment _env,
            IConfiguration _config)
        {
            #region tblFilterNames - Назви фільтрів
            string[] filterNames = { "Тип авто", "Пальне","Модель","Колір" };
            foreach (var type in filterNames)
            {
                if (context.FilterNames.SingleOrDefault(f => f.Name == type) == null)
                {
                    context.FilterNames.Add(
                        new Entities.FilterName
                        {
                            Name = type
                        });
                    context.SaveChanges();
                }
            }
            #endregion
            List<Model> listModel = new List<Model>
                {
                    //new Model{ ValueId = 7,Name = "3-series Coupe"},

             };
            #region tblFilterValues - Значення фільтрів
            List<string[]> filterValues = new List<string[]> { 
                new string [] { "Кросовер", "Легковий", "Вантажний" },
                new string [] { "Дизель", "Бензин", "Газ"},
                new string [] {"C6","SPACETOURER","C4 SEDAN","BERLINGO","C-CROSSER","CR-V","PILOT","PASSPORT","FIT","ACCORD","KAMIQ",
                               "YETI","ROOMSTER","OCTAVIA","CITIGO","FORESTER","JUSTY","ASCENT",
                    "TRIBECA","STELLA","TWINGO","TALISMAN","SANDERO","LATITUDE","KOLEOS","ESPACE","VIVARO","CORSA","FRONTERA",
                               "ANTARA","ADAM","GENESIS","SONATA","CRETA","GRANDEUR","KONA","TERRACAN","SENTRA",
                 "PATROL","ALMERA","GT-R","LAFESTA","LINEA","TORO","TIPO","PANDA","MOBI","BRAVO",
                               "508 RXH","TRAVELLER","208","PEUGEOT 1007","308 GT","EXPERT","TAURUS",
                                 "MUSTANG","FOCUS RS","FIESTA","EXPLORER","ALERO","ORLANDO","VIVA","CORVETTE","COBALT","TOURAN","PASSAT",
                               "ATLAS","GOLF","CAMRY","SIENNA","GT 86","S-CLASS CABRIOLET","M-CLASS","V-CLASS","A SEDAN",
                    "AMG GT S","TTS","S3","Q2","A5","Axela","Tribute","MX-5","X5","750iL","3-series Coupe"},
                 new string []{"Зелений","Червоний","Синій","Чорний","Білий","Сірий"}
            };
            
            foreach(var items in filterValues)
            {
                foreach(var value in items)
                {
                    if (context.FilterValues
                        .SingleOrDefault(f => f.Name == value) == null)
                    {
                        context.FilterValues.Add(
                            new Entities.FilterValue
                            {
                                Name = value
                            });
                        context.SaveChanges();
                    }
                }
            }
            #endregion

            #region tblFilterNameGroups - Групування по групах фільтрів

            for (int i = 0; i < filterNames.Length; i++)
            {
                foreach (var value in filterValues[i])
                {
                    var nId = context.FilterNames
                        .SingleOrDefault(f => f.Name == filterNames[i]).Id;
                    var vId = context.FilterValues
                        .SingleOrDefault(f => f.Name == value).Id;
                    if (context.FilterNameGroups
                        .SingleOrDefault(f => f.FilterValueId == vId && 
                        f.FilterNameId == nId) == null)
                    {
                        context.FilterNameGroups.Add(
                            new Entities.FilterNameGroup
                            {
                                FilterNameId = nId,
                                FilterValueId = vId
                            });
                        context.SaveChanges();
                    }
                }
            }
            #endregion

            #region tblCars - Автомобілі
            List<string> cars = new List<string>{
             "154muv2f", "154m2fas" 
            };
            foreach (var item in cars)
            {
                string path = Path.Combine("images", item);

                if (context.Cars.SingleOrDefault(f => f.UniqueName == item) == null)
                {
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);               
                    context.Cars.Add(
                        new Car
                        {
                            UniqueName=item,
                            Date =DateTime.Now,
                            Price=20000,
                            Count =20,
                            Name="BMW X5"
                        });
                    context.SaveChanges();
                }
            }
            #endregion

            #region tblFilters -Фільтри
            Filter[] filters =
            {
                new Filter { FilterNameId = 1, FilterValueId=1, CarId=1 },
                new Filter { FilterNameId = 2, FilterValueId=5, CarId=1 },
                new Filter { FilterNameId = 3, FilterValueId=7, CarId=1 },
                new Filter { FilterNameId = 4, FilterValueId=27, CarId=1 },

                new Filter { FilterNameId = 1, FilterValueId=2, CarId=2 },
                new Filter { FilterNameId = 2, FilterValueId=6, CarId=2 },
                new Filter { FilterNameId = 3, FilterValueId=8, CarId=2 },
                new Filter { FilterNameId = 4, FilterValueId=28, CarId=2 }
            };
            foreach (var item in filters)
            {
                var f = context.Filters.SingleOrDefault(p=>p==item);
                if(f==null)
            context.Filters.Add(new Filter{ FilterNameId=item.FilterNameId,FilterValueId= item.FilterValueId,CarId= item.CarId});
            context.SaveChanges();
            }
            #endregion


       MakesAndModels[] makesAndModels =
       {
                new MakesAndModels { FilterMakeId = 18, FilterValueId=7 },
                new MakesAndModels { FilterMakeId = 18, FilterValueId=8 },
                new MakesAndModels { FilterMakeId = 18, FilterValueId=9 },
                new MakesAndModels { FilterMakeId = 18, FilterValueId=10 },
                new MakesAndModels { FilterMakeId = 18, FilterValueId=11},

                new MakesAndModels { FilterMakeId = 17, FilterValueId=12 },
                new MakesAndModels { FilterMakeId = 17, FilterValueId=13 },
                new MakesAndModels { FilterMakeId = 17, FilterValueId=14 },
                new MakesAndModels { FilterMakeId = 17, FilterValueId=15 },
                new MakesAndModels { FilterMakeId = 17, FilterValueId=16 },

                new MakesAndModels { FilterMakeId = 16, FilterValueId=17 },
                new MakesAndModels { FilterMakeId = 16, FilterValueId=18 },
                new MakesAndModels { FilterMakeId = 16, FilterValueId=19 },
                new MakesAndModels { FilterMakeId = 16, FilterValueId=20 },
                new MakesAndModels { FilterMakeId = 16, FilterValueId=21 },

                new MakesAndModels { FilterMakeId = 15, FilterValueId=22 },
                new MakesAndModels { FilterMakeId = 15, FilterValueId=23 },
                new MakesAndModels { FilterMakeId = 15, FilterValueId=24 },
                new MakesAndModels { FilterMakeId = 15, FilterValueId=25 },
                new MakesAndModels { FilterMakeId = 15, FilterValueId=26 },


                new MakesAndModels { FilterMakeId = 14, FilterValueId=27 },
                new MakesAndModels { FilterMakeId = 14, FilterValueId=28 },
                new MakesAndModels { FilterMakeId = 14, FilterValueId=29 },
                new MakesAndModels { FilterMakeId = 14, FilterValueId=30 },
                new MakesAndModels { FilterMakeId = 14, FilterValueId=31 },
                new MakesAndModels { FilterMakeId = 14, FilterValueId=32 },

                new MakesAndModels { FilterMakeId = 13, FilterValueId=33 },
                new MakesAndModels { FilterMakeId = 13, FilterValueId=34 },
                new MakesAndModels { FilterMakeId = 13, FilterValueId=35 },
                new MakesAndModels { FilterMakeId = 13, FilterValueId=36 },
                new MakesAndModels { FilterMakeId = 13, FilterValueId=37 },

                new MakesAndModels { FilterMakeId = 12, FilterValueId=38 },
                new MakesAndModels { FilterMakeId = 12, FilterValueId=39 },
                new MakesAndModels { FilterMakeId = 12, FilterValueId=40 },
                new MakesAndModels { FilterMakeId = 12, FilterValueId=41 },
                new MakesAndModels { FilterMakeId = 12, FilterValueId=42 },
                new MakesAndModels { FilterMakeId = 12, FilterValueId=43 },

                new MakesAndModels { FilterMakeId = 11, FilterValueId=44 },
                new MakesAndModels { FilterMakeId = 11, FilterValueId=45 },
                new MakesAndModels { FilterMakeId = 11, FilterValueId=46 },
                new MakesAndModels { FilterMakeId = 11, FilterValueId=47 },
                new MakesAndModels { FilterMakeId = 11, FilterValueId=48 },

                new MakesAndModels { FilterMakeId = 10, FilterValueId=49 },
                new MakesAndModels { FilterMakeId = 10, FilterValueId=50 },
                new MakesAndModels { FilterMakeId = 10, FilterValueId=51 },
                new MakesAndModels { FilterMakeId = 10, FilterValueId=52 },
                new MakesAndModels { FilterMakeId = 10, FilterValueId=53 },
                new MakesAndModels { FilterMakeId = 10, FilterValueId=54 },

                new MakesAndModels { FilterMakeId = 9, FilterValueId=55 },
                new MakesAndModels { FilterMakeId = 9, FilterValueId=56 },
                new MakesAndModels { FilterMakeId = 9, FilterValueId=57 },
                new MakesAndModels { FilterMakeId = 9, FilterValueId=58 },
                new MakesAndModels { FilterMakeId = 9, FilterValueId=59 },
                new MakesAndModels { FilterMakeId = 9, FilterValueId=60 },

                new MakesAndModels { FilterMakeId = 8, FilterValueId=61 },
                new MakesAndModels { FilterMakeId = 8, FilterValueId=62 },
                new MakesAndModels { FilterMakeId = 8, FilterValueId=63 },
                new MakesAndModels { FilterMakeId = 8, FilterValueId=64 },
                new MakesAndModels { FilterMakeId = 8, FilterValueId=65 },

                new MakesAndModels { FilterMakeId = 7, FilterValueId=66 },
                new MakesAndModels { FilterMakeId = 7, FilterValueId=67 },
                new MakesAndModels { FilterMakeId = 7, FilterValueId=68 },
                new MakesAndModels { FilterMakeId = 7, FilterValueId=69 },
                new MakesAndModels { FilterMakeId = 7, FilterValueId=70 },

                new MakesAndModels { FilterMakeId = 6, FilterValueId=71 },
                new MakesAndModels { FilterMakeId = 6, FilterValueId=72 },
                new MakesAndModels { FilterMakeId = 6, FilterValueId=73 },
                new MakesAndModels { FilterMakeId = 6, FilterValueId=74 },

                new MakesAndModels { FilterMakeId = 5, FilterValueId=75 },
                new MakesAndModels { FilterMakeId = 5, FilterValueId=76 },
                new MakesAndModels { FilterMakeId = 5, FilterValueId=77 },

                new MakesAndModels { FilterMakeId = 4, FilterValueId=78 },
                new MakesAndModels { FilterMakeId = 4, FilterValueId=79 },
                new MakesAndModels { FilterMakeId = 4, FilterValueId=80 },
                new MakesAndModels { FilterMakeId = 4, FilterValueId=81 },
                new MakesAndModels { FilterMakeId = 4, FilterValueId=82 },


                new MakesAndModels { FilterMakeId = 3, FilterValueId=83 },
                new MakesAndModels { FilterMakeId = 3, FilterValueId=84 },
                new MakesAndModels { FilterMakeId = 3, FilterValueId=85 },
                new MakesAndModels { FilterMakeId = 3, FilterValueId=86 },

                new MakesAndModels { FilterMakeId = 2, FilterValueId=87 },
                new MakesAndModels { FilterMakeId = 2, FilterValueId=88 },
                new MakesAndModels { FilterMakeId = 2, FilterValueId=89 },

                new MakesAndModels { FilterMakeId = 1, FilterValueId=90 },
                new MakesAndModels { FilterMakeId = 1, FilterValueId=91 },
                new MakesAndModels { FilterMakeId = 1, FilterValueId=92 },
            };
            foreach (var item in makesAndModels)
            {
                context.MakesAndModels.Add(new MakesAndModels { FilterMakeId = item.FilterMakeId, FilterValueId = item.FilterValueId });
                context.SaveChanges();
            }

        }
        public static void SeedData(IServiceProvider services, IHostingEnvironment env,
            IConfiguration config)
        {
            using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var managerUser = scope.ServiceProvider.GetRequiredService<UserManager<DbUser>>();
                var managerRole = scope.ServiceProvider.GetRequiredService<RoleManager<DbRole>>();

            

                #region Make
                var context = scope.ServiceProvider.GetRequiredService<EFDbContext>();
                SeedFilters(context, env, config);
                List<Make> listMake = new List<Make>
                {
                    new Make{ Name = "BMW"},
                    new Make{ Name = "Mazda"},
                    new Make{ Name = "Audi"},
                    new Make{ Name = "Mersedes-Benz"},
                    new Make{ Name = "Toyota"},
                    new Make{ Name = "Volkswagen"},
                    new Make{ Name = "Chevrolet"},
                    new Make{ Name = "Ford"},
                    new Make{ Name = "Peugeot"},
                    new Make{ Name = "Fiat"},
                    new Make{ Name = "Nissan"},
                    new Make{ Name = "Hyundai"},
                    new Make{ Name = "Opel"},
                    new Make{ Name = "Renault"},
                    new Make{ Name = "Subaru"},
                    new Make{ Name = "Skoda"},
                    new Make{ Name = "Honda"},
                    new Make{ Name = "Citroen"}
                };
                foreach (var item in listMake)
                {
                    var make = context.Makes.SingleOrDefault(c => c.Name == item.Name);
                    if (make == null)
                    {
                        context.Makes.Add(item);
                        context.SaveChanges();
                    }
                }
                #endregion
                #region Model
                List<MakesAndModels> listModel = new List<MakesAndModels>
                {

                    //new Model{ ValueId = 7,Name = "3-series Coupe"},
                    //new Model{ ValueId = 7,Name = "750iL"},
                    //new Model{ ValueId = 7,Name = "X5"},
                    //new Model{ ValueId = 8,Name = "MX-5" },
                    //new Model{ ValueId = 8,Name = "Tribute"},
                    //new Model{ ValueId = 8,Name = "Axela"},
                    //new Model{ ValueId = 9,Name = "A5"},
                    //new Model{ ValueId = 9,Name = "Q2"},
                    //new Model{ ValueId = 9,Name = "S3"},
                    //new Model{ ValueId = 9,Name = "TTS"},
                    //new Model{ ValueId = 10,Name = "AMG GT S"},
                    //new Model{
                    //ValueId = 10,
                    //Name = "A SEDAN"},
                    //new Model{
                    //ValueId = 10,
                    //Name = "V-CLASS"},
                    //new Model{
                    //ValueId = 10,
                    //Name = "M-CLASS"},
                    //new Model{
                    //ValueId = 10,
                    //Name = "S-CLASS CABRIOLET"},
                    //new Model{
                    //ValueId = 11,
                    //Name = "GT 86"},
                    //new Model{
                    //ValueId = 11,
                    //Name = "SIENNA"},
                    //new Model{
                    //ValueId = 11,
                    //Name = "CAMRY"},
                    //new Model{
                    //ValueId =11,
                    //Name = "GOLF"},
                    //new Model{
                    //ValueId = 11,
                    //Name = "ATLAS"},
                    //new Model{
                    //ValueId = 11,
                    //Name = "PASSAT"},
                    //new Model{
                    //ValueId = 11,
                    //Name = "TOURAN"},
                    //new Model{
                    //ValueId = 13,
                    //Name = "COBALT"},
                    //new Model{
                    //ValueId = 13,
                    //Name = "CORVETTE"},
                    //new Model{
                    //ValueId = 13,
                    //Name = "VIVA"},
                    //new Model{
                    //ValueId = 13,
                    //Name = "ORLANDO"},
                    //new Model{
                    //ValueId = 13,
                    //Name = "ALERO" },
                    //new Model{
                    //ValueId = 14,
                    //Name = "EXPLORER"},
                    //new Model{
                    //ValueId =14,
                    //Name = "FIESTA"},
                    //new Model{
                    //ValueId = 14,
                    //Name = "FOCUS RS" },
                    //new Model{
                    //ValueId = 14,
                    //Name = "MUSTANG"},
                    //new Model{
                    //ValueId = 14,
                    //Name = "TAURUS"},
                    //new Model{
                    //ValueId = 15,
                    //Name = "EXPERT"},
                    //new Model{
                    //ValueId = 15,
                    //Name = "308 GT" },
                    //new Model{
                    //ValueId = 15,
                    //Name = "PEUGEOT 1007"},
                    //new Model{
                    //ValueId = 15,
                    //Name = "208"},
                    //new Model{
                    //ValueId = 15,
                    //Name = "TRAVELLER" },
                    //new Model{
                    //ValueId = 15,
                    //Name = "508 RXH" },
                    //new Model{
                    //ValueId = 16,
                    //Name = "BRAVO" },
                    //new Model{
                    //ValueId = 16,
                    //Name = "MOBI" },
                    //new Model{
                    //ValueId = 16,
                    //Name = "PANDA" },
                    //new Model{
                    //ValueId = 16,
                    //Name = "TIPO" },
                    //new Model{
                    //ValueId = 16,
                    //Name = "TORO"},
                    //new Model{
                    //ValueId = 16,
                    //Name = "LINEA" },
                    //new Model{
                    //ValueId = 17,
                    //Name = "LAFESTA" },
                    //new Model{
                    //ValueId = 17,
                    //Name = "GT-R" },
                    //new Model{
                    //ValueId = 17,
                    //Name = "ALMERA" },
                    //new Model{
                    //ValueId = 17,
                    //Name = "PATROL" },
                    //new Model{
                    //ValueId = 17,
                    //Name = "SENTRA"},
                    //new Model{
                    //ValueId = 12,
                    //Name = "TERRACAN" },
                    //new Model{
                    //ValueId = 12,
                    //Name = "KONA" },
                    //new Model{
                    //ValueId = 10,
                    //Name = "GRANDEUR" },
                    //new Model{
                    //ValueId = 10,
                    //Name = "CRETA" },
                    //new Model{
                    //ValueId = 10,
                    //Name = "SONATA" },
                    //new Model{
                    //ValueId = 10,
                    //Name = "GENESIS"},
                    //new Model{
                    //ValueId = 19,
                    //Name = "ADAM"},
                    //new Model{
                    //ValueId = 19,
                    //Name = "ANTARA" },
                    //new Model{
                    //ValueId = 19,
                    //Name = "FRONTERA" },
                    //new Model{
                    //ValueId = 19,
                    //Name = "CORSA" },
                    //new Model{
                    //ValueId = 19,
                    //Name = "VIVARO" },
                    //new Model{
                    //ValueId = 20,
                    //Name = "ESPACE" },
                    //new Model{
                    //ValueId = 20,
                    //Name = "KOLEOS" },
                    //new Model{
                    //ValueId = 20,
                    //Name = "LATITUDE" },
                    //new Model{
                    //ValueId = 20,
                    //Name = "SANDERO" },
                    //new Model{
                    //ValueId = 20,
                    //Name = "TALISMAN" },
                    //new Model{
                    //ValueId = 20,
                    //Name = "TWINGO" },
                    //new Model{
                    //ValueId = 21,
                    //Name = "STELLA" },
                    //new Model{
                    //ValueId = 21,
                    //Name = "TRIBECA" },
                    //new Model{
                    //ValueId = 21,
                    //Name = "ASCENT" },
                    //new Model{
                    //ValueId = 21,
                    //Name = "JUSTY" },
                    //new Model{
                    //ValueId = 21,
                    //Name = "FORESTER" },
                    //new Model{
                    //ValueId = 22,
                    //Name = "CITIGO" },
                    //new Model{
                    //ValueId = 22,
                    //Name = "OCTAVIA" },
                    //new Model{
                    //ValueId = 22,
                    //Name = "ROOMSTER" },
                    //new Model{
                    //ValueId = 22,
                    //Name = "YETI" },
                    //new Model{
                    //ValueId = 22,
                    //Name = "KAMIQ" },
                    //new Model{
                    //ValueId = 23,
                    //Name = "ACCORD" },
                    //new Model{
                    //ValueId = 23,
                    //Name = "FIT" },
                    //new Model{
                    //ValueId = 23,
                    //Name = "PASSPORT" },
                    //new Model{
                    //ValueId = 23,
                    //Name = "PILOT" },
                    //new Model{
                    //ValueId = 23,
                    //Name = "CR-V" },
                    //new Model{
                    //ValueId = 24,
                    //Name = "C-CROSSER" },
                    //new Model{
                    //ValueId = 24,
                    //Name = "BERLINGO" },
                    //new Model{
                    //ValueId = 24,
                    //Name = "C4 SEDAN" },
                    //new Model{
                    //ValueId = 24,
                    //Name = "SPACETOURER" },
                    //new Model{
                    //ValueId = 24,
                    //Name = "C6" }
                };
                //foreach (var item in listModel)
                //{
                //    var model = context.Models.SingleOrDefault(c => c.Name == item.Name);
                //    if (model == null)
                //    {
                //        context.Models.Add(item);
                //        context.SaveChanges();
                //    }
                //}
                #endregion              

                #region Car
                context = scope.ServiceProvider.GetRequiredService<EFDbContext>();
                //List<Car> listCar = new List<Car>
                //{
                //    new Car{ TypeId = 1,ModelId = 1,FuelTypeId = 3,Date = DateTime.Now,ColorId = 1,Image = "https://inlviv.in.ua/wp-content/uploads/2018/02/74_main.jpg",Price = 500000},
                //    new Car{ TypeId = 1,ModelId = 4,FuelTypeId = 4,Date = DateTime.Now,ColorId = 4,Image = "https://inlviv.in.ua/wp-content/uploads/2018/02/74_main.jpg",Price = 260000},
                //    new Car{ TypeId = 1,ModelId = 2,FuelTypeId = 2,Date = DateTime.Now,ColorId = 1,Image = "https://inlviv.in.ua/wp-content/uploads/2018/02/74_main.jpg",Price = 150000},
                //    new Car{ TypeId = 1,ModelId = 3,FuelTypeId = 2,Date = DateTime.Now,ColorId = 3,Image = "https://inlviv.in.ua/wp-content/uploads/2018/02/74_main.jpg",Price = 400000},
                //    new Car{ TypeId = 1,ModelId = 2,FuelTypeId = 4,Date = DateTime.Now,ColorId = 2,Image = "https://inlviv.in.ua/wp-content/uploads/2018/02/74_main.jpg",Price = 700000}
                //};
                //foreach (var item in listCar)
                //{
                //    var car = context.Cars.SingleOrDefault(c => c.Id== item.Id);
                //    if (car == null)
                //    {
                //        context.Cars.Add(item);
                //        context.SaveChanges();
                //    }
                //}
                #endregion

                #region Clients
                context = scope.ServiceProvider.GetRequiredService<EFDbContext>();
                List<Client> listClient = new List<Client>
                {
                    new Client{Name = "Zahar",Phone = "+380(68)238-80-01",Email="bomba@gmail.com"},
                    new Client{Name = "Yuri",Phone = "+380(68)278-55-22",Email="bomba@gmail.com"},
                    new Client{Name = "Maxim", Phone = "+380(97)888-15-97",Email="bomba@gmail.com"}
                };
                foreach (var item in listClient)
                {
                    var client = context.Clients.SingleOrDefault(c => c.Name == item.Name);
                    if (client == null)
                    {
                        context.Clients.Add(item);
                        context.SaveChanges();
                    }
                }
                #endregion

                SeedUsers(managerUser, managerRole);
            }
        }
        public static void SeedUsers(UserManager<DbUser> userManager,RoleManager<DbRole> roleManager)
        {
            string roleName = "Admin";
            var role = roleManager.FindByNameAsync(roleName).Result;
            if (role == null)
            {
                role = new DbRole
                {
                    Name = roleName
                };
                var addRoleResult = roleManager.CreateAsync(role).Result;
            }
            roleName = "Employee";
            role = roleManager.FindByNameAsync(roleName).Result;
            if (role == null)
            {
                role = new DbRole
                {
                    Name = roleName
                };
                var addRoleResult = roleManager.CreateAsync(role).Result;
            }
            var userEmail = "admin@gmail.com";
            var user = userManager.FindByEmailAsync(userEmail).Result;
            if (user == null)
            {
                user = new DbUser
                {
                    Email = userEmail,
                    UserName = "Yura"
                };
                var result = userManager.CreateAsync(user, "Qwerty1-").Result;
                if (result.Succeeded)
                {
                    result = userManager.AddToRoleAsync(user, roleName).Result;
                }
            }
            userEmail = "maks123@gmail.com";
            user = userManager.FindByEmailAsync(userEmail).Result;
            if (user == null)
            {
                user = new DbUser
                {
                    Email = userEmail,
                    UserName = "Maksim"
                };
                var result = userManager.CreateAsync(user, "max12478-Q").Result;
                if (result.Succeeded)
                {
                    result = userManager.AddToRoleAsync(user, roleName).Result;
                }
            }
            userEmail = "zaharjoker@gmail.com";
            user = userManager.FindByEmailAsync(userEmail).Result;
            if (user == null)
            {
                user = new DbUser
                {
                    Email = userEmail,
                    UserName = "Zahar"
                };
                var result = userManager.CreateAsync(user, "zahardeadinside!39-R").Result;
                if (result.Succeeded)
                {
                    result = userManager.AddToRoleAsync(user, roleName).Result;
                }
            }
            userEmail = "invoker@ukr.net";
            user = userManager.FindByEmailAsync(userEmail).Result;
            if (user == null)
            {
                user = new DbUser
                {
                    Email = userEmail,
                    UserName = "Carl"
                };
                var result = userManager.CreateAsync(user, "quaswexQ-11").Result;
                if (result.Succeeded)
                {
                    result = userManager.AddToRoleAsync(user, roleName).Result;
                }
            }
        }
        }
    }
