using gsnet.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gsnet.Services
{
    public interface IUserService
    {
        Task CreateUserAsync(User user);
        Task<User> GetUserByIdAsync(string userId);
        Task<User> GetUserByEmailAsync(string email);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(string userId);
        Task<string?> GetAllUsersAsync();
    }
}
