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
                #region Colors
                var context = scope.ServiceProvider.GetRequiredService<EFDbContext>();
                var color = new Colors
                {
                    Id = 1,
                    Name = "Red",
                    R = 255,
                    G = 0,
                    B = 0,
                    A = 1
                };
                context.Colors.Add(color);
                context.SaveChanges();
                color = new Colors
                {
                    Id = 2,
                    Name = "Green",
                    R = 0,
                    G = 115,
                    B = 0,
                    A = 1
                };
                context.Colors.Add(color);
                context.SaveChanges();
                color = new Colors
                {
                    Id = 3,
                    Name = "Dark Blue",
                    R = 0,
                    G = 0,
                    B = 228,
                    A = 1
                };
                context.Colors.Add(color);
                context.SaveChanges();
                color = new Colors
                {
                    Id = 4,
                    Name = "Black",
                    R = 0,
                    G = 0,
                    B = 0,
                    A = 1
                };
                context.Colors.Add(color);
                context.SaveChanges();
                color = new Colors
                {
                    Id = 5,
                    Name = "White",
                    R = 255,
                    G = 255,
                    B = 255,
                    A = 1
                };
                context.Colors.Add(color);
                context.SaveChanges();
                #endregion

                #region FuelType
                context = scope.ServiceProvider.GetRequiredService<EFDbContext>();
                var fuel_type = new FuelType
                {
                    Id = 1,
                    Type = "Electric"
                };
                context.FuelTypes.Add(fuel_type);
                context.SaveChanges();
                fuel_type = new FuelType
                {
                    Id = 2,
                    Type = "Gas"
                };
                context.FuelTypes.Add(fuel_type);
                context.SaveChanges();
                fuel_type = new FuelType
                {
                    Id = 3,
                    Type = "Diesel"
                };
                context.FuelTypes.Add(fuel_type);
                context.SaveChanges();
                fuel_type = new FuelType
                {
                    Id = 4,
                    Type = "Gasoline"
                };
                context.FuelTypes.Add(fuel_type);
                context.SaveChanges();
                #endregion

                #region Make
                context = scope.ServiceProvider.GetRequiredService<EFDbContext>();
                var makes = new Make
                {
                    Id = 1,
                    Name = "BMW"
                };
                context.Makes.Add(makes);
                context.SaveChanges();
                makes = new Make
                {
                    Id = 2,
                    Name = "Mazda"
                };
                context.Makes.Add(makes);
                context.SaveChanges();
                makes = new Make
                {
                    Id = 3,
                    Name = "Audi"
                };
                context.Makes.Add(makes);
                context.SaveChanges();
                makes = new Make
                {
                    Id = 4,
                    Name = "Mersedes-Benz"
                };
                context.Makes.Add(makes);
                context.SaveChanges();
                makes = new Make
                {
                    Id = 5,
                    Name = "Toyota"
                };
                context.Makes.Add(makes);
                context.SaveChanges();
                makes = new Make
                {
                    Id = 6,
                    Name = "Volkswagen"
                };
                context.Makes.Add(makes);
                context.SaveChanges();
                makes = new Make
                {
                    Id = 7,
                    Name = "Chevrolet"
                };
                context.Makes.Add(makes);
                context.SaveChanges();
                makes = new Make
                {
                    Id = 8,
                    Name = "Ford"
                };
                context.Makes.Add(makes);
                context.SaveChanges();
                makes = new Make
                {
                    Id = 9,
                    Name = "Peugeot"
                };
                context.Makes.Add(makes);
                context.SaveChanges();
                makes = new Make
                {
                    Id = 10,
                    Name = "Fiat"
                };
                context.Makes.Add(makes);
                context.SaveChanges();
                makes = new Make
                {
                    Id = 11,
                    Name = "Nissan"
                };
                context.Makes.Add(makes);
                context.SaveChanges();
                makes = new Make
                {
                    Id = 12,
                    Name = "Hyundai"
                };
                context.Makes.Add(makes);
                context.SaveChanges();
                makes = new Make
                {
                    Id = 13,
                    Name = "Opel"
                };
                context.Makes.Add(makes);
                context.SaveChanges();
                makes = new Make
                {
                    Id = 14,
                    Name = "Renault"
                };
                context.Makes.Add(makes);
                context.SaveChanges();
                makes = new Make
                {
                    Id = 15,
                    Name = "Subaru"
                };
                context.Makes.Add(makes);
                context.SaveChanges();
                makes = new Make
                {
                    Id = 16,
                    Name = "Skoda"
                };
                context.Makes.Add(makes);
                context.SaveChanges();
                makes = new Make
                {
                    Id = 17,
                    Name = "Honda"
                };
                context.Makes.Add(makes);
                context.SaveChanges();
                makes = new Make
                {
                    Id = 18,
                    Name = "Citroen"
                };
                context.Makes.Add(makes);
                context.SaveChanges();
                #endregion

                #region Model
                context = scope.ServiceProvider.GetRequiredService<EFDbContext>();
                var models = new Model
                {
                    Id = 1,
                    MakeId = 1,
                    Name = "3-series Coupe"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 2,
                    MakeId = 1,
                    Name = "750iL"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 3,
                    MakeId = 1,
                    Name = "X5"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 4,
                    MakeId = 2,
                    Name = "MX-5"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 5,
                    MakeId = 2,
                    Name = "Tribute"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 6,
                    MakeId = 2,
                    Name = "Axela"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 7,
                    MakeId = 3,
                    Name = "A5"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 8,
                    MakeId = 3,
                    Name = "Q2"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 9,
                    MakeId = 3,
                    Name = "S3"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 10,
                    MakeId = 3,
                    Name = "TTS"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 11,
                    MakeId = 4,
                    Name = "AMG GT S"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 12,
                    MakeId = 4,
                    Name = "A SEDAN"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 13,
                    MakeId = 4,
                    Name = "V-CLASS"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 14,
                    MakeId = 4,
                    Name = "M-CLASS"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 15,
                    MakeId = 4,
                    Name = "S-CLASS CABRIOLET"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 16,
                    MakeId = 5,
                    Name = "GT 86"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 17,
                    MakeId = 5,
                    Name = "SIENNA"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 18,
                    MakeId = 5,
                    Name = "CAMRY"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 19,
                    MakeId = 6,
                    Name = "GOLF"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 20,
                    MakeId = 6,
                    Name = "ATLAS"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 21,
                    MakeId = 6,
                    Name = "PASSAT"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 22,
                    MakeId = 6,
                    Name = "TOURAN"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 23,
                    MakeId = 7,
                    Name = "COBALT"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 24,
                    MakeId = 7,
                    Name = "CORVETTE"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 25,
                    MakeId = 7,
                    Name = "VIVA"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 26,
                    MakeId = 7,
                    Name = "ORLANDO"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 27,
                    MakeId = 7,
                    Name = "ALERO"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 28,
                    MakeId = 8,
                    Name = "EXPLORER"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 29,
                    MakeId = 8,
                    Name = "FIESTA"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 30,
                    MakeId = 8,
                    Name = "FOCUS RS"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 31,
                    MakeId = 8,
                    Name = "MUSTANG"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 32,
                    MakeId = 8,
                    Name = "TAURUS"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 33,
                    MakeId = 9,
                    Name = "EXPERT"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 34,
                    MakeId = 9,
                    Name = "308 GT"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 35,
                    MakeId = 9,
                    Name = "PEUGEOT 1007"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 36,
                    MakeId = 9,
                    Name = "208"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 37,
                    MakeId = 9,
                    Name = "TRAVELLER"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 38,
                    MakeId = 9,
                    Name = "508 RXH"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 39,
                    MakeId = 10,
                    Name = "BRAVO"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 40,
                    MakeId = 10,
                    Name = "MOBI"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 41,
                    MakeId = 10,
                    Name = "PANDA"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 42,
                    MakeId = 10,
                    Name = "TIPO"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 43,
                    MakeId = 10,
                    Name = "TORO"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 44,
                    MakeId = 10,
                    Name = "LINEA"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 45,
                    MakeId = 11,
                    Name = "LAFESTA"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 46,
                    MakeId = 11,
                    Name = "GT-R"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 47,
                    MakeId = 11,
                    Name = "ALMERA"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 48,
                    MakeId = 11,
                    Name = " PATROL"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 49,
                    MakeId = 11,
                    Name = "SENTRA"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 50,
                    MakeId = 12,
                    Name = "TERRACAN"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 51,
                    MakeId = 12,
                    Name = "KONA"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 52,
                    MakeId = 12,
                    Name = " GRANDEUR"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 53,
                    MakeId = 12,
                    Name = "CRETA"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 54,
                    MakeId = 12,
                    Name = "SONATA"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 55,
                    MakeId = 12,
                    Name = "GENESIS"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 56,
                    MakeId = 13,
                    Name = "ADAM"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 57,
                    MakeId = 13,
                    Name = "ANTARA"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 58,
                    MakeId = 13,
                    Name = "FRONTERA"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 59,
                    MakeId = 13,
                    Name = "CORSA"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 60,
                    MakeId = 13,
                    Name = "VIVARO"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 61,
                    MakeId = 14,
                    Name = "ESPACE"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 62,
                    MakeId = 14,
                    Name = "KOLEOS"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 63,
                    MakeId = 14,
                    Name = "LATITUDE"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 64,
                    MakeId = 14,
                    Name = "SANDERO"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 65,
                    MakeId = 14,
                    Name = "TALISMAN"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 66,
                    MakeId = 14,
                    Name = "TWINGO"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 67,
                    MakeId = 15,
                    Name = "STELLA"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 68,
                    MakeId = 15,
                    Name = "TRIBECA"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 69,
                    MakeId = 15,
                    Name = "ASCENT"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 70,
                    MakeId = 15,
                    Name = "JUSTY"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 71,
                    MakeId = 15,
                    Name = "FORESTER"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 72,
                    MakeId = 16,
                    Name = "CITIGO"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 73,
                    MakeId = 16,
                    Name = "OCTAVIA"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 74,
                    MakeId = 16,
                    Name = "ROOMSTER"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 75,
                    MakeId = 16,
                    Name = "YETI"
                };
                context.Models.Add(models);
                context.SaveChanges();
                 models = new Model
                {
                    Id = 76,
                    MakeId = 16,
                    Name = "KAMIQ"
                };
                context.Models.Add(models);
                context.SaveChanges();
                 models = new Model
                {
                    Id = 77,
                    MakeId = 17,
                    Name = "ACCORD"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 78,
                    MakeId = 17,
                    Name = "FIT"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 79,
                    MakeId = 17,
                    Name = "PASSPORT"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 80,
                    MakeId = 17,
                    Name = "PILOT"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 81,
                    MakeId = 17,
                    Name = "CR-V"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 82,
                    MakeId = 18,
                    Name = "C-CROSSER"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 83,
                    MakeId = 18,
                    Name = "BERLINGO"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 84,
                    MakeId = 18,
                    Name = "C4 SEDAN"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 85,
                    MakeId = 18,
                    Name = "SPACETOURER"
                };
                context.Models.Add(models);
                context.SaveChanges();
                models = new Model
                {
                    Id = 86,
                    MakeId = 18,
                    Name = "C6"
                };
                context.Models.Add(models);
                context.SaveChanges();
                #endregion

                #region TypesCar
                context = scope.ServiceProvider.GetRequiredService<EFDbContext>();
                var car_types = new TypeCar
                {
                    Id = 1,
                    Name = "Passenger"
                };
                context.TypeCars.Add(car_types);
                context.SaveChanges();
                car_types = new TypeCar
                {
                    Id = 2,
                    Name = "Crossover"
                };
                context.TypeCars.Add(car_types);
                context.SaveChanges();
                car_types = new TypeCar
                {
                    Id = 3,
                    Name = "Truck"
                };
                context.TypeCars.Add(car_types);
                context.SaveChanges();
                car_types = new TypeCar
                {
                    Id = 4,
                    Name = "Moto"
                };
                context.TypeCars.Add(car_types);
                context.SaveChanges();
                #endregion

                #region Car
                context = scope.ServiceProvider.GetRequiredService<EFDbContext>();
                var cars = new Car
                {
                    Id = 1,
                    TypeId = 1,
                    ModelId = 1,
                    FuelTypeId = 3,
                    Date = DateTime.Now,
                    ColorId = 1,
                    Image = "https://inlviv.in.ua/wp-content/uploads/2018/02/74_main.jpg",
                    Price = 50000
                };
                context.Cars.Add(cars);
                context.SaveChanges();
                cars = new Car
                {
                    Id = 2,
                    TypeId = 1,
                    ModelId = 4,
                    Date = DateTime.Now,
                    FuelTypeId = 4,
                    ColorId = 4,
                    Price = 26000
                };
                context.Cars.Add(cars);
                context.SaveChanges();
                cars = new Car
                {
                    Id = 3,
                    TypeId = 1,
                    ModelId = 2,
                    FuelTypeId = 2,
                    Date = DateTime.Now,
                    ColorId = 1,
                    Price = 15000
                };
                context.Cars.Add(cars);
                context.SaveChanges();
                cars = new Car
                {
                    Id = 4,
                    TypeId = 1,
                    ModelId = 3,
                    FuelTypeId = 2,
                    Date = DateTime.Now,
                    ColorId = 3,
                    Price = 40000
                };
                context.Cars.Add(cars);
                context.SaveChanges();
                cars = new Car
                {
                    Id = 5,
                    TypeId = 1,
                    ModelId = 2,
                    FuelTypeId = 4,
                    ColorId = 3,
                    Date = DateTime.Now,
                    Price = 10000
                };
                context.Cars.Add(cars);
                context.SaveChanges();
                #endregion
            }
        }
    }
}