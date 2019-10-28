﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCarApi.Entities
{
    [Table("tblCars")]
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string UniqueName { get; set; }

        public string Image { get; set; }

        [Required]
        public int Price { get; set; }

        public virtual ICollection<Filter> Filtres { get; set; }


    }
}