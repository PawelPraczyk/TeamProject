using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.ComponentModel.DataAnnotations;

namespace HomeBudget.Models
{
    public class CatColor
    {
        public int Id { get; set; }

        //[Required]
        public string Color { get; set; }
    }
}