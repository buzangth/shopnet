using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithSpec : BaseSpecification<Product>
    {
        public ProductWithSpec()
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }

        public ProductWithSpec(int id) : base(x => x.Id == id)
        {
           AddInclude(x => x.ProductBrand);
           AddInclude(x => x.ProductType); 
        }
    }
}