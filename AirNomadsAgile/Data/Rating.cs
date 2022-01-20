using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AirNomadsAgile.Data
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }
        [Range(0,5)]
        public double StarRating { get; set; }
    }
}