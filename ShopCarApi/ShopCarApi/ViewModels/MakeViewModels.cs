﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCarApi.ViewModels
{

    public class MakeVM
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
    public class MakeAddVM
    {
        public string Name { get; set; }
    }
    public class MakeDeleteVM
    {
        public int Id { get; set; }
    }


}