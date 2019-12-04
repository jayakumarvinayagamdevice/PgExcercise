using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace PersitanceModel
{
    public static class BookingConfiguration
    {
        public static void Configure(EntityTypeBuilder<Booking> endityBuilder)
        {
            endityBuilder.HasKey(x=>new {x.FacId, x.MemId });
            
            endityBuilder.HasOne(x=>x.Facility)
                .WithMany(x=>x.Bookings)
                .HasForeignKey(x=>x.FacId);
                
            endityBuilder.HasOne(x=>x.Member)
                .WithMany(x=>x.Bookings)
                .HasForeignKey(x=>x.MemId);
        }
    }
}