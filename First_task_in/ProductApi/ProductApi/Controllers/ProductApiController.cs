using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductContext _context;

        public ProductController(ProductContext context)
        {
            _context = context;
        }

        // In your ProductController

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            // Correctly executing the function without causing ambiguity
            return await _context.Products.FromSqlRaw("SELECT * FROM get_products()").ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            // Execute the function to get a specific product by Id
            return await _context.Products.FromSqlRaw("SELECT * FROM get_products() WHERE \"Id\" = {0}", id).FirstOrDefaultAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            // Call the insert procedure
            await _context.Database.ExecuteSqlRawAsync("CALL insert_product({0}, {1}, {2})", product.Name, product.Qty, product.Cost);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            // Call the update procedure
            await _context.Database.ExecuteSqlRawAsync("CALL update_product({0}, {1}, {2}, {3})", id, product.Name, product.Qty, product.Cost);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            // Call the delete procedure
            await _context.Database.ExecuteSqlRawAsync("CALL delete_product({0})", id);
            return NoContent();
        }
    }
}
