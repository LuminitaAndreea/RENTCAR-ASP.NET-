﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental.Models
{
    class ReservationStatus
    {
     [Key] public int ReservStatsID { get; set; }
        public string Name {get;set;}
        public string Description { get; set; }
    }
}
