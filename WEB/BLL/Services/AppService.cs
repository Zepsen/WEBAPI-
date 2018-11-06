using DAL;

namespace BLL.Services
{
    public class AppService
    {
        public readonly RepoWorker Repo;

        public AppService(ApplicationContext context)
        {
            Repo = new RepoWorker(context);
        }
    }
}