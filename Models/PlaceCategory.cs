using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StoreApi.Models
{
    public class PlaceCategory
    {
        [Key]
        public long Id { get; set; }
        public long PlaceId { get; set; }
        public long CategoryId { get; set; }
    }
}
