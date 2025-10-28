using ecommerce.Data.Interfaces;
using ecommerce.Data.Models;
using System.Threading.Tasks;

namespace ecommerce.Data.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;

        public LoginService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> LoginAsync(string email, string password)
        {
            var user = await _userRepository.LoginAsync(email, password);
            return user;
        }
    }
}
