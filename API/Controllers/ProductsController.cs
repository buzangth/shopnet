using Microsoft.AspNetCore.Mvc;
using Core.Entities;
using System.Threading.Tasks;

using System.Collections.Generic;
using Core.Interfaces;
using Core.Specifications;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTYpeRepo;

        public ProductsController(IGenericRepository<Product> productsRepo,
        IGenericRepository<ProductBrand> productBrandRepo,
        IGenericRepository<ProductType> productTYpeRepo)
        {
             _productsRepo = productsRepo;
             _productBrandRepo = productBrandRepo;
             _productTYpeRepo = productTYpeRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {

            var spec = new ProductWithSpec();
            var products = await _productsRepo.ListAsync(spec);

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var spec = new ProductWithSpec(id);
            return await _productsRepo.GetEntityWithSpec(spec);
        }

        [HttpPost]
        // public async Task<Product> AppProduct(Product product){
        //   //  return await _productsRepo.AddProductAsync(product);
        // }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrand(){
            return Ok(await _productBrandRepo.ListAllAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductType(){
            return Ok(await _productTYpeRepo.ListAllAsync());
        }
        
    }
}