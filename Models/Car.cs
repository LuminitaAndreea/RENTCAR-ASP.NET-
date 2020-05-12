using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rental.Models
{
    class Car
    {
        [Key] public int CarID { get; set; }
        public string Plate { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string PricePerDay {get;set;}
       
    }
}
