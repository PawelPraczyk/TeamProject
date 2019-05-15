﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeBudget.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public ApplicationUser User { get; set; }
    }
}