using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Services
{
    public interface IAuthService
    {
        Task<Users> AuthenticateUserAsync(string username, string password);
    }

    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Users> AuthenticateUserAsync(string login, string password)
        {
            var user = await _userRepository.GetUserByLoginAndPasswordAsync(login, password);
            return user;
        }
    }
}
