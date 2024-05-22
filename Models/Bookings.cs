using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cars_Den.Models
{

    public class Bookings
    {
        [Key]
        public int BookingID { get; set; }

        [ForeignKey("Cars")]
        public int CarID { get; set; }

        [ForeignKey("Users")]
        public int UserID { get; set; }

        [Required]
        public required DateOnly StartDate { get; set; }

        [Required]
        public required DateOnly EndDate { get; set; }

        public decimal TotalPrice { get; set; }

        public virtual Cars Cars { get; set; }

        public virtual Users Users { get; set; }
    }
}