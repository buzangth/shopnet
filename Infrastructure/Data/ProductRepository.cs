using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Infrastructure.Data
{
    public class ProductRepository : GenericRepository<Product>
    {
        public ProductRepository(StoreContext context) : base(context)
        {
        }
    }
}