using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCarApi.ViewModels
{
    public class FuelTypeVM
    {
        public int Id { get; set; }

        public string Type { get; set; }     

    }
    public class FuelTypeAddVM
    {
        public string Type { get; set; }
     
    }
    public class FuelTypeDeleteVM
    {
        public int Id { get; set; }
    }
}
