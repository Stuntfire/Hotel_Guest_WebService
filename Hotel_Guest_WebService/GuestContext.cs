namespace Hotel_Guest_WebService
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class GuestContext : DbContext
    {
        public GuestContext()
            : base("name=GuestContext")
        {
        }

        public virtual DbSet<Guest> Guest { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guest>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Guest>()
                .Property(e => e.Address)
                .IsUnicode(false);
        }
    }
}
