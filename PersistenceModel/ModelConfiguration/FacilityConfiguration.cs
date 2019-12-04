using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PersistenceModel
{
    public static class FacilityConfiguration
    {
        public static void Configure(EntityTypeBuilder<Facility> endityBuilder)
        {
            endityBuilder.HasKey(x=>x.FacId);
        }
    }
}