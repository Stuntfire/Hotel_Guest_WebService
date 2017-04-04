namespace Hotel_Guest_WebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GuestNameAndNoOfBookings
    {
        [Key]
        [StringLength(30)]
        public string Name { get; set; }

        public int? NoOfBookings { get; set; }
    }
}
