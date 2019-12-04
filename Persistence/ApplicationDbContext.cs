using System;
using Microsoft.EntityFrameworkCore;
using PersitanceModel;

namespace Persitance
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("efcore");
            MemberConfiguration.Configure(modelBuilder.Entity<Member>());
            FacilityConfiguration.Configure(modelBuilder.Entity<Facility>());
            BookingConfiguration.Configure(modelBuilder.Entity<Booking>());
            base.OnModelCreating(modelBuilder);
        }
    }
}
