using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Mission6_cvzh7.Models
{
    public class MovieFormContext : DbContext
    {
        // Constructor
          
        public MovieFormContext(DbContextOptions<MovieFormContext> options) : base (options)
        {
            // Leave blank for now
        }

        public DbSet<ApplicationResponse> responses { get; set; }

        public DbSet<Category> Categories { get; set; }

        // Add the preset data to the movie database when it is built for the first time

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName="Action/Adventure"},
                new Category { CategoryID = 2, CategoryName= "Mystery/Thriller"},
                new Category { CategoryID = 3, CategoryName="Comedy/Family"}

                );
            mb.Entity<ApplicationResponse>().HasData(

                new ApplicationResponse
                {
                    MovieID = 1,
                    CategoryID = 1,
                    Title = "Tenet",
                    Year = 2020,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false

                },
                new ApplicationResponse
                {
                    MovieID = 2,
                    CategoryID = 2,
                    Title = "Knives Out",
                    Year = 2019,
                    Director = "Rian Johnson",
                    Rating = "PG-13",
                    Edited = false
                },
                new ApplicationResponse
                {
                    MovieID = 3,
                    CategoryID = 3,
                    Title = "Cars",
                    Year = 2006,
                    Director = "John Lasseter",
                    Rating = "G",
                    Edited = false
                }
                );

        }

    }
}
