﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class Car
    {
        public int id { get; set; }
        public string name { get; set; }
        public string shortDesc { get; set; }
        public string longDesc { get; set; }
        public string  img { get; set; }
        public decimal price { get; set; }
        public bool isFavourite { get; set; }
        public bool iavailable { get; set; }
        public int categoryID { get; set; }
        public  Category Category { get; set; }
    }
}
