using System;
using Persistence;
using PersistenceModel;
namespace PersistenceRepository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ApplicationDbContext _dbContext;
        private BaseRepository<Member> _members;
        private BaseRepository<Facility> _facilities;
        private BaseRepository<Booking> _booking;
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IRepository<Member> Members => _members ?? (_members = new BaseRepository<Member>(_dbContext));
        public IRepository<Facility> Facilities => _facilities ?? (_facilities = new BaseRepository<Facility>(_dbContext));

        public IRepository<Booking> Booking => _booking ?? (_booking = new BaseRepository<Booking>(_dbContext));

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing) 
            {
                // free managed resources
            }
            // free native resources if there are any.
        }
    }
}