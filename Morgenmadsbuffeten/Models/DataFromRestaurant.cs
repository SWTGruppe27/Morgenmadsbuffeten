using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Morgenmadsbuffeten.Models
{
    public class DataFromRestaurant
    {
        [Key]
        public int DataFromRestaurantId { get; set; }
        [Required]
        [Display(Name = "Room number")]
        public int RoomNumber { get; set; }
        [Display(Name = "Adults")]
        public int NumbersOfAdults { get; set; }
        [Display(Name = "Children")]
        public int NumbersOfChildren { get; set; }
    }
}
