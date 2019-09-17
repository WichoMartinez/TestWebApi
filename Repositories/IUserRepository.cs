using StoreApi.Models;
using System.Threading.Tasks;

namespace StoreApi.Repositories
{
    public interface IUserRepository
    {
        Task<User> Authenticate(string username, string password);
    }
}