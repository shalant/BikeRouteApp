using Microsoft.AspNetCore.Mvc.Rendering;

namespace BikeRouteApp.Models
{
    public class BikeRouteLengthViewModel
    {
        public List<BikeRoute>? BikeRoutes { get; set; }
        public SelectList? Lengths { get; set; }
        public string? BikeRouteLength { get; set; }
        public string? SearchString { get; set; }
    }
}
