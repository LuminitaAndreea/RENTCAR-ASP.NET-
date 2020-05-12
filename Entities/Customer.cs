namespace Rental.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Customer
    {
        public int CustomerID { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string Location { get; set; }

        public int ZIP { get; set; }
    }
}
