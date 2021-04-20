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
        public int DataFromReceptionId { get; set; }
        [Required]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }
        [Display(Name = "Adults")]
        public int NumbersOfAdults { get; set; }
        [Display(Name = "Children")]
        public int NumbersOfChildren { get; set; }

    }
}
