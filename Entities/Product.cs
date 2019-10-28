using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_App.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public int Capacity { get; set; }
        public double Price { get; set; }
    }
}