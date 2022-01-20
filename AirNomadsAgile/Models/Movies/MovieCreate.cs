using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AirNomadsAgile.Models.Movies
{
    // View Model or Data Transfer Object aka DTO 
    public class MovieCreate
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public int? RatingId { get; set; }
    }
}