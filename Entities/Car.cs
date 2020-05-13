namespace Rental.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Car
    {
        public int CarID { get; set; }

        public string Plate { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public string PricePerDay { get; set; }
        public string Location { get; set; }
    }
}
