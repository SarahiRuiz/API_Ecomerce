using API_Ecommerce.Data;
using API_Ecommerce.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API_Ecommerce.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProductsController(StoreContext context) : ControllerBase
    {
        [HttpGet] // api/products
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            return context.Products.ToList();
        }
        [HttpGet("{id}")] //api/products/1
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await context.Products.FindAsync(id);
            if (product == null) return NotFound();
            return product;
        }
    }
}
