namespace Hotel_Guest_WebService
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class GuestBookingViewContext : DbContext
    {
        public GuestBookingViewContext()
            : base("name=GuestBookingViewContext")
        {
        }

        public virtual DbSet<GuestNameAndNoOfBookings> GuestNameAndNoOfBookings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GuestNameAndNoOfBookings>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
