using ecommerce.Data.Models;
using System.Threading.Tasks;

namespace ecommerce.Data.Interfaces
{
    public interface ILoginService
    {
        Task<User?> LoginAsync(string email, string password);
    }
}
