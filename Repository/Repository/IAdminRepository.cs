using Repository.Models;

namespace Repository.Repository
{
    public interface IAdminRepository
    {
        public Admin Login(string username, string password);
    }
}
