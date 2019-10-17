using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCarApi.ViewModels
{

    public class UserVM
    {
        public string Name { get; set; }

        public string Email { get; set; }

    }

    public class UserLoginVM
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }

    public class UserRegisterVM
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
