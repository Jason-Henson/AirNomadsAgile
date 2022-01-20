using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AirNomadsAgile.Models.Movies
{
    public class MovieEdit
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
    }
}