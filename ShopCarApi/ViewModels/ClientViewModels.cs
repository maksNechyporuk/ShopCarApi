using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCarApi.ViewModels
{
    public class ClientVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Image { get; set; }

        public string Email { get; set; }

    }
    public class ClientAddVM
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
    }
    public class ClientDeleteVM
    {
        public int Id { get; set; }
    }
}
