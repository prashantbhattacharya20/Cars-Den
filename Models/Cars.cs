using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Cars_Den.Models
{

    public class Cars
    {
        [Key]
        public int CarID { get; set; }
        [Required]
        public required string Model { get; set; }
        [Required]
        public required int MakeYear { get; set; }

        [Required]
        public required string Seaters { get; set; }

        [Required]
        public required string FuelType { get; set; }

        [Required]
        public required decimal Mileage { get; set; }
        
        [Required]
        public required string Transmission { get; set; }

        [Required]
        public required decimal RentPerDay { get; set; }

        [Required]
        public required string ImageUrl { get; set; }
    }
}