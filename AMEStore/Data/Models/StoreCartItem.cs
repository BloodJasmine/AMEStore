﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMEStore.Data.Models
{
    public class StoreCartItem
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Price { get; set; }
        public string StoreCartId { get; set; } 
    }
}
