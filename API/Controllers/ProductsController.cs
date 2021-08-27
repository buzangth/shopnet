using Microsoft.AspNetCore.Mvc;
using Core.Entities;
using System.Threading.Tasks;

using System.Collections.Generic;
using Core.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;

        public ProductsController(IProductRepository repo)
        {
             _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _repo.GetProductsAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _repo.GetProductByIdAsync(id);
        }

        [HttpPost]
        public async Task<Product> AppProduct(Product product){
            return await _repo.AddProductAsync(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrand(){
            return Ok(await _repo.GetProductBrandsAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductType(){
            return Ok(await _repo.GetProductTypesAsync());
        }
        
    }
}