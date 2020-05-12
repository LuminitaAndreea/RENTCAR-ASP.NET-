using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental.Models
{
    class Cupon
    {
        [Key] public string CouponCode { set; get; }
        public string Description { get; set; }
        public decimal Discount { get; set; }
    }
}
