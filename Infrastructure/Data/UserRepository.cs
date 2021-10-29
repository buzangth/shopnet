using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Infrastructure.Data
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(StoreContext context) : base(context)
        {
        }
    }
}