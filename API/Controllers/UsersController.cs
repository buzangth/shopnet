using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers


{
    
    public class UsersController : BaseApiController
    {
       private readonly IGenericRepository<User> _userRepo;

        public UsersController(IGenericRepository<User> userRepo)
        {
             _userRepo = userRepo;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<User>>>  GetUsers()
        {
            var users = await _userRepo.ListAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userRepo.GetByIdAsync(id);
            return Ok(user);
        }
        

        // [HttpPost]
        // public async Task<User> AppUser(User user){
        //     return await _repo.AddUserAsync(user);
        // }

        
    }
}