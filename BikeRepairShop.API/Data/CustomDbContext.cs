using BikeRepairShop.API.Models;
using Microsoft.DotNet.Scaffolding.Shared.Project;
using Microsoft.EntityFrameworkCore;

namespace BikeRepairShop.API.Data
{
    public class CustomDbContext: DbContext
    {
        public CustomDbContext(DbContextOptions<CustomDbContext> options) : base(options) 
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<BikeBrand> Brands { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<RepairOrder> RepairOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Customer)
                .WithMany(c => c.Bookings)
                .HasForeignKey(b => b.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RepairOrder>()
                .HasOne(ro => ro.Booking)
                .WithMany(b => b.RepairOrders)
                .HasForeignKey(ro => ro.BookingId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RepairOrder>()
                .HasOne(ro => ro.BikeBrand)
                .WithMany()
                .HasForeignKey(ro => ro.BikeBrandId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.Email)
                .IsUnique();
        }
    }
}
