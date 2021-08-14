using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Migrations
{
    public class UserRepository : IUserRepository
    {

        private readonly StoreContext _context;

        public UserRepository(StoreContext context)
        {
            _context = context;

        }
        public async Task<User> AddUserAsync(User user)
        {
            var results = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return results.Entity;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
             return await _context.Users.FindAsync(id);
        }

        public async Task<IReadOnlyList<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}