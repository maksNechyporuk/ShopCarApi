using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCarApi.ViewModels
{
    public class TypeVM
    {
        public int Id { get; set; }

        public string Name { get; set; }      
    }
    public class TypeAddVM
    {
        public string Name { get; set; }
    }
    public class TypeDeleteVM
    {
        public int Id { get; set; }
    }
}
