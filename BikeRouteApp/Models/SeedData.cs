using BikeRouteApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BikeRouteApp.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BikeRouteAppContext(
                serviceProvider.GetRequiredService<
                DbContextOptions<BikeRouteAppContext>>()))
            {
                // Look for any movies.
                if (context.BikeRoute.Any())
                {
                    return;   // DB has been seeded
                }
                context.BikeRoute.AddRange(
                    new BikeRoute
                    {
                        Name = "South Shore Drive",
                        ReleaseDate = DateTime.Now,
                        Length = 37,
                        Elevation = 500,
                        Direction = "South East",
                        Description = "Beautiful South Shore Drive",
                        StravaLink = "www.strava.com",
                        MapUrl = "www.google.com"
                    },
                    new BikeRoute
                    {
                        Name = "German Church",
                        ReleaseDate = DateTime.Now,
                        Length = 30,
                        Elevation = 1500,
                        Direction = "South West",
                        Description = "Head South to German Church on Willows Springs",
                        StravaLink = "www.strava.com",
                        MapUrl = "www.google.com"
                    },
                    new BikeRoute
                    {
                        Name = "Shorty to Jerome Huppert Woods",
                        ReleaseDate = DateTime.Now,
                        Length = 14,
                        Elevation = 100,
                        Direction = "North West",
                        Description = "Short 45-er",
                        StravaLink = "www.strava.com",
                        MapUrl = "www.google.com"
                    },
                    new BikeRoute
                    {
                        Name = "North Lake Shore Drive",
                        ReleaseDate = DateTime.Now,
                        Length = 37,
                        Elevation = 500,
                        Direction = "North East",
                        Description = "Beautiful North Lake Shore Drive",
                        StravaLink = "www.strava.com",
                        MapUrl = "www.google.com"
                    }
                );
                context.SaveChanges();
            }
        }


    }
}
