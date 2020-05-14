namespace Rental.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Reservation
    {
        public int ReservationId { get; set; }
        public int UserId { get; set; }

        public int CarID { get; set; }

        public int CustomerID { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Location { get; set; }

        public string CouponCode { get; set; }

        public string Plate { get; set; }
    }
}
