using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental.Models
{
    class Reservation
    {
        [Key]public int UserId { get; set; }
        [Key]public int CarID { get; set; }
        public string Plate { get; set; }
        public int CustomerID { get; set; }
        public int ReservStatsID{get;set;}
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public string CouponCode { get; set; }
        
        
    }
}
