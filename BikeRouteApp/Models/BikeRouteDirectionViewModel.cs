using Microsoft.AspNetCore.Mvc.Rendering;

namespace BikeRouteApp.Models
{
    public class BikeRouteDirectionViewModel
    {
        public List<BikeRoute>? BikeRoutes { get; set; }
        public SelectList? Directions { get; set; }
        public string? BikeRouteDirection { get; set; }
        public string? SearchString { get; set; }
    }
}
