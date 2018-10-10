using System;
using System.Threading.Tasks;
using DAL.Repositories;

namespace DAL
{
    public class RepoWorker : IDisposable
    {
        private readonly ApplicationContext _db;
        private bool _disposed;
        
        public RepoWorker(ApplicationContext context)
        {
            _db = context;
        }
        
        private CompaniesRepository _companiesRepository;
        
        private UsersRepository _usersRepository;

        public CompaniesRepository CompaniesRepository => _companiesRepository ?? (_companiesRepository = new CompaniesRepository(_db));

        public UsersRepository UsersRepository => _usersRepository ?? (_usersRepository = new UsersRepository(_db));

        

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _db.Dispose();
            _disposed = true;
        }

        ~RepoWorker()
        {
            Dispose(false);
        }
    }
}
