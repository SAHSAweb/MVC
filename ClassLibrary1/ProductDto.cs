﻿using MVC.Model.Enams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Model
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Products Category { get; set; }
    }
}
