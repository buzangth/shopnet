using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers


{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
       private readonly IUserRepository _repo;

        public UsersController(IUserRepository repo)
        {
             _repo = repo;
        }
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var users = await _repo.GetUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            return await _repo.GetUserByIdAsync(id);
        }
        

        [HttpPost]
        public async Task<User> AppUser(User user){
            return await _repo.AddUserAsync(user);
        }

        
    }
}