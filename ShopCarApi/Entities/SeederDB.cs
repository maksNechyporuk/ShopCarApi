using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebElectra.Entities;

namespace ShopCarApi.Entities
{
    public class SeederDB
    {
        private static void SeedFilters(EFDbContext context)
        {
            #region tblFilterNames - Назви фільтрів
            string[] filterNames = { "Тип авто", "Пальне","Марки","Колір" };
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

            #region tblFilterValues - Значення фільтрів
            List<string[]> filterValues = new List<string[]> { 
                new string [] { "Кросовер", "Легковий", "Вантажний" },
                new string [] { "Дизель", "Бензин", "Газ"},
                new string [] {"BMW","Mazda","Audi","Mersedes-Benz","Toyota","Volkswagen","Chevrolet","Ford","Peugeot","Fiat","Nissan",
                               "Hyundai","Opel","Renault","Subaru","Skoda","Honda","Citroen"},
                new string []{"Зелений","Червоний","Синій","Чорний","Білий","Сірий"}
            };
            //string t=filterNames[0];
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
                if (context.Cars.SingleOrDefault(f => f.UniqueName == item) == null)
                {
                    context.Cars.Add(
                        new Car
                        {
                            UniqueName=item,
                            Date =DateTime.Now,
                            Price=20000
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
                new Filter { FilterNameId = 1, FilterValueId=2, CarId=2 },
                new Filter { FilterNameId = 2, FilterValueId=6, CarId=2 }
            };
            foreach (var item in filters)
            {
            context.Filters.Add(new Filter{ FilterNameId=item.FilterNameId,FilterValueId= item.FilterValueId,CarId= item.CarId});
                context.SaveChanges();
            }
            #endregion
        }
        public static void SeedData(IServiceProvider services, IHostingEnvironment env,
            IConfiguration config)
        {

            using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var managerUser = scope.ServiceProvider.GetRequiredService<UserManager<DbUser>>();
                var managerRole = scope.ServiceProvider.GetRequiredService<RoleManager<DbRole>>();

                #region FuelType
           var   context = scope.ServiceProvider.GetRequiredService<EFDbContext>();
                List<FuelType> listFuelType = new List<FuelType>
                {
                    new FuelType{ Id = 1,Type = "Electric"},
                    new FuelType{ Id = 2,Type = "Gas"},
                    new FuelType{ Id = 3,Type = "Diesel"},
                    new FuelType{ Id = 4,Type = "Gasoline"}
                };
                foreach (var item in listFuelType)
                {
                    var fuel_type = context.FuelTypes.SingleOrDefault(c => c.Type == item.Type);
                    if (fuel_type == null)
                    {
                        context.FuelTypes.Add(item);
                        context.SaveChanges();
                    }
                }
                #endregion


                context = scope.ServiceProvider.GetRequiredService<EFDbContext>();
  
               
                #region Model
                context = scope.ServiceProvider.GetRequiredService<EFDbContext>();
                List<Model> listModel = new List<Model>
                {
                    new Model{ MakeId = 1,Name = "3-series Coupe"},
                    new Model{ MakeId = 1,Name = "750iL"},
                    new Model{ MakeId = 1,Name = "X5"},
                    new Model{ MakeId = 2,Name = "MX-5" },
                    new Model{ MakeId = 2,Name = "Tribute"},
                    new Model{ MakeId = 2,Name = "Axela"},
                    new Model{ MakeId = 3,Name = "A5"},
                    new Model{ MakeId = 3,Name = "Q2"},
                    new Model{ MakeId = 3,Name = "S3"},
                    new Model{ MakeId = 3,Name = "TTS"},
                    new Model{ MakeId = 4,Name = "AMG GT S"},
                    new Model{ 
                    MakeId = 4,
                    Name = "A SEDAN"},
                    new Model{ 
                    MakeId = 4,
                    Name = "V-CLASS"},
                    new Model{ 
                    MakeId = 4,
                    Name = "M-CLASS"},
                    new Model{ 
                    MakeId = 4,
                    Name = "S-CLASS CABRIOLET"},
                    new Model{ 
                    MakeId = 5,
                    Name = "GT 86"},
                    new Model{ 
                    MakeId = 5,
                    Name = "SIENNA"},
                    new Model{  
                    MakeId = 5,
                    Name = "CAMRY"},
                    new Model{  
                    MakeId = 6,
                    Name = "GOLF"},
                    new Model{ 
                    MakeId = 6,
                    Name = "ATLAS"},
                    new Model{ 
                    MakeId = 6,
                    Name = "PASSAT"},
                    new Model{ 
                    MakeId = 6,
                    Name = "TOURAN"},
                    new Model{  
                    MakeId = 7,
                    Name = "COBALT"},
                    new Model{
                    MakeId = 7,
                    Name = "CORVETTE"},
                    new Model{  
                    MakeId = 7,
                    Name = "VIVA"},
                    new Model{ 
                    MakeId = 7,
                    Name = "ORLANDO"},
                    new Model{
                    MakeId = 7,
                    Name = "ALERO" },
                    new Model{ 
                    MakeId = 8,
                    Name = "EXPLORER"},
                    new Model{ 
                    MakeId = 8,
                    Name = "FIESTA"},
                    new Model{
                    MakeId = 8,
                    Name = "FOCUS RS" },
                    new Model{ 
                    MakeId = 8,
                    Name = "MUSTANG"},
                    new Model{ 
                    MakeId = 8,
                    Name = "TAURUS"},
                    new Model{
                    MakeId = 9,
                    Name = "EXPERT"},
                    new Model{
                    MakeId = 9,
                    Name = "308 GT" },
                    new Model{ 
                    MakeId = 9,
                    Name = "PEUGEOT 1007"},
                    new Model{  
                    MakeId = 9,
                    Name = "208"},
                    new Model{
                    MakeId = 9,
                    Name = "TRAVELLER" },
                    new Model{ 
                    MakeId = 9,
                    Name = "508 RXH" },
                    new Model{
                    MakeId = 10,
                    Name = "BRAVO" },
                    new Model{
                    MakeId = 10,
                    Name = "MOBI" },
                    new Model{ 
                    MakeId = 10,
                    Name = "PANDA" },
                    new Model{ 
                    MakeId = 10,
                    Name = "TIPO" },
                    new Model{ 
                    MakeId = 10,
                    Name = "TORO"},
                    new Model{
                    MakeId = 10,
                    Name = "LINEA" },
                    new Model{
                    MakeId = 11,
                    Name = "LAFESTA" },
                    new Model{
                    MakeId = 11,
                    Name = "GT-R" },
                    new Model{
                    MakeId = 11,
                    Name = "ALMERA" },
                    new Model{
                    MakeId = 11,
                    Name = "PATROL" },
                    new Model{
                    MakeId = 11,
                    Name = "SENTRA"},
                    new Model{ 
                    MakeId = 12,
                    Name = "TERRACAN" },
                    new Model{ 
                    MakeId = 12,
                    Name = "KONA" },
                    new Model{
                    MakeId = 12,
                    Name = "GRANDEUR" },
                    new Model{
                    MakeId = 12,
                    Name = "CRETA" },
                    new Model{
                    MakeId = 12,
                    Name = "SONATA" },
                    new Model{ 
                    MakeId = 12,
                    Name = "GENESIS"},
                    new Model{ 
                    MakeId = 13,
                    Name = "ADAM"},
                    new Model{ 
                    MakeId = 13,
                    Name = "ANTARA" },
                    new Model{
                    MakeId = 13,
                    Name = "FRONTERA" },
                    new Model{
                    MakeId = 13,
                    Name = "CORSA" },
                    new Model{
                    MakeId = 13,
                    Name = "VIVARO" },
                    new Model{ 
                    MakeId = 14,
                    Name = "ESPACE" },
                    new Model{ 
                    MakeId = 14,
                    Name = "KOLEOS" },
                    new Model{
                    MakeId = 14,
                    Name = "LATITUDE" },
                    new Model{
                    MakeId = 14,
                    Name = "SANDERO" },
                    new Model{ 
                    MakeId = 14,
                    Name = "TALISMAN" },
                    new Model{
                    MakeId = 14,
                    Name = "TWINGO" },
                    new Model{
                    MakeId = 15,
                    Name = "STELLA" },
                    new Model{
                    MakeId = 15,
                    Name = "TRIBECA" },
                    new Model{ 
                    MakeId = 15,
                    Name = "ASCENT" },
                    new Model{
                    MakeId = 15,
                    Name = "JUSTY" },
                    new Model{
                    MakeId = 15,
                    Name = "FORESTER" },
                    new Model{
                    MakeId = 16,
                    Name = "CITIGO" },
                    new Model{
                    MakeId = 16,
                    Name = "OCTAVIA" },
                    new Model{
                    MakeId = 16,
                    Name = "ROOMSTER" },
                    new Model{
                    MakeId = 16,
                    Name = "YETI" },
                    new Model{
                    MakeId = 16,
                    Name = "KAMIQ" },
                    new Model{
                    MakeId = 17,
                    Name = "ACCORD" },
                    new Model{
                    MakeId = 17,
                    Name = "FIT" },
                    new Model{
                    MakeId = 17,
                    Name = "PASSPORT" },
                    new Model{
                    MakeId = 17,
                    Name = "PILOT" },
                    new Model{ 
                    MakeId = 17,
                    Name = "CR-V" },
                    new Model{
                    MakeId = 18,
                    Name = "C-CROSSER" },
                    new Model{
                    MakeId = 18,
                    Name = "BERLINGO" },
                    new Model{ 
                    MakeId = 18,
                    Name = "C4 SEDAN" },
                    new Model{
                    MakeId = 18,
                    Name = "SPACETOURER" },
                    new Model{
                    MakeId = 18,
                    Name = "C6" }                 
                };
                foreach (var item in listModel)
                {
                    var model = context.Models.SingleOrDefault(c => c.Name == item.Name);
                    if (model == null)
                    {
                        context.Models.Add(item);
                        context.SaveChanges();
                    }
                }
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
                    new Client{Name = "Zahar",Phone = "+380(68)238-80-01"},
                    new Client{Name = "Yuri",Phone = "+380(68)278-55-22"},
                    new Client{Name = "Maxim", Phone = "+380(97)888-15-97"}
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
