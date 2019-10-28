﻿using ShopCarApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ShopCarApi.ViewModels.CarComparer;

namespace ShopCarApi.ViewModels
{
   public class CarComparer : IEqualityComparer<CarGetVM>
    {
        // Products are equal if their names and product numbers are equal.

        bool IEqualityComparer<CarGetVM>.Equals(CarGetVM x, CarGetVM y)
        {
            //Check whether the compared objects reference the same data.
            if (Object.ReferenceEquals(x, y)) return true;

            //Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            //Check whether the products' properties are equal.
            return x.Id == y.Id;
        }

        int IEqualityComparer<CarGetVM>.GetHashCode(CarGetVM obj)
        { //Check whether the object is null
            if (Object.ReferenceEquals(obj, null)) return 0;

            //Get hash code for the Name field if it is not null.
            int hashProductName = obj.Id == null ? 0 : obj.Id.GetHashCode();

            //Get hash code for the Code field.
            int hashProductCode = obj.Id.GetHashCode();

            //Calculate the hash code for the product.
            return hashProductName ^ hashProductCode;
        }
    }
        public class CarGetVM
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public List<FNameGetViewModel> filters { get; set; }
    }
    public class CarVM
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public FNameViewModel filter { get; set; }
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
