﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreTodo.Models
{
    public class StoreItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int price { get; set; }
    }
}
