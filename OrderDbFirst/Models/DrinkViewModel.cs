using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderDbFirst.Models
{
    public class DrinkViewModel
    {
        public int DrinkId { get; set; }
        
        public Drink Drink { get; set; }

        public IEnumerable<Size> Sizes { get; set; }
    }
}