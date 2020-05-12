using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental.Models
{
    class User
    {
        [Key] public int UserID { get; set; }
        public string Password { get; set; }
        public byte Enabled{get;set;}
        public int RoleID { get; set; }
    }
}
