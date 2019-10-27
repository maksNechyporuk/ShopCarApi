using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCarApi.ViewModels
{
    public class FValueViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class FNameViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<FValueViewModel> Children { get; set; }
    }

    public class FilterVM
    {
        public int Id { get; set; }
        public string Name { get; set; }     
    }
    public class FilterAddVM
    {
        public DateTime Date { get; set; }
        public ColorVM Color { get; set; }
        public ModelVM Model { get; set; }
        public FuelTypeVM Fuel_type { get; set; }
        public TypeVM Type_car { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
    }
    public class FilterDeleteVM
    {
        public int Id { get; set; }
    }
}
