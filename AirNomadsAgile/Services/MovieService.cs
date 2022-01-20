﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AirNomadsAgile.Data;
using AirNomadsAgile.Models.Movies;

namespace AirNomadsAgile.Services
{
    public class MovieService
    {
        private readonly Guid _userId;

        public MovieService(Guid userId)
        {
            _userId = userId;
        }
        // CRUD methods go below

        // Read
        public IEnumerable<MovieListItem> GetAllMovies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var movieList = ctx.Movies.Select(m => new MovieListItem()
                {
                    Id = m.Id,
                    Title = m.Title,
                }).ToList();
                return movieList;
            }
        }

        public MovieGetById GetMovieById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Movies
                        .Single(e => e.Id == id);
                return
                    new MovieGetById
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        Description = entity.Description
                    };
            };
        }
    }
}