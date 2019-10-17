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
        public static void SeedData(IServiceProvider services, IHostingEnvironment env,
            IConfiguration config)
        {

            using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var managerUser = scope.ServiceProvider.GetRequiredService<UserManager<DbUser>>();
                var managerRole = scope.ServiceProvider.GetRequiredService<RoleManager<DbRole>>();

                #region Colors
                var context = scope.ServiceProvider.GetRequiredService<EFDbContext>();
                List<Colors> listColors = new List<Colors>
                {
                    new Colors {  Id = 1, Name = "Red",  R = 255, G = 0, B = 0, A = 1 },
                    new Colors {  Id = 2, Name = "Green", R = 0, G = 115, B = 0, A = 1 },
                    new Colors {  Id = 3, Name = "Dark Blue", R = 0, G = 0, B = 228, A = 1 },
                    new Colors {  Id = 4, Name = "Black", R = 0, G = 0, B = 0, A = 1},
                    new Colors {  Id = 5, Name = "White", R = 255, G = 255, B = 255, A = 1}
                };
                foreach(var item in listColors)
                {
                    var color = context.Colors.SingleOrDefault(c => c.Name == item.Name);
                    if (color == null)
                    {
                        context.Colors.Add(item);
                        context.SaveChanges();
                    }
                }                                         
                #endregion

                #region FuelType
                context = scope.ServiceProvider.GetRequiredService<EFDbContext>();
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

                #region Make
                context = scope.ServiceProvider.GetRequiredService<EFDbContext>();
                List<Make> listMake = new List<Make>
                {
                    new Make{ Id = 1,Name = "BMW"},
                    new Make{ Id = 2,Name = "Mazda"},
                    new Make{ Id = 3,Name = "Audi"},
                    new Make{ Id = 4,Name = "Mersedes-Benz"},
                    new Make{ Id = 5,Name = "Toyota"},
                    new Make{ Id = 6,Name = "Volkswagen"},
                    new Make{ Id = 7,Name = "Chevrolet"},
                    new Make{ Id = 8,Name = "Ford"},
                    new Make{ Id = 9,Name = "Peugeot"},
                    new Make{ Id = 10,Name = "Fiat"},
                    new Make{ Id = 11,Name = "Nissan"},
                    new Make{ Id = 12,Name = "Hyundai"},
                    new Make{ Id = 13,Name = "Opel"},
                    new Make{ Id = 14,Name = "Renault"},
                    new Make{ Id = 15,Name = "Subaru"},
                    new Make{ Id = 16,Name = "Skoda"},
                    new Make{ Id = 17,Name = "Honda"},
                    new Make{ Id = 18,Name = "Citroen"}
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
                context = scope.ServiceProvider.GetRequiredService<EFDbContext>();
                List<Model> listModel = new List<Model>
                {
                    new Model{ Id = 1,MakeId = 1,Name = "3-series Coupe"},
                    new Model{ Id = 2,MakeId = 1,Name = "750iL"},
                    new Model{ Id = 3,MakeId = 1,Name = "X5"},
                    new Model{ Id = 4,MakeId = 2,Name = "MX-5" },
                    new Model{ Id = 5,MakeId = 2,Name = "Tribute"},
                    new Model{ Id = 6,MakeId = 2,Name = "Axela"},
                    new Model{ Id = 7,MakeId = 3,Name = "A5"},
                    new Model{ Id = 8,MakeId = 3,Name = "Q2"},
                    new Model{ Id = 9,MakeId = 3,Name = "S3"},
                    new Model{ Id = 10,MakeId = 3,Name = "TTS"},
                    new Model{ Id = 11,MakeId = 4,Name = "AMG GT S"},
                    new Model{  Id = 12,
                    MakeId = 4,
                    Name = "A SEDAN"},
                    new Model{ Id = 13,
                    MakeId = 4,
                    Name = "V-CLASS"},
                    new Model{ Id = 14,
                    MakeId = 4,
                    Name = "M-CLASS"},
                    new Model{ Id = 15,
                    MakeId = 4,
                    Name = "S-CLASS CABRIOLET"},
                    new Model{ Id = 16,
                    MakeId = 5,
                    Name = "GT 86"},
                    new Model{ Id = 17,
                    MakeId = 5,
                    Name = "SIENNA"},
                    new Model{  Id = 18,
                    MakeId = 5,
                    Name = "CAMRY"},
                    new Model{  Id = 19,
                    MakeId = 6,
                    Name = "GOLF"},
                    new Model{ Id = 20,
                    MakeId = 6,
                    Name = "ATLAS"},
                    new Model{ Id = 21,
                    MakeId = 6,
                    Name = "PASSAT"},
                    new Model{ Id = 22,
                    MakeId = 6,
                    Name = "TOURAN"},
                    new Model{   Id = 23,
                    MakeId = 7,
                    Name = "COBALT"},
                    new Model{ Id = 24,
                    MakeId = 7,
                    Name = "CORVETTE"},
                    new Model{  Id = 25,
                    MakeId = 7,
                    Name = "VIVA"},
                    new Model{ Id = 26,
                    MakeId = 7,
                    Name = "ORLANDO"},
                    new Model{Id = 27,
                    MakeId = 7,
                    Name = "ALERO" },
                    new Model{ Id = 28,
                    MakeId = 8,
                    Name = "EXPLORER"},
                    new Model{  Id = 29,
                    MakeId = 8,
                    Name = "FIESTA"},
                    new Model{Id = 30,
                    MakeId = 8,
                    Name = "FOCUS RS" },
                    new Model{  Id = 31,
                    MakeId = 8,
                    Name = "MUSTANG"},
                    new Model{ Id = 32,
                    MakeId = 8,
                    Name = "TAURUS"},
                    new Model{ Id = 33,
                    MakeId = 9,
                    Name = "EXPERT"},
                    new Model{Id = 34,
                    MakeId = 9,
                    Name = "308 GT" },
                    new Model{ Id = 35,
                    MakeId = 9,
                    Name = "PEUGEOT 1007"},
                    new Model{  Id = 36,
                    MakeId = 9,
                    Name = "208"},
                    new Model{Id = 37,
                    MakeId = 9,
                    Name = "TRAVELLER" },
                    new Model{ Id = 38,
                    MakeId = 9,
                    Name = "508 RXH" },
                    new Model{Id = 39,
                    MakeId = 10,
                    Name = "BRAVO" },
                    new Model{ Id = 40,
                    MakeId = 10,
                    Name = "MOBI" },
                    new Model{ Id = 41,
                    MakeId = 10,
                    Name = "PANDA" },
                    new Model{ Id = 42,
                    MakeId = 10,
                    Name = "TIPO" },
                    new Model{ Id = 43,
                    MakeId = 10,
                    Name = "TORO"},
                    new Model{Id = 44,
                    MakeId = 10,
                    Name = "LINEA" },
                    new Model{Id = 45,
                    MakeId = 11,
                    Name = "LAFESTA" },
                    new Model{Id = 46,
                    MakeId = 11,
                    Name = "GT-R" },
                    new Model{Id = 47,
                    MakeId = 11,
                    Name = "ALMERA" },
                    new Model{Id = 48,
                    MakeId = 11,
                    Name = "PATROL" },
                    new Model{ Id = 49,
                    MakeId = 11,
                    Name = "SENTRA"},
                    new Model{ Id = 50,
                    MakeId = 12,
                    Name = "TERRACAN" },
                    new Model{ Id = 51,
                    MakeId = 12,
                    Name = "KONA" },
                    new Model{Id = 52,
                    MakeId = 12,
                    Name = "GRANDEUR" },
                    new Model{Id = 53,
                    MakeId = 12,
                    Name = "CRETA" },
                    new Model{Id = 54,
                    MakeId = 12,
                    Name = "SONATA" },
                    new Model{ Id = 55,
                    MakeId = 12,
                    Name = "GENESIS"},
                    new Model{ Id = 56,
                    MakeId = 13,
                    Name = "ADAM"},
                    new Model{ Id = 57,
                    MakeId = 13,
                    Name = "ANTARA" },
                    new Model{Id = 58,
                    MakeId = 13,
                    Name = "FRONTERA" },
                    new Model{Id = 59,
                    MakeId = 13,
                    Name = "CORSA" },
                    new Model{ Id = 60,
                    MakeId = 13,
                    Name = "VIVARO" },
                    new Model{ Id = 61,
                    MakeId = 14,
                    Name = "ESPACE" },
                    new Model{ Id = 62,
                    MakeId = 14,
                    Name = "KOLEOS" },
                    new Model{ Id = 63,
                    MakeId = 14,
                    Name = "LATITUDE" },
                    new Model{Id = 64,
                    MakeId = 14,
                    Name = "SANDERO" },
                    new Model{ Id = 65,
                    MakeId = 14,
                    Name = "TALISMAN" },
                    new Model{Id = 66,
                    MakeId = 14,
                    Name = "TWINGO" },
                    new Model{Id = 67,
                    MakeId = 15,
                    Name = "STELLA" },
                    new Model{Id = 68,
                    MakeId = 15,
                    Name = "TRIBECA" },
                    new Model{ Id = 69,
                    MakeId = 15,
                    Name = "ASCENT" },
                    new Model{Id = 70,
                    MakeId = 15,
                    Name = "JUSTY" },
                    new Model{Id = 71,
                    MakeId = 15,
                    Name = "FORESTER" },
                    new Model{Id = 72,
                    MakeId = 16,
                    Name = "CITIGO" },
                    new Model{Id = 73,
                    MakeId = 16,
                    Name = "OCTAVIA" },
                    new Model{Id = 74,
                    MakeId = 16,
                    Name = "ROOMSTER" },
                    new Model{Id = 75,
                    MakeId = 16,
                    Name = "YETI" },
                    new Model{Id = 76,
                    MakeId = 16,
                    Name = "KAMIQ" },
                    new Model{Id = 77,
                    MakeId = 17,
                    Name = "ACCORD" },
                    new Model{Id = 78,
                    MakeId = 17,
                    Name = "FIT" },
                    new Model{Id = 79,
                    MakeId = 17,
                    Name = "PASSPORT" },
                    new Model{Id = 80,
                    MakeId = 17,
                    Name = "PILOT" },
                    new Model{ Id = 81,
                    MakeId = 17,
                    Name = "CR-V" },
                    new Model{Id = 82,
                    MakeId = 18,
                    Name = "C-CROSSER" },
                    new Model{Id = 83,
                    MakeId = 18,
                    Name = "BERLINGO" },
                    new Model{ Id = 84,
                    MakeId = 18,
                    Name = "C4 SEDAN" },
                    new Model{ Id = 85,
                    MakeId = 18,
                    Name = "SPACETOURER" },
                    new Model{Id = 86,
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

                #region TypesCar
                context = scope.ServiceProvider.GetRequiredService<EFDbContext>();
                List<TypeCar> listTypesCar = new List<TypeCar>
                {
                    new TypeCar{ Id = 1,Name = "Passenger"},
                    new TypeCar{ Id = 2,Name = "Crossover"},
                    new TypeCar{ Id = 3,Name = "Truck"},
                    new TypeCar{ Id = 4,Name = "Moto"}
                };

                foreach (var item in listTypesCar)
                {
                    var type_car = context.TypeCars.SingleOrDefault(c => c.Name == item.Name);
                    if (type_car == null)
                    {
                        context.TypeCars.Add(item);
                        context.SaveChanges();
                    }
                }
                #endregion

                #region Car
                context = scope.ServiceProvider.GetRequiredService<EFDbContext>();
                List<Car> listCar = new List<Car>
                {
                    new Car{ Id = 1,TypeId = 1,ModelId = 1,FuelTypeId = 3,Date = DateTime.Now,ColorId = 1,Image = "https://inlviv.in.ua/wp-content/uploads/2018/02/74_main.jpg",Price = 500000},
                    new Car{ Id = 2,TypeId = 1,ModelId = 4,FuelTypeId = 4,Date = DateTime.Now,ColorId = 4,Image = "https://inlviv.in.ua/wp-content/uploads/2018/02/74_main.jpg",Price = 260000},
                    new Car{ Id = 3,TypeId = 1,ModelId = 2,FuelTypeId = 2,Date = DateTime.Now,ColorId = 1,Image = "https://inlviv.in.ua/wp-content/uploads/2018/02/74_main.jpg",Price = 150000},
                    new Car{ Id = 4,TypeId = 1,ModelId = 3,FuelTypeId = 2,Date = DateTime.Now,ColorId = 3,Image = "https://inlviv.in.ua/wp-content/uploads/2018/02/74_main.jpg",Price = 400000},
                    new Car{ Id = 5,TypeId = 1,ModelId = 2,FuelTypeId = 4,Date = DateTime.Now,ColorId = 2,Image = "https://inlviv.in.ua/wp-content/uploads/2018/02/74_main.jpg",Price = 700000}
                };
                foreach (var item in listCar)
                {
                    var car = context.Cars.SingleOrDefault(c => c.Id== item.Id);
                    if (car == null)
                    {
                        context.Cars.Add(item);
                        context.SaveChanges();
                    }
                }
                #endregion

                #region Clients
                context = scope.ServiceProvider.GetRequiredService<EFDbContext>();
                List<Client> listClient = new List<Client>
                {
                    new Client{ Id = 1,Name = "Zahar",Phone = "+380(68)238-80-01",Image = "https://mystatfiles.itstep.org/index.php?view_key=rtILv2awXkYrSQ7WVzOr0G9F1kZwIdRQC03dLrvYiKeqOlHfVfWihS/QG/11CgvGz2Oj7lb/U37S6VWM25ADRgZpjRgGmn2pOd45FJeYozc="},
                    new Client{ Id = 2,Name = "Yuri",Phone = "+380(68)278-55-22",Image = "https://mystatfiles.itstep.org/index.php?view_key=rtILv2awXkYrSQ7WVzOr0G9F1kZwIdRQC03dLrvYiKeqOlHfVfWihS/QG/11CgvGz2Oj7lb/U37S6VWM25ADRgZpjRgGmn2pOd45FJeYozc="},
                    new Client{ Id = 3,Name = "Maxim", Phone = "+380(97)888-15-97",Image = "https://mystatfiles.itstep.org/index.php?view_key=rtILv2awXkYrSQ7WVzOr0G9F1kZwIdRQC03dLrvYiKeqOlHfVfWihS/QG/11CgvGz2Oj7lb/U37S6VWM25ADRgZpjRgGmn2pOd45FJeYozc="}
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