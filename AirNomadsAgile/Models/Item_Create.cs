using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AirNomadsAgile.Models
{
    public class Item_Create
    {
        [Required]
        public string Name { get; set; }
        public string Rating { get; set; }
        public string Description { get; set; }
    }
}