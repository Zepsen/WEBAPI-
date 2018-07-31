using System.Threading.Tasks;
using DAL.Repositories;
using Serilog;

namespace DAL
{
    public class RepoWorker
    {
        private readonly ApplicationContext _db;
        private UsersRepository _usersRepository;

        public RepoWorker()
        {
            _db = new ApplicationContext();
        }

        public UsersRepository UsersRepository => _usersRepository ?? (_usersRepository = new UsersRepository(_db));


        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
