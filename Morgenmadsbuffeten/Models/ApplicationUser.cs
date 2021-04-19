using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Morgenmadsbuffeten.Models
{
    public class ApplicationUser :IdentityUser
    {
        [Required]
        [PersonalData]
        public string Name { get; set; }
        //[PersonalData]
        //public ICollection<??> Reviews { get; set; }
    }
}
