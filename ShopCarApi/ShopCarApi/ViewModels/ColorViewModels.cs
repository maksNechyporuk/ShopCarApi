using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCarApi.ViewModels
{
    public class ColorVM
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
    public class ColorAddVM
    {
        public string Name { get; set; }
    }
    public class ColorDeleteVM
    {
        public int Id { get; set; }
    }
}
