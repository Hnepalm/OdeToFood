using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OdeToFood.Core
{
    public class Restaurant
    {
        [Required, StringLength(80)]
        public String Name { get; set; }
        public int Id { get; set; }
        [Required, StringLength(250)]
        public String Location { get; set; }
        public CuisineType Cousine { get; set; }
    }
}
