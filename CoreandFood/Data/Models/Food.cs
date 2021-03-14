using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreandFood.Data.Models
{
    public class Food
    {
        
        public int FoodID { get; set; }

        [Required(ErrorMessage = "Food name did not empty")]
        public string Name { get; set; }
        public string Description { get; set; }

        [Range(0,10000,ErrorMessage ="Please only enter 0-10.000 Price")]
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public int Stock { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category  { get; set; }
    }
}
