using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace PersistenceModel
{
    public static class MemberConfiguration
    {
        public static void Configure(EntityTypeBuilder<Member> endityBuilder)
        {
            endityBuilder.HasKey(x=>x.MemberId);
            endityBuilder.HasOne(x=>x.MemberSelf)
                .WithMany(x=>x.Members)
                .HasForeignKey(x=>x.RecommendedBy)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}