using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HomeBudget.Models
{
    public class JqDate
    {
        [Required]
        [Display(Name = "Select Date")]
        public DateTime JoinDate { get; set; }
    }
}