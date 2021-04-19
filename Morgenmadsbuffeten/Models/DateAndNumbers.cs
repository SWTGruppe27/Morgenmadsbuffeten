using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Morgenmadsbuffeten.Models
{
    public class DateAndNumbers
    {
        public int DateAndNumbersId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public int NumbersOfAdults { get; set; }
        public int NumbersOfChildren { get; set; }
    }
}
