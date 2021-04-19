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
        public int DateAndNumbersId { get; set; }
        [Required]
        public int RoomNumber { get; set; }
        public int NumbersOfAdults { get; set; }
        public int NumbersOfChildren { get; set; }
    }
}
