using ShopCarApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCarApi.ViewModels
{
    public class CarVM
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public ColorVM Color { get; set; }
        public ModelVM Model { get; set; }
        public FuelTypeVM Fuel_type { get; set; }
        public TypeVM Type_car { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
    }
    public class CarAddVM
    {
        public DateTime Date { get; set; }
        public ColorVM Color { get; set; }
        public ModelVM Model { get; set; }
        public FuelTypeVM Fuel_type { get; set; }
        public TypeVM Type_car { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
    }
    public class CarDeleteVM
    {
        public int Id { get; set; }
    }
}
