using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BikeRouteApp.Models;

namespace BikeRouteApp.Data
{
    public class BikeRouteAppContext : DbContext
    {
        public BikeRouteAppContext (DbContextOptions<BikeRouteAppContext> options)
            : base(options)
        {
        }

        public DbSet<BikeRouteApp.Models.BikeRoute> BikeRoute { get; set; } = default!;
    }
}
