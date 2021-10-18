using Microsoft.AspNetCore.Mvc;
using Core.Entities;
using System.Threading.Tasks;

using System.Collections.Generic;
using Core.Interfaces;
using Core.Specifications;
using API.Dtos;
using System.Linq;

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
        public async Task<ActionResult<List<ProductDto>>> GetProducts()
        {

            var spec = new ProductWithSpec();
            var products = await _productsRepo.ListAsync(spec);

            return products.Select(product => new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                PictureUrl = product.PictureUrl,
                ProductBrand = product.ProductBrand.Name,
                ProductType = product.ProductType.Name
            }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var spec = new ProductWithSpec(id);
            var product = await _productsRepo.GetEntityWithSpec(spec);

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                PictureUrl = product.PictureUrl,
                ProductBrand = product.ProductBrand.Name,
                ProductType = product.ProductType.Name
                
            };

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