﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApi.Models
{
    public class Category
    {
        [Key]
        public long Id { get; set; }
        public string Description { get; set; }
    }
}
