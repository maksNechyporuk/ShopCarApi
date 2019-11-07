using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCarApi.ViewModels
{
    public class ClientVM
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Поле не може бути пустим")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле не може бути пустим")]
        public string Phone { get; set; }
        public string Image { get; set; }
        [Required(ErrorMessage = "Поле не може бути пустим")]
        public string Email { get; set; }

    }
    public class ClientAddVM
    {
        [Required(ErrorMessage = "Поле не може бути пустим")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле не може бути пустим")]
        public string Phone { get; set; }
        public string Image { get; set; }
        [Required(ErrorMessage = "Поле не може бути пустим")]
        public string Email { get; set; }
    }
    public class ClientDeleteVM
    {
        public int Id { get; set; }
    }
}
