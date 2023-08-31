using System.ComponentModel.DataAnnotations;

namespace BikeRouteApp.Models
{
    public class BikeRoute
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        
        [Required]
        [Range(1, 120)]
        public int? Length { get; set; }

        public int? Elevation { get; set; }
        public string? Direction { get; set; }
        public string? Description { get; set; }
        public string? StravaLink { get; set; }
        public string? MapUrl { get; set; }
    }
}
