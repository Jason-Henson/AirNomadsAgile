using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirNomadsAgile.Models.Movies
{
    public class MovieGetById
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public object Description { get; internal set; }
    }
}