﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApi.Models
{
    public class VwPlacesCategory
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Categories { get; set; }
    }
}