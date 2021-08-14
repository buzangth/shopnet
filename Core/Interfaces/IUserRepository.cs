using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int Id);

        Task<IReadOnlyList<User>> GetUsersAsync();

        Task<User> AddUserAsync(User user);


    }
}