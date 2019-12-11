using PersistenceModel;
using Persistence;
namespace PersistenceRepository
{
    public class MemberRepository : BaseRepository<Member>, IRepository<Member>
    {
        public MemberRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}