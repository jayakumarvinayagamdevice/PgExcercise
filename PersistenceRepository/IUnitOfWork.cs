using PersistenceModel;

namespace PersistenceRepository
{
    public interface IUnitOfWork
    {
        IRepository<Member> Members { get;}
        void Commit();
    }
}