using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Morgenmadsbuffeten.Models
{
    public class DataFromReception
    {
        [Key]
        public int DateAndNumbersAndRoomnumberId { get; set; }
        public DateTime Date { get; set; }
        public int NumberOfGuests { get; set; }

    }
}
